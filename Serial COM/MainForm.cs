using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO.Ports;
using System.Drawing;
using System.Management;
using System.Net;
using System.Reflection;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Megamind.IO.Serial;

namespace Serial_COM
{
    public partial class MainForm : Form
    {
        #region enum ans const

        const string SERIAL_ENTITY_CLASS_GUID = "{4d36e978-e325-11ce-bfc1-08002be10318}";
        readonly string[] StddBaudRate = { "9600", "14400", "19200", "38400", "57600", "115200" };

        #endregion

        #region Data

        string ConfigFilename = "Serial COM Config.xml";
        string EventLogFilename = "Serial COM EventLog.rtf";

        bool _isConnected;
        int _txSelPosition;
        AppConfig _appConfig;
        SerialCom _serialCom;

        bool _isEventLogClear = true;
        DateTime _lastRxTsTime = DateTime.Now;

        string[] _portNames = new string[0];
        string[] _portViewNames = new string[0];

        ManagementEventWatcher _deviceArrivalWatcher;
        ManagementEventWatcher _deviceRemovalWatcher;

        #endregion

        #region App Config

        private void LoadAppConfig()
        {
            try
            {
                if (File.Exists(ConfigFilename))
                    _appConfig = AppConfig.Load(ConfigFilename);
            }
            catch (Exception ex)
            {
                PopupException(ex.Message);
            }

            if (_appConfig == null)
            {
                _appConfig = new AppConfig();
                return;
            }

            if (_appConfig.TxEncode == EncodeType.Mixed)
                ToolStripMenuItemTxEncodeAuto_Click(this, null);
            else if (_appConfig.TxEncode == EncodeType.Ascii)
                ToolStripMenuItemTxEncodeAscii_Click(this, null);
            else if (_appConfig.TxEncode == EncodeType.Hex)
                ToolStripMenuItemTxEncodeHex_Click(this, null);

            if (_appConfig.RxDecode == EncodeType.Mixed)
                ToolStripMenuItemRxDecodeAuto_Click(this, null);
            else if (_appConfig.RxDecode == EncodeType.Ascii)
                ToolStripMenuItemRxDecodeAscii_Click(this, null);
            else if (_appConfig.RxDecode == EncodeType.Hex)
                ToolStripMenuItemRxDecodeHex_Click(this, null);

            toolStripMenuItemTxAppendCR.Checked = _appConfig.AppendCrWithTxData;
            toolStripMenuItemTxAppendNL.Checked = _appConfig.AppendNlWithTxData;
            toolStripMenuItemTxAppendTs.Checked = _appConfig.AppendTsBeforeTxView;
            appendNewlineToolStripMenuItemTx.Checked = _appConfig.AppendNlAfterTxView;
            sendOnKeyPressToolStripMenuItemTx.Checked = _appConfig.SendOnKeyPress;
            selectAllOnSendToolStripMenuItemTx.Checked = _appConfig.SelectAllAfterTx;

            richTextBoxExEventLog.Autoscroll = toolStripMenuItemAutoScroll.Checked = _appConfig.RxAutoScroll;
            richTextBoxExEventLog.WordWrap = toolStripMenuItemWordWrap.Checked = _appConfig.RxWordWrap;
            toolStripMenuItemRxAppendNL.Checked = _appConfig.AppendNlBeforeRxView;
            toolStripMenuItemRxAppendTS.Checked = _appConfig.AppendTsBeforeRxView;
            toolStripMenuItemRxPreserveEventLog.Checked = _appConfig.PreserveHistory;

            this.TopMost = toolStripMenuItemAwaysOnTop.Checked = _appConfig.AlwaysOnTop;
            toolStripMenuItemSetDtrOnConnect.Checked = _appConfig.SetDtrOnConnect;
            toolStripMenuItemWmiPortNames.Checked = _appConfig.ShowWmiPortNames;

            this.Size = _appConfig.WindowSize;
            var winlocation = _appConfig.WindowLocation;
            if (winlocation.X >= Screen.AllScreens.Sum(p => p.Bounds.Width))
            {
                winlocation.X = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;
                winlocation.Y = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            }
            this.Location = winlocation;

            UpdateSendHistotyListView();
            if (_txSelPosition > 0)
                richTextBoxTxData.Text = _appConfig.SendHistory[_txSelPosition - 1];
        }

        private void SaveAppConfig()
        {
            var portName = comboBoxPortName.Text;
            if (comboBoxPortName.SelectedIndex >= 0)
                portName = _portNames[comboBoxPortName.SelectedIndex];
            _appConfig.SerialPortName = portName;
            _appConfig.SerialBaudRate = comboBoxBaudRate.Text;
            _appConfig.WindowSize = this.Size;
            _appConfig.WindowLocation = this.Location;
            AppConfig.Save(ConfigFilename, _appConfig);
        }

        #endregion

        #region Internal Methods

        private void AppendEventLog(string str, Color? color = null, bool appendNewLine = true)
        {
            var clr = color ?? Color.Black;
            if (appendNewLine) str += Environment.NewLine;
            if (_isEventLogClear)
            {
                if (str.StartsWith("\r"))
                    str = str.Remove(0, 1);
                _isEventLogClear = false;
            }
            Invoke(new MethodInvoker(() =>
            {
                richTextBoxExEventLog.AppendText(str, clr);
                if (!richTextBoxExEventLog.Focused)
                    richTextBoxExEventLog.ScrollToCaret();
            }));
        }

        public void AppendEventLogMixedFormatString(byte[] bytes, Color asciicolor, Color binarycolor)
        {
            var isPrevCharAscii = false;
            var sb = new StringBuilder();
            foreach (var item in bytes)
            {
                var isCurrCharAscii = (item >= 32 && item <= 126);
                if (isCurrCharAscii != isPrevCharAscii && sb.Length > 0)
                {
                    AppendEventLog(sb.ToString(), isPrevCharAscii ? asciicolor : binarycolor, false);
                    sb.Clear();
                }

                if (item == 10) sb.Append("<LF>");
                else if (item == 13) sb.Append("<CR>");
                else if (item < 32 || item > 126) sb.AppendFormat("<{0:X2}>", item);
                else sb.AppendFormat("{0}", (char)item);
                isPrevCharAscii = isCurrCharAscii;
            }

            if (sb.Length > 0)
                AppendEventLog(sb.ToString(), isPrevCharAscii ? asciicolor : binarycolor, false);
        }

        public void UpdateStatusLabel(string message)
        {
            Invoke(new Action(() => { toolStripStatusLabel1.Text = message; }));
        }

        private void AppenToSendHistory(string txstr)
        {
            // remove existing
            var idx = _appConfig.SendHistory.IndexOf(txstr);
            if (idx >= 0)
                _appConfig.SendHistory.RemoveAt(idx);

            // remove from first
            if (_appConfig.SendHistory.Count >= _appConfig.SendHistoryCapacity)
                _appConfig.SendHistory.RemoveAt(0);

            _appConfig.SendHistory.Add(txstr);
            UpdateSendHistotyListView();
        }

        private void UpdateSendHistotyListView()
        {
            _txSelPosition = _appConfig.SendHistory.Count;
            listViewTxHistory.Items.Clear();
            if (_txSelPosition <= 0) return;
            for (int i = 1; i <= _txSelPosition; i++)
            {
                string[] row = { i.ToString(), _appConfig.SendHistory[i - 1] };
                var lvitem = new ListViewItem(row);
                listViewTxHistory.Items.Add(lvitem);
            }
            listViewTxHistory.Items[_txSelPosition - 1].EnsureVisible();
        }

        private void MonitorDeviceChanges()
        {
            var deviceArrivalQuery = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2");
            var deviceRemovalQuery = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 3");
            _deviceArrivalWatcher = new ManagementEventWatcher(deviceArrivalQuery);
            _deviceRemovalWatcher = new ManagementEventWatcher(deviceRemovalQuery);
            _deviceArrivalWatcher.EventArrived += (o, args) => DeviceChangedCallback();
            _deviceRemovalWatcher.EventArrived += (sender, eventArgs) => DeviceChangedCallback();
            _deviceArrivalWatcher.Start();
            _deviceRemovalWatcher.Start();
        }

        //called several timse when device arrived or removed
        private void DeviceChangedCallback()
        {
            try
            {
                if (!_isConnected)
                    UpdateSerialPortNames();
            }
            catch (Exception ex)
            {
                PopupException(ex.Message);
            }
        }

        public static IEnumerable<WmiSerialPortInfo> GetWmiSerialPortInfo()
        {
            var portNames = new List<WmiSerialPortInfo>();
            var wmiQuery = "SELECT * FROM Win32_PnPEntity WHERE ClassGuid='" + SERIAL_ENTITY_CLASS_GUID + "'";
            using (var searcher = new ManagementObjectSearcher("root\\CIMV2", wmiQuery))
            {
                foreach (var item in searcher.Get())
                {
                    var port = new WmiSerialPortInfo();
                    try
                    {
                        var allMatches = Regex.Matches(item["Name"].ToString(), @"\(COM(\d)+\)");
                        if (allMatches.Count > 0) port.Name = allMatches[0].Value.Substring(1, allMatches[0].Value.Length - 2);
                        port.Description = item["Description"].ToString();
                        port.Manufacturer = item["Manufacturer"].ToString();
                    }
                    catch { }
                    if (!String.IsNullOrEmpty(port.Name)) portNames.Add(port);
                }
            }
            return portNames.OrderBy(p => p.Name);
        }

        //update combobox if port name sequence changed
        private void UpdateSerialPortNames()
        {
            var portNames = new string[0];
            var portViewNames = new string[0];

            if (_appConfig.ShowWmiPortNames)
            {
                var wmiPortNames = GetWmiSerialPortInfo();
                portNames = wmiPortNames.Select(p => p.Name).ToArray();
                portViewNames = wmiPortNames.Select(p => p.Details).ToArray();
            }
            else
            {
                portNames = SerialPort.GetPortNames();
                Array.Sort(portNames);
                portViewNames = portNames;
            }

            if (!_portNames.SequenceEqual(portNames) || !_portViewNames.SequenceEqual(portViewNames))
            {
                _portNames = portNames;
                _portViewNames = portViewNames;
                Invoke(new Action(() =>
                {
                    var prevSelection = comboBoxPortName.Text;
                    comboBoxPortName.ComboBox.DataSource = portViewNames;

                    if (comboBoxPortName.Items.Contains(prevSelection))
                        comboBoxPortName.SelectedIndex = comboBoxPortName.Items.IndexOf(prevSelection);
                    else if (comboBoxPortName.Items.Count > 0)
                        comboBoxPortName.SelectedIndex = comboBoxPortName.Items.Count - 1;
                }));
            }
        }

        public void UpdateSerialPortDescription()
        {
            var portName = comboBoxPortName.Text;
            if (comboBoxPortName.SelectedIndex >= 0)
                portName = _portNames[comboBoxPortName.SelectedIndex];
            var portInfo = GetWmiSerialPortInfo().FirstOrDefault(p => p.Name == portName);
            if (portInfo != null) toolStripPortDetails.Text = portInfo.Details;
            else toolStripPortDetails.Text = portName;
        }

        public static string ByteArrayToHexString(byte[] bytes, string separator = "")
        {
            return BitConverter.ToString(bytes).Replace("-", separator);
        }

        public static byte[] HexStringToByteArray(string hexstr)
        {
            hexstr.Trim();
            hexstr = hexstr.Replace("-", "");
            hexstr = hexstr.Replace(" ", "");
            return Enumerable.Range(0, hexstr.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hexstr.Substring(x, 2), 16))
                             .ToArray();
        }

        private void PopupException(string message, string caption = "Exception")
        {
            Invoke(new Action(() =>
            {
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }));
        }

        #endregion

        #region ctor

        public MainForm()
        {
            InitializeComponent();
            richTextBoxTxData.ForeColor = Color.DarkGreen;
            listViewTxHistory.ForeColor = Color.DarkGreen;
            richTextBoxTxData.Font = new Font("Consolas", 9);
            richTextBoxExEventLog.Font = new Font("Consolas", 9);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigFilename = Path.Combine(Application.UserAppDataPath, ConfigFilename);
                EventLogFilename = Path.Combine(Application.UserAppDataPath, EventLogFilename);

                LoadAppConfig();
                UpdateSerialPortNames();
                comboBoxBaudRate.ComboBox.DataSource = StddBaudRate;
                if (comboBoxPortName.Items.Contains(_appConfig.SerialPortName))
                    comboBoxPortName.SelectedIndex = comboBoxPortName.Items.IndexOf(_appConfig.SerialPortName);
                if (comboBoxBaudRate.Items.Contains(_appConfig.SerialBaudRate))
                    comboBoxBaudRate.SelectedIndex = comboBoxBaudRate.Items.IndexOf(_appConfig.SerialBaudRate);
            }
            catch (Exception ex)
            {
                PopupException(ex.Message);
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            try
            {
                MonitorDeviceChanges();
                if (_appConfig.PreserveHistory)
                {
                    if (File.Exists(EventLogFilename))
                    {
                        richTextBoxExEventLog.LoadFile(EventLogFilename, RichTextBoxStreamType.RichText);
                        richTextBoxExEventLog.SelectionStart = richTextBoxExEventLog.Text.Length;
                        richTextBoxExEventLog.ScrollToCaret();
                        _isEventLogClear = richTextBoxExEventLog.Text.Length <= 0;
                    }
                }
                RichTextBoxExEventLog_SelectionChanged(sender, e);
                RichTextBoxTxData_SelectionChanged(sender, e);
                UpdateStatusLabel("Ready to Connect");
            }
            catch (Exception ex)
            {
                PopupException(ex.Message);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                SaveAppConfig();
                if (_appConfig.PreserveHistory)
                    richTextBoxExEventLog.SaveFile(EventLogFilename, RichTextBoxStreamType.RichText);
                if (_serialCom != null)
                    _serialCom.Dispose();
            }
            catch (Exception ex)
            {
                PopupException(ex.Message);
            }
        }

        #endregion

        #region File Menu

        private void ToolStripMenuItemNew_Click(object sender, EventArgs e)
        {
            Process.Start(Application.ExecutablePath);
        }

        private void ToolStripMenuItemSaveAs_Click(object sender, EventArgs e)
        {
            try
            {
                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Text Files (*.txt)|*.txt|Rich Text Files (*.rtf)|*.rtf|All Files (*.*)|*.*";
                    var now = DateTime.Today;
                    var filename = string.Format("Serial COM EventLog {0} - {1}", now.ToLongDateString(), now.ToLongTimeString());
                    sfd.FileName = filename.Replace(':', '-').Replace(',', '-');
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        if (Path.GetExtension(sfd.FileName) == ".txt")
                            richTextBoxExEventLog.SaveFile(sfd.FileName, RichTextBoxStreamType.PlainText);
                        else if (Path.GetExtension(sfd.FileName) == ".rtf")
                            richTextBoxExEventLog.SaveFile(sfd.FileName, RichTextBoxStreamType.RichText);
                    }
                }
            }
            catch (Exception ex)
            {
                PopupException(ex.Message);
            }
        }

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Send Menu

        private void ToolStripMenuItemTxEncodeAuto_Click(object sender, EventArgs e)
        {
            _appConfig.TxEncode = EncodeType.Mixed;
            encodeASCIIToolStripMenuItemTx.Checked = false;
            encodeHEXToolStripMenuItemTx.Checked = false;
            encodeMixedToolStripMenuItemTx.Checked = true;

            if (_appConfig.TxEncode == EncodeType.Mixed)
                appendNewlineToolStripMenuItemTx.Checked = true;
        }

        private void ToolStripMenuItemTxEncodeAscii_Click(object sender, EventArgs e)
        {
            _appConfig.TxEncode = EncodeType.Ascii;
            encodeMixedToolStripMenuItemTx.Checked = false;
            encodeHEXToolStripMenuItemTx.Checked = false;
            encodeASCIIToolStripMenuItemTx.Checked = true;
        }

        private void ToolStripMenuItemTxEncodeHex_Click(object sender, EventArgs e)
        {
            _appConfig.TxEncode = EncodeType.Hex;
            encodeMixedToolStripMenuItemTx.Checked = false;
            encodeASCIIToolStripMenuItemTx.Checked = false;
            encodeHEXToolStripMenuItemTx.Checked = true;
        }

        private void ToolStripMenuItemTxAppendCR_CheckedChanged(object sender, EventArgs e)
        {
            _appConfig.AppendCrWithTxData = toolStripMenuItemTxAppendCR.Checked;
        }

        private void ToolStripMenuItemTxAppendNL_CheckedChanged(object sender, EventArgs e)
        {
            _appConfig.AppendNlWithTxData = toolStripMenuItemTxAppendNL.Checked;
        }

        private void AppendNewlineToolStripMenuItemTx_CheckedChanged(object sender, EventArgs e)
        {
            _appConfig.AppendNlAfterTxView = appendNewlineToolStripMenuItemTx.Checked;
        }

        private void ToolStripMenuItemTxAppendTs_CheckedChanged(object sender, EventArgs e)
        {
            _appConfig.AppendTsBeforeTxView = toolStripMenuItemTxAppendTs.Checked;
        }

        private void SendOnKeyPressToolStripMenuItemTx_CheckedChanged(object sender, EventArgs e)
        {
            _appConfig.SendOnKeyPress = sendOnKeyPressToolStripMenuItemTx.Checked;
            if (_appConfig.SendOnKeyPress)
            {
                richTextBoxTxData.Clear();
                richTextBoxTxData.Focus();
            }
        }

        private void SelectAllOnSendToolStripMenuItemTx_CheckedChanged(object sender, EventArgs e)
        {
            _appConfig.SelectAllAfterTx = selectAllOnSendToolStripMenuItemTx.Checked;
        }

        #endregion

        #region Receive Menu

        private void ToolStripMenuItemRxDecodeAuto_Click(object sender, EventArgs e)
        {
            _appConfig.RxDecode = EncodeType.Mixed;
            decodeASCIIToolStripMenuItemRx.Checked = false;
            decodeHEXToolStripMenuItemRx.Checked = false;
            decodeMixedToolStripMenuItemRx.Checked = true;
        }

        private void ToolStripMenuItemRxDecodeAscii_Click(object sender, EventArgs e)
        {
            _appConfig.RxDecode = EncodeType.Ascii;
            decodeMixedToolStripMenuItemRx.Checked = false;
            decodeHEXToolStripMenuItemRx.Checked = false;
            decodeASCIIToolStripMenuItemRx.Checked = true;
        }

        private void ToolStripMenuItemRxDecodeHex_Click(object sender, EventArgs e)
        {
            _appConfig.RxDecode = EncodeType.Hex;
            decodeMixedToolStripMenuItemRx.Checked = false;
            decodeASCIIToolStripMenuItemRx.Checked = false;
            decodeHEXToolStripMenuItemRx.Checked = true;
        }

        private void ToolStripMenuItemRxAppendNL_CheckedChanged(object sender, EventArgs e)
        {
            _appConfig.AppendNlBeforeRxView = toolStripMenuItemRxAppendNL.Checked;
        }

        private void ToolStripMenuItemRxAppendTS_CheckedChanged(object sender, EventArgs e)
        {
            _appConfig.AppendTsBeforeRxView = toolStripMenuItemRxAppendTS.Checked;
        }

        private void ToolStripMenuItemAutoScroll_CheckedChanged(object sender, EventArgs e)
        {
            richTextBoxExEventLog.Autoscroll = _appConfig.RxAutoScroll = toolStripMenuItemAutoScroll.Checked;
        }

        private void ToolStripMenuItemWordWrap_CheckedChanged(object sender, EventArgs e)
        {
            richTextBoxExEventLog.WordWrap = _appConfig.RxWordWrap = toolStripMenuItemWordWrap.Checked;
        }

        private void ToolStripMenuItemRxPreserveEventLog_CheckedChanged(object sender, EventArgs e)
        {
            _appConfig.PreserveHistory = toolStripMenuItemRxPreserveEventLog.Checked;
        }

        #endregion

        #region Tools Menu

        private void ToolStripMenuItemAwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = _appConfig.AlwaysOnTop = toolStripMenuItemAwaysOnTop.Checked;
        }

        private void ToolStripMenuItemToolsResetOnConnect_CheckedChanged(object sender, EventArgs e)
        {
            _appConfig.SetDtrOnConnect = toolStripMenuItemSetDtrOnConnect.Checked;
        }

        private void ToolStripMenuItemWmiPortNames_CheckedChanged(object sender, EventArgs e)
        {
            _appConfig.ShowWmiPortNames = toolStripMenuItemWmiPortNames.Checked;
            try
            {
                if (_appConfig.ShowWmiPortNames) comboBoxPortName.Width = 350;
                else comboBoxPortName.Width = 100;
                UpdateSerialPortNames();
            }
            catch (Exception ex)
            {
                PopupException(ex.Message);
            }
        }

        #endregion

        #region Help Menu

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutbox = new AboutBox();
            aboutbox.ShowDialog();
        }

        string _installerFilename = "";

        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateStatusLabel("Checking for update...");
                var github = new Octokit.GitHubClient(new Octokit.ProductHeaderValue("Serial-COM"));
                var release = github.Repository.Release.GetAll("gsmrana", "Serial-COM").Result.FirstOrDefault();

                var verstr = release.TagName;
                if (verstr.StartsWith("v")) verstr = verstr.Remove(0, 1);
                if (verstr.Count(c => c == '.') < 3) verstr += ".0";
                var latestversion = new Version(verstr);
                if (latestversion > Assembly.GetExecutingAssembly().GetName().Version)
                {
                    var message = string.Format("A new version {0} is available!\rDo you want to download and install?", release.TagName);
                    var result = MessageBox.Show(message, "Update Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (result != DialogResult.Yes) return;
                }
                else
                {
                    MessageBox.Show("You are already using the latest version!", "Update Check",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                _installerFilename = Path.Combine(Path.GetTempPath(), release.Assets.FirstOrDefault().Name);
                UpdateStatusLabel(string.Format("Downloading... 0%, Total {0} bytes to {1}",
                    release.Assets.FirstOrDefault().Size, Path.GetFileName(_installerFilename)));
                using (var client = new WebClient())
                {
                    client.DownloadProgressChanged += Client_DownloadProgressChanged;
                    client.DownloadFileCompleted += Client_DownloadFileCompleted;
                    client.DownloadFileAsync(new Uri(release.Assets.FirstOrDefault().BrowserDownloadUrl), _installerFilename);
                }
            }
            catch (Exception ex)
            {
                PopupException(ex.Message, "Update Exception");
                Process.Start("https://github.com/gsmrana/Serial-COM/releases");
            }
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            UpdateStatusLabel(string.Format("Downloading... {0}%, {1} of {2} bytes",
                e.ProgressPercentage, e.BytesReceived, e.TotalBytesToReceive));
        }

        private void Client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null) throw e.Error;
                UpdateStatusLabel("Installing: " + Path.GetFileName(_installerFilename));
                Process.Start(_installerFilename);
                this.Close();
            }
            catch (Exception ex)
            {
                PopupException(ex.Message, "Download Exception");
            }
        }

        #endregion

        #region Toolbar Events

        private void ComboBoxPortList_DropDown(object sender, EventArgs e)
        {
            try
            {
                UpdateSerialPortNames();
            }
            catch (Exception ex)
            {
                PopupException(ex.Message);
            }
        }

        private void ComboBoxPortName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateSerialPortDescription();
            }
            catch (Exception ex)
            {
                PopupException(ex.Message);
            }
        }

        private void ToolStripButtonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_isConnected)
                {
                    var portName = comboBoxPortName.Text;
                    if (comboBoxPortName.SelectedIndex >= 0)
                        portName = _portNames[comboBoxPortName.SelectedIndex];
                    var baudRate = int.Parse(comboBoxBaudRate.Text);

                    _serialCom = new SerialCom(portName, baudRate, _appConfig.SetDtrOnConnect);
                    _serialCom.OnDataReceived += SerialCom_OnDataReceived;
                    _serialCom.OnException += SerialCom_OnException;
                    _serialCom.Open();

                    _isConnected = true;
                    buttonConnect.Text = "Disconnect";
                    this.Text = string.Format("{0} [{1} - {2}]", Application.ProductName, portName, baudRate);
                    UpdateStatusLabel("Connected at Baudrate " + baudRate);
                    comboBoxPortName.Enabled = false;
                    comboBoxBaudRate.Enabled = false;
                }
                else
                {
                    _isConnected = false;
                    buttonConnect.Text = "Connect";
                    comboBoxPortName.Enabled = true;
                    comboBoxBaudRate.Enabled = true;
                    UpdateStatusLabel("Disconnected");
                    this.Text = Application.ProductName;
                    _serialCom.Close();
                }
                UpdateSerialPortDescription();
            }
            catch (Exception ex)
            {
                PopupException(ex.Message);
            }
        }

        private void ToolStripButtonList_Click(object sender, EventArgs e)
        {
            try
            {
                using (var tableview = new TableViwForm())
                {
                    tableview.Tittle = "Serial Port List";
                    tableview.ColumnHeaders.Add(new ColumnHeader("Name", 80));
                    tableview.ColumnHeaders.Add(new ColumnHeader("WMI Info", 200));
                    tableview.ColumnHeaders.Add(new ColumnHeader("Manufacturer", 180));
                    foreach (var item in GetWmiSerialPortInfo())
                        tableview.DataRows.Add(new[] { item.Name, item.Description, item.Manufacturer });
                    tableview.ShowDialog();
                    var idx = tableview.SelectedIndex;
                    if (idx >= 0 && comboBoxPortName.Items.Count > idx)
                        comboBoxPortName.SelectedIndex = idx;
                }
            }
            catch (Exception ex)
            {
                PopupException(ex.Message);
            }
        }

        private void ToolStripButtonCopyText_Click(object sender, EventArgs e)
        {
            try
            {
                if (richTextBoxExEventLog.Text.Length > 0)
                {
                    Clipboard.SetText(richTextBoxExEventLog.Text);
                }
            }
            catch (Exception ex)
            {
                PopupException(ex.Message);
            }
        }

        private void ToolStripButtonClear_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBoxExEventLog.Clear();
                _isEventLogClear = true;
            }
            catch (Exception ex)
            {
                PopupException(ex.Message);
            }
        }

        #endregion

        #region Rx Context Menu

        private void ContextMenuStripRx_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            copyToolStripMenuItemRx.Enabled = richTextBoxExEventLog.SelectionLength > 0;
            copyAllToolStripMenuItemRx.Enabled = richTextBoxExEventLog.Text.Length > 0;
        }

        private void CopyToolStripMenuItemRx_Click(object sender, EventArgs e)
        {
            richTextBoxExEventLog.Copy();
        }

        private void CopyAllToolStripMenuItemRx_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBoxExEventLog.Text);
        }

        private void ClearAllToolStripMenuItemRx_Click(object sender, EventArgs e)
        {
            richTextBoxExEventLog.Clear();
            _isEventLogClear = true;
        }

        #endregion

        #region Tx Context Menu

        private void ContextMenuStripTx_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cutToolStripMenuItemTx.Enabled = richTextBoxTxData.SelectionLength > 0;
            copyToolStripMenuItemTx.Enabled = richTextBoxTxData.SelectionLength > 0;
        }

        private void CutToolStripMenuItemTx_Click(object sender, EventArgs e)
        {
            richTextBoxTxData.Cut();
        }

        private void CopyToolStripMenuItemTx_Click(object sender, EventArgs e)
        {
            richTextBoxTxData.Copy();
        }

        private void PasteToolStripMenuItemTx_Click(object sender, EventArgs e)
        {
            richTextBoxTxData.Paste();
        }

        private void ClearAllToolStripMenuItemTx_Click(object sender, EventArgs e)
        {
            richTextBoxTxData.Clear();
        }

        #endregion

        #region Send History

        private void ContextMenuStripTxHistory_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sendToolStripMenuItemTxHist.Enabled = listViewTxHistory.SelectedIndices.Count > 0;
            removeToolStripMenuItemTxHist.Enabled = listViewTxHistory.SelectedIndices.Count > 0;
            removeAllToolStripMenuItemTxHist.Enabled = listViewTxHistory.Items.Count > 0;
        }

        private void SendToolStripMenuItemTxHist_Click(object sender, EventArgs e)
        {
            buttonSend.PerformClick();
        }

        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewTxHistory.SelectedIndices.Count <= 0) return;
                var idx = listViewTxHistory.SelectedIndices[0];
                if (idx >= 0 && idx < _appConfig.SendHistory.Count)
                {
                    _appConfig.SendHistory.RemoveAt(idx);
                    UpdateSendHistotyListView();
                }
            }
            catch (Exception ex)
            {
                PopupException(ex.Message);
            }
        }

        private void RemoveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _appConfig.SendHistory.Clear();
                UpdateSendHistotyListView();
            }
            catch (Exception ex)
            {
                PopupException(ex.Message);
            }
        }

        private void RichTextBoxTxData_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                }

                if (e.KeyCode == Keys.Up)
                {
                    if (_appConfig.SendHistory.Count > 0)
                    {
                        if (_txSelPosition > 1) _txSelPosition--;
                        richTextBoxTxData.Text = _appConfig.SendHistory[_txSelPosition - 1];
                    }
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Down)
                {
                    if (_appConfig.SendHistory.Count > 0)
                    {
                        if (_txSelPosition < _appConfig.SendHistory.Count) _txSelPosition++;
                        richTextBoxTxData.Text = _appConfig.SendHistory[_txSelPosition - 1];
                    }
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                PopupException(ex.Message);
            }
        }

        private void RichTextBoxTxData_KeyUp(object sender, KeyEventArgs e)
        {
            // nothing to do here for now
        }

        private void RichTextBoxTxData_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (_appConfig.SendOnKeyPress)
                {
                    var keyval = (byte)e.KeyChar;
                    _serialCom.Write(new byte[] { keyval });

                    var txstr = "";
                    if (keyval > 32 && keyval < 127) txstr = e.KeyChar.ToString();
                    else txstr = "0x" + keyval.ToString("X2");
                    AppendEventLog(txstr, Color.DarkGreen);
                }
                else if (e.KeyChar == '\n') //CTRL+ENTER
                {
                    e.Handled = true;
                    buttonSend.PerformClick();
                }
            }
            catch (Exception ex)
            {
                PopupException(ex.Message);
            }
        }

        private void ListViewTxHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listViewTxHistory.SelectedIndices.Count <= 0) return;
                var idx = listViewTxHistory.SelectedIndices[0];
                if (idx < _appConfig.SendHistory.Count)
                    richTextBoxTxData.Text = _appConfig.SendHistory[idx];
            }
            catch (Exception ex)
            {
                PopupException(ex.Message);
            }
        }

        #endregion

        #region Sending Data

        private void ListViewTxHistory_DoubleClick(object sender, EventArgs e)
        {
            buttonSend.PerformClick();
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_isConnected)
                    ToolStripButtonConnect_Click(sender, e);

                var txstr = richTextBoxTxData.Text;
                if (string.IsNullOrEmpty(txstr)) return;

                //replace windows default newline char \n with \r
                txstr = txstr.Replace("\r\n", "\n");
                txstr = txstr.Replace('\n', '\r');

                AppenToSendHistory(txstr);

                if (_appConfig.AppendTsBeforeTxView)
                {
                    var txts = string.Format("\r[{0:HH:mm:ss.fff}] --> ", DateTime.Now);
                    AppendEventLog(txts, Color.DarkOliveGreen, false);
                }
                else
                {
                    AppendEventLog("\r", Color.DarkOliveGreen, false); //for richtextbox newline
                }

                var txbytes = new List<byte>();
                if (_appConfig.TxEncode == EncodeType.Ascii)
                {
                    if (_appConfig.AppendCrWithTxData) txstr += "\r";
                    if (_appConfig.AppendNlWithTxData) txstr += "\n";
                    _serialCom.Write(txstr);
                    AppendEventLog(txstr, Color.DarkGreen, false);
                }
                else if (_appConfig.TxEncode == EncodeType.Hex)
                {
                    if (txstr.StartsWith("0x")) txstr = txstr.Substring(2);
                    txbytes.AddRange(HexStringToByteArray(txstr));
                    if (_appConfig.AppendCrWithTxData) txbytes.Add((byte)'\r');
                    if (_appConfig.AppendNlWithTxData) txbytes.Add((byte)'\n');
                    _serialCom.Write(txbytes.ToArray());
                    AppendEventLog(ByteArrayToHexString(txbytes.ToArray()), Color.DarkGreen, false);
                }
                else if (_appConfig.TxEncode == EncodeType.Mixed)
                {
                    if (txstr.StartsWith("0x"))
                    {
                        txstr = txstr.Substring(2);
                        txbytes.AddRange(HexStringToByteArray(txstr));
                        if (_appConfig.AppendCrWithTxData) txbytes.Add((byte)'\r');
                        if (_appConfig.AppendNlWithTxData) txbytes.Add((byte)'\n');
                        _serialCom.Write(txbytes.ToArray());
                    }
                    else
                    {
                        if (_appConfig.AppendCrWithTxData) txstr += "\r";
                        if (_appConfig.AppendNlWithTxData) txstr += "\n";
                        _serialCom.Write(txstr);
                        txbytes.AddRange(Encoding.ASCII.GetBytes(txstr));
                    }
                    AppendEventLogMixedFormatString(txbytes.ToArray(), Color.DarkGreen, Color.DarkOliveGreen);
                }

                if (_appConfig.AppendNlAfterTxView) AppendEventLog("\r", Color.DarkGreen, false);
                richTextBoxTxData.Focus();
                if (_appConfig.SelectAllAfterTx) richTextBoxTxData.SelectAll();
            }
            catch (Exception ex)
            {
                PopupException(ex.Message);
            }
        }

        #endregion

        #region Date Received

        private void RichTextBoxExEventLog_SelectionChanged(object sender, EventArgs e)
        {
            labelRxSelection.Text = string.Format("RxSel: {0}", richTextBoxExEventLog.SelectionLength);
        }

        private void RichTextBoxTxData_SelectionChanged(object sender, EventArgs e)
        {
            labelTxSelection.Text = string.Format("TxSel: {0}", richTextBoxTxData.SelectionLength);
        }

        private void SerialCom_OnDataReceived(object sender, SerialComEventArgs e)
        {
            try
            {
                var now = DateTime.Now;
                if (_appConfig.AppendTsBeforeRxView && (now.Subtract(_lastRxTsTime).Milliseconds > _appConfig.AppendTsOnRxIntervalMs))
                {
                    _lastRxTsTime = now;
                    var rxts = string.Format("\r[{0:HH:mm:ss.fff}] <-- ", _lastRxTsTime);
                    AppendEventLog(rxts, Color.MidnightBlue, false);
                }
                else if (_appConfig.AppendNlBeforeRxView)
                {
                    AppendEventLog("\r", Color.MidnightBlue, false);  //for richtextbox newline
                }

                if (_appConfig.RxDecode == EncodeType.Ascii)
                {
                    var rxstr = Encoding.ASCII.GetString(e.Data);
                    AppendEventLog(rxstr, Color.Blue, false);
                }
                else if (_appConfig.RxDecode == EncodeType.Hex)
                {
                    var rxstr = ByteArrayToHexString(e.Data);
                    AppendEventLog(rxstr, Color.Blue, false);
                }
                else if (_appConfig.RxDecode == EncodeType.Mixed)
                {
                    AppendEventLogMixedFormatString(e.Data, Color.Blue, Color.MidnightBlue);
                }

            }
            catch (Exception ex)
            {
                PopupException(ex.Message);
            }
        }

        private void SerialCom_OnException(object sender, SerialComEventArgs e)
        {
            AppendEventLog("Exception --> " + e.Message, Color.Magenta);
        }

        #endregion

    }

    #region Wmi Info Class

    public class WmiSerialPortInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public string Details
        {
            get => string.Format("{0} - {1} | {2}", Name, Description, Manufacturer);
        }
    }

    #endregion

}
