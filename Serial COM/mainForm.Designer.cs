﻿namespace Serial_COM
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.encodeASCIIToolStripMenuItemTx = new System.Windows.Forms.ToolStripMenuItem();
            this.encodeHEXToolStripMenuItemTx = new System.Windows.Forms.ToolStripMenuItem();
            this.encodeMixedToolStripMenuItemTx = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemTxAppendCR = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTxAppendNL = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.appendNewlineToolStripMenuItemTx = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTxAppendTs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.sendOnKeyPressToolStripMenuItemTx = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllOnSendToolStripMenuItemTx = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.decodeASCIIToolStripMenuItemRx = new System.Windows.Forms.ToolStripMenuItem();
            this.decodeHEXToolStripMenuItemRx = new System.Windows.Forms.ToolStripMenuItem();
            this.decodeMixedToolStripMenuItemRx = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemRxAppendNL = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRxAppendTS = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemAutoScroll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemWordWrap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemRxPreserveEventLog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAwaysOnTop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSetDtrOnConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemWmiPortNames = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripPortDetails = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelRxSelection = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelTxSelection = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBoxRx = new System.Windows.Forms.GroupBox();
            this.richTextBoxExEventLog = new Serial_COM.RichTextBoxEx();
            this.contextMenuStripRx = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItemRx = new System.Windows.Forms.ToolStripMenuItem();
            this.copyAllToolStripMenuItemRx = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllToolStripMenuItemRx = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxTx = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBoxTxData = new System.Windows.Forms.RichTextBox();
            this.contextMenuStripTx = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItemTx = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItemTx = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItemTx = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.clearAllToolStripMenuItemTx = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewTxHistory = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripTxHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sendToolStripMenuItemTxHist = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItemTxHist = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllToolStripMenuItemTxHist = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSend = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonList = new System.Windows.Forms.ToolStripButton();
            this.comboBoxPortName = new System.Windows.Forms.ToolStripComboBox();
            this.comboBoxBaudRate = new System.Windows.Forms.ToolStripComboBox();
            this.buttonConnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCopyText = new System.Windows.Forms.ToolStripButton();
            this.ButtonClear = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBoxRx.SuspendLayout();
            this.contextMenuStripRx.SuspendLayout();
            this.groupBoxTx.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStripTx.SuspendLayout();
            this.contextMenuStripTxHistory.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxRx, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxTx, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(834, 749);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(834, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItemNew_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsToolStripMenuItem.Image")));
            this.saveAsToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.saveAsToolStripMenuItem.Text = "&Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItemSaveAs_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(151, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItemExit_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Checked = true;
            this.toolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.encodeASCIIToolStripMenuItemTx,
            this.encodeHEXToolStripMenuItemTx,
            this.encodeMixedToolStripMenuItemTx,
            this.toolStripSeparator6,
            this.toolStripMenuItemTxAppendCR,
            this.toolStripMenuItemTxAppendNL,
            this.toolStripSeparator5,
            this.appendNewlineToolStripMenuItemTx,
            this.toolStripMenuItemTxAppendTs,
            this.toolStripSeparator3,
            this.sendOnKeyPressToolStripMenuItemTx,
            this.selectAllOnSendToolStripMenuItemTx});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(45, 20);
            this.toolStripMenuItem1.Text = "&Send";
            // 
            // encodeASCIIToolStripMenuItemTx
            // 
            this.encodeASCIIToolStripMenuItemTx.Checked = true;
            this.encodeASCIIToolStripMenuItemTx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.encodeASCIIToolStripMenuItemTx.Name = "encodeASCIIToolStripMenuItemTx";
            this.encodeASCIIToolStripMenuItemTx.Size = new System.Drawing.Size(178, 22);
            this.encodeASCIIToolStripMenuItemTx.Text = "Encode ASCII";
            this.encodeASCIIToolStripMenuItemTx.Click += new System.EventHandler(this.ToolStripMenuItemTxEncodeAscii_Click);
            // 
            // encodeHEXToolStripMenuItemTx
            // 
            this.encodeHEXToolStripMenuItemTx.Name = "encodeHEXToolStripMenuItemTx";
            this.encodeHEXToolStripMenuItemTx.Size = new System.Drawing.Size(178, 22);
            this.encodeHEXToolStripMenuItemTx.Text = "Encode HEX";
            this.encodeHEXToolStripMenuItemTx.Click += new System.EventHandler(this.ToolStripMenuItemTxEncodeHex_Click);
            // 
            // encodeMixedToolStripMenuItemTx
            // 
            this.encodeMixedToolStripMenuItemTx.Name = "encodeMixedToolStripMenuItemTx";
            this.encodeMixedToolStripMenuItemTx.Size = new System.Drawing.Size(178, 22);
            this.encodeMixedToolStripMenuItemTx.Text = "Encode Mixed";
            this.encodeMixedToolStripMenuItemTx.Click += new System.EventHandler(this.ToolStripMenuItemTxEncodeAuto_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(175, 6);
            // 
            // toolStripMenuItemTxAppendCR
            // 
            this.toolStripMenuItemTxAppendCR.CheckOnClick = true;
            this.toolStripMenuItemTxAppendCR.Name = "toolStripMenuItemTxAppendCR";
            this.toolStripMenuItemTxAppendCR.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItemTxAppendCR.Text = "Append - \\r";
            this.toolStripMenuItemTxAppendCR.CheckedChanged += new System.EventHandler(this.ToolStripMenuItemTxAppendCR_CheckedChanged);
            // 
            // toolStripMenuItemTxAppendNL
            // 
            this.toolStripMenuItemTxAppendNL.CheckOnClick = true;
            this.toolStripMenuItemTxAppendNL.Name = "toolStripMenuItemTxAppendNL";
            this.toolStripMenuItemTxAppendNL.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItemTxAppendNL.Text = "Append - \\n";
            this.toolStripMenuItemTxAppendNL.CheckedChanged += new System.EventHandler(this.ToolStripMenuItemTxAppendNL_CheckedChanged);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(175, 6);
            // 
            // appendNewlineToolStripMenuItemTx
            // 
            this.appendNewlineToolStripMenuItemTx.CheckOnClick = true;
            this.appendNewlineToolStripMenuItemTx.Name = "appendNewlineToolStripMenuItemTx";
            this.appendNewlineToolStripMenuItemTx.Size = new System.Drawing.Size(178, 22);
            this.appendNewlineToolStripMenuItemTx.Text = "Append Newline";
            this.appendNewlineToolStripMenuItemTx.CheckedChanged += new System.EventHandler(this.AppendNewlineToolStripMenuItemTx_CheckedChanged);
            // 
            // toolStripMenuItemTxAppendTs
            // 
            this.toolStripMenuItemTxAppendTs.Checked = true;
            this.toolStripMenuItemTxAppendTs.CheckOnClick = true;
            this.toolStripMenuItemTxAppendTs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemTxAppendTs.Name = "toolStripMenuItemTxAppendTs";
            this.toolStripMenuItemTxAppendTs.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItemTxAppendTs.Text = "Append Timestamp";
            this.toolStripMenuItemTxAppendTs.CheckedChanged += new System.EventHandler(this.ToolStripMenuItemTxAppendTs_CheckedChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(175, 6);
            // 
            // sendOnKeyPressToolStripMenuItemTx
            // 
            this.sendOnKeyPressToolStripMenuItemTx.CheckOnClick = true;
            this.sendOnKeyPressToolStripMenuItemTx.Name = "sendOnKeyPressToolStripMenuItemTx";
            this.sendOnKeyPressToolStripMenuItemTx.Size = new System.Drawing.Size(178, 22);
            this.sendOnKeyPressToolStripMenuItemTx.Text = "Send on Key Press";
            this.sendOnKeyPressToolStripMenuItemTx.CheckedChanged += new System.EventHandler(this.SendOnKeyPressToolStripMenuItemTx_CheckedChanged);
            // 
            // selectAllOnSendToolStripMenuItemTx
            // 
            this.selectAllOnSendToolStripMenuItemTx.CheckOnClick = true;
            this.selectAllOnSendToolStripMenuItemTx.Name = "selectAllOnSendToolStripMenuItemTx";
            this.selectAllOnSendToolStripMenuItemTx.Size = new System.Drawing.Size(178, 22);
            this.selectAllOnSendToolStripMenuItemTx.Text = "Select All On Send";
            this.selectAllOnSendToolStripMenuItemTx.CheckedChanged += new System.EventHandler(this.SelectAllOnSendToolStripMenuItemTx_CheckedChanged);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.decodeASCIIToolStripMenuItemRx,
            this.decodeHEXToolStripMenuItemRx,
            this.decodeMixedToolStripMenuItemRx,
            this.toolStripSeparator1,
            this.toolStripMenuItemRxAppendNL,
            this.toolStripMenuItemRxAppendTS,
            this.toolStripSeparator4,
            this.toolStripMenuItemAutoScroll,
            this.toolStripMenuItemWordWrap,
            this.toolStripSeparator7,
            this.toolStripMenuItemRxPreserveEventLog});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(59, 20);
            this.toolStripMenuItem2.Text = "&Receive";
            // 
            // decodeASCIIToolStripMenuItemRx
            // 
            this.decodeASCIIToolStripMenuItemRx.Checked = true;
            this.decodeASCIIToolStripMenuItemRx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.decodeASCIIToolStripMenuItemRx.Name = "decodeASCIIToolStripMenuItemRx";
            this.decodeASCIIToolStripMenuItemRx.Size = new System.Drawing.Size(178, 22);
            this.decodeASCIIToolStripMenuItemRx.Text = "Decode ASCII";
            this.decodeASCIIToolStripMenuItemRx.Click += new System.EventHandler(this.ToolStripMenuItemRxDecodeAscii_Click);
            // 
            // decodeHEXToolStripMenuItemRx
            // 
            this.decodeHEXToolStripMenuItemRx.Name = "decodeHEXToolStripMenuItemRx";
            this.decodeHEXToolStripMenuItemRx.Size = new System.Drawing.Size(178, 22);
            this.decodeHEXToolStripMenuItemRx.Text = "Decode HEX";
            this.decodeHEXToolStripMenuItemRx.Click += new System.EventHandler(this.ToolStripMenuItemRxDecodeHex_Click);
            // 
            // decodeMixedToolStripMenuItemRx
            // 
            this.decodeMixedToolStripMenuItemRx.Name = "decodeMixedToolStripMenuItemRx";
            this.decodeMixedToolStripMenuItemRx.Size = new System.Drawing.Size(178, 22);
            this.decodeMixedToolStripMenuItemRx.Text = "Decode Mixed";
            this.decodeMixedToolStripMenuItemRx.Click += new System.EventHandler(this.ToolStripMenuItemRxDecodeAuto_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // toolStripMenuItemRxAppendNL
            // 
            this.toolStripMenuItemRxAppendNL.CheckOnClick = true;
            this.toolStripMenuItemRxAppendNL.Name = "toolStripMenuItemRxAppendNL";
            this.toolStripMenuItemRxAppendNL.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItemRxAppendNL.Text = "Append Newline";
            this.toolStripMenuItemRxAppendNL.CheckedChanged += new System.EventHandler(this.ToolStripMenuItemRxAppendNL_CheckedChanged);
            // 
            // toolStripMenuItemRxAppendTS
            // 
            this.toolStripMenuItemRxAppendTS.CheckOnClick = true;
            this.toolStripMenuItemRxAppendTS.Name = "toolStripMenuItemRxAppendTS";
            this.toolStripMenuItemRxAppendTS.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItemRxAppendTS.Text = "Append Timestamp";
            this.toolStripMenuItemRxAppendTS.CheckedChanged += new System.EventHandler(this.ToolStripMenuItemRxAppendTS_CheckedChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(175, 6);
            // 
            // toolStripMenuItemAutoScroll
            // 
            this.toolStripMenuItemAutoScroll.Checked = true;
            this.toolStripMenuItemAutoScroll.CheckOnClick = true;
            this.toolStripMenuItemAutoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemAutoScroll.Name = "toolStripMenuItemAutoScroll";
            this.toolStripMenuItemAutoScroll.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItemAutoScroll.Text = "Auto Scroll";
            this.toolStripMenuItemAutoScroll.CheckedChanged += new System.EventHandler(this.ToolStripMenuItemAutoScroll_CheckedChanged);
            // 
            // toolStripMenuItemWordWrap
            // 
            this.toolStripMenuItemWordWrap.Checked = true;
            this.toolStripMenuItemWordWrap.CheckOnClick = true;
            this.toolStripMenuItemWordWrap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemWordWrap.Name = "toolStripMenuItemWordWrap";
            this.toolStripMenuItemWordWrap.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItemWordWrap.Text = "Word Wrap";
            this.toolStripMenuItemWordWrap.CheckedChanged += new System.EventHandler(this.ToolStripMenuItemWordWrap_CheckedChanged);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(175, 6);
            // 
            // toolStripMenuItemRxPreserveEventLog
            // 
            this.toolStripMenuItemRxPreserveEventLog.Checked = true;
            this.toolStripMenuItemRxPreserveEventLog.CheckOnClick = true;
            this.toolStripMenuItemRxPreserveEventLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemRxPreserveEventLog.Name = "toolStripMenuItemRxPreserveEventLog";
            this.toolStripMenuItemRxPreserveEventLog.Size = new System.Drawing.Size(178, 22);
            this.toolStripMenuItemRxPreserveEventLog.Text = "Preserve History";
            this.toolStripMenuItemRxPreserveEventLog.CheckedChanged += new System.EventHandler(this.ToolStripMenuItemRxPreserveEventLog_CheckedChanged);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAwaysOnTop,
            this.toolStripMenuItemSetDtrOnConnect,
            this.toolStripMenuItemWmiPortNames,
            this.ToolStripMenuItemOptions});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "T&ools";
            // 
            // toolStripMenuItemAwaysOnTop
            // 
            this.toolStripMenuItemAwaysOnTop.CheckOnClick = true;
            this.toolStripMenuItemAwaysOnTop.Name = "toolStripMenuItemAwaysOnTop";
            this.toolStripMenuItemAwaysOnTop.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.toolStripMenuItemAwaysOnTop.Size = new System.Drawing.Size(220, 22);
            this.toolStripMenuItemAwaysOnTop.Text = "Always on Top";
            this.toolStripMenuItemAwaysOnTop.CheckedChanged += new System.EventHandler(this.ToolStripMenuItemAwaysOnTop_CheckedChanged);
            // 
            // toolStripMenuItemSetDtrOnConnect
            // 
            this.toolStripMenuItemSetDtrOnConnect.CheckOnClick = true;
            this.toolStripMenuItemSetDtrOnConnect.Name = "toolStripMenuItemSetDtrOnConnect";
            this.toolStripMenuItemSetDtrOnConnect.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.toolStripMenuItemSetDtrOnConnect.Size = new System.Drawing.Size(220, 22);
            this.toolStripMenuItemSetDtrOnConnect.Text = "Set DTR on Connect";
            this.toolStripMenuItemSetDtrOnConnect.CheckedChanged += new System.EventHandler(this.ToolStripMenuItemToolsResetOnConnect_CheckedChanged);
            // 
            // toolStripMenuItemWmiPortNames
            // 
            this.toolStripMenuItemWmiPortNames.CheckOnClick = true;
            this.toolStripMenuItemWmiPortNames.Name = "toolStripMenuItemWmiPortNames";
            this.toolStripMenuItemWmiPortNames.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.toolStripMenuItemWmiPortNames.Size = new System.Drawing.Size(220, 22);
            this.toolStripMenuItemWmiPortNames.Text = "WMI Port Names";
            this.toolStripMenuItemWmiPortNames.CheckedChanged += new System.EventHandler(this.ToolStripMenuItemWmiPortNames_CheckedChanged);
            // 
            // ToolStripMenuItemOptions
            // 
            this.ToolStripMenuItemOptions.Name = "ToolStripMenuItemOptions";
            this.ToolStripMenuItemOptions.Size = new System.Drawing.Size(220, 22);
            this.ToolStripMenuItemOptions.Text = "&Options";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.updateToolStripMenuItem.Text = "&Update...";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.UpdateToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripPortDetails,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.labelRxSelection,
            this.toolStripStatusLabel4,
            this.labelTxSelection});
            this.statusStrip1.Location = new System.Drawing.Point(0, 727);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(834, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripPortDetails
            // 
            this.toolStripPortDetails.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripPortDetails.Name = "toolStripPortDetails";
            this.toolStripPortDetails.Size = new System.Drawing.Size(89, 22);
            this.toolStripPortDetails.Text = "labelPortDetails";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Margin = new System.Windows.Forms.Padding(25, 3, 25, 2);
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel3.Text = "|";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(64, 22);
            this.toolStripStatusLabel1.Text = "labelStatus";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Margin = new System.Windows.Forms.Padding(25, 3, 25, 2);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // labelRxSelection
            // 
            this.labelRxSelection.Margin = new System.Windows.Forms.Padding(0);
            this.labelRxSelection.Name = "labelRxSelection";
            this.labelRxSelection.Size = new System.Drawing.Size(93, 22);
            this.labelRxSelection.Text = "labelRxSelection";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Margin = new System.Windows.Forms.Padding(25, 3, 25, 2);
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel4.Text = "|";
            // 
            // labelTxSelection
            // 
            this.labelTxSelection.Name = "labelTxSelection";
            this.labelTxSelection.Size = new System.Drawing.Size(91, 17);
            this.labelTxSelection.Text = "labelTxSelection";
            // 
            // groupBoxRx
            // 
            this.groupBoxRx.Controls.Add(this.richTextBoxExEventLog);
            this.groupBoxRx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxRx.Location = new System.Drawing.Point(3, 53);
            this.groupBoxRx.Name = "groupBoxRx";
            this.groupBoxRx.Size = new System.Drawing.Size(828, 519);
            this.groupBoxRx.TabIndex = 6;
            this.groupBoxRx.TabStop = false;
            this.groupBoxRx.Text = "Receive";
            // 
            // richTextBoxExEventLog
            // 
            this.richTextBoxExEventLog.Autoscroll = true;
            this.richTextBoxExEventLog.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBoxExEventLog.ContextMenuStrip = this.contextMenuStripRx;
            this.richTextBoxExEventLog.DetectUrls = false;
            this.richTextBoxExEventLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxExEventLog.HideSelection = false;
            this.richTextBoxExEventLog.Location = new System.Drawing.Point(3, 16);
            this.richTextBoxExEventLog.Name = "richTextBoxExEventLog";
            this.richTextBoxExEventLog.ReadOnly = true;
            this.richTextBoxExEventLog.Size = new System.Drawing.Size(822, 500);
            this.richTextBoxExEventLog.TabIndex = 0;
            this.richTextBoxExEventLog.Text = "";
            this.richTextBoxExEventLog.SelectionChanged += new System.EventHandler(this.RichTextBoxExEventLog_SelectionChanged);
            // 
            // contextMenuStripRx
            // 
            this.contextMenuStripRx.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItemRx,
            this.copyAllToolStripMenuItemRx,
            this.clearAllToolStripMenuItemRx});
            this.contextMenuStripRx.Name = "contextMenuStrip1";
            this.contextMenuStripRx.Size = new System.Drawing.Size(120, 70);
            this.contextMenuStripRx.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStripRx_Opening);
            // 
            // copyToolStripMenuItemRx
            // 
            this.copyToolStripMenuItemRx.Name = "copyToolStripMenuItemRx";
            this.copyToolStripMenuItemRx.Size = new System.Drawing.Size(119, 22);
            this.copyToolStripMenuItemRx.Text = "Copy";
            this.copyToolStripMenuItemRx.Click += new System.EventHandler(this.CopyToolStripMenuItemRx_Click);
            // 
            // copyAllToolStripMenuItemRx
            // 
            this.copyAllToolStripMenuItemRx.Name = "copyAllToolStripMenuItemRx";
            this.copyAllToolStripMenuItemRx.Size = new System.Drawing.Size(119, 22);
            this.copyAllToolStripMenuItemRx.Text = "Copy All";
            this.copyAllToolStripMenuItemRx.Click += new System.EventHandler(this.CopyAllToolStripMenuItemRx_Click);
            // 
            // clearAllToolStripMenuItemRx
            // 
            this.clearAllToolStripMenuItemRx.Name = "clearAllToolStripMenuItemRx";
            this.clearAllToolStripMenuItemRx.Size = new System.Drawing.Size(119, 22);
            this.clearAllToolStripMenuItemRx.Text = "Clear All";
            this.clearAllToolStripMenuItemRx.Click += new System.EventHandler(this.ClearAllToolStripMenuItemRx_Click);
            // 
            // groupBoxTx
            // 
            this.groupBoxTx.Controls.Add(this.tableLayoutPanel2);
            this.groupBoxTx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTx.Location = new System.Drawing.Point(3, 578);
            this.groupBoxTx.Name = "groupBoxTx";
            this.groupBoxTx.Size = new System.Drawing.Size(828, 144);
            this.groupBoxTx.TabIndex = 5;
            this.groupBoxTx.TabStop = false;
            this.groupBoxTx.Text = "Send";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.listViewTxHistory, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonSend, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(822, 125);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.richTextBoxTxData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(466, 119);
            this.panel1.TabIndex = 5;
            // 
            // richTextBoxTxData
            // 
            this.richTextBoxTxData.ContextMenuStrip = this.contextMenuStripTx;
            this.richTextBoxTxData.DetectUrls = false;
            this.richTextBoxTxData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxTxData.HideSelection = false;
            this.richTextBoxTxData.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxTxData.Name = "richTextBoxTxData";
            this.richTextBoxTxData.Size = new System.Drawing.Size(466, 119);
            this.richTextBoxTxData.TabIndex = 0;
            this.richTextBoxTxData.Text = "";
            this.richTextBoxTxData.SelectionChanged += new System.EventHandler(this.RichTextBoxTxData_SelectionChanged);
            this.richTextBoxTxData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RichTextBoxTxData_KeyDown);
            this.richTextBoxTxData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RichTextBoxTxData_KeyPress);
            this.richTextBoxTxData.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RichTextBoxTxData_KeyUp);
            // 
            // contextMenuStripTx
            // 
            this.contextMenuStripTx.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItemTx,
            this.copyToolStripMenuItemTx,
            this.pasteToolStripMenuItemTx,
            this.toolStripSeparator2,
            this.clearAllToolStripMenuItemTx});
            this.contextMenuStripTx.Name = "contextMenuStripTx";
            this.contextMenuStripTx.Size = new System.Drawing.Size(119, 98);
            this.contextMenuStripTx.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStripTx_Opening);
            // 
            // cutToolStripMenuItemTx
            // 
            this.cutToolStripMenuItemTx.Name = "cutToolStripMenuItemTx";
            this.cutToolStripMenuItemTx.Size = new System.Drawing.Size(118, 22);
            this.cutToolStripMenuItemTx.Text = "Cut";
            this.cutToolStripMenuItemTx.Click += new System.EventHandler(this.CutToolStripMenuItemTx_Click);
            // 
            // copyToolStripMenuItemTx
            // 
            this.copyToolStripMenuItemTx.Name = "copyToolStripMenuItemTx";
            this.copyToolStripMenuItemTx.Size = new System.Drawing.Size(118, 22);
            this.copyToolStripMenuItemTx.Text = "Copy";
            this.copyToolStripMenuItemTx.Click += new System.EventHandler(this.CopyToolStripMenuItemTx_Click);
            // 
            // pasteToolStripMenuItemTx
            // 
            this.pasteToolStripMenuItemTx.Name = "pasteToolStripMenuItemTx";
            this.pasteToolStripMenuItemTx.Size = new System.Drawing.Size(118, 22);
            this.pasteToolStripMenuItemTx.Text = "Paste";
            this.pasteToolStripMenuItemTx.Click += new System.EventHandler(this.PasteToolStripMenuItemTx_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(115, 6);
            // 
            // clearAllToolStripMenuItemTx
            // 
            this.clearAllToolStripMenuItemTx.Name = "clearAllToolStripMenuItemTx";
            this.clearAllToolStripMenuItemTx.Size = new System.Drawing.Size(118, 22);
            this.clearAllToolStripMenuItemTx.Text = "Clear All";
            this.clearAllToolStripMenuItemTx.Click += new System.EventHandler(this.ClearAllToolStripMenuItemTx_Click);
            // 
            // listViewTxHistory
            // 
            this.listViewTxHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewTxHistory.ContextMenuStrip = this.contextMenuStripTxHistory;
            this.listViewTxHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewTxHistory.FullRowSelect = true;
            this.listViewTxHistory.GridLines = true;
            this.listViewTxHistory.HideSelection = false;
            this.listViewTxHistory.Location = new System.Drawing.Point(475, 3);
            this.listViewTxHistory.MultiSelect = false;
            this.listViewTxHistory.Name = "listViewTxHistory";
            this.listViewTxHistory.Size = new System.Drawing.Size(244, 119);
            this.listViewTxHistory.TabIndex = 8;
            this.listViewTxHistory.UseCompatibleStateImageBehavior = false;
            this.listViewTxHistory.View = System.Windows.Forms.View.Details;
            this.listViewTxHistory.SelectedIndexChanged += new System.EventHandler(this.ListViewTxHistory_SelectedIndexChanged);
            this.listViewTxHistory.DoubleClick += new System.EventHandler(this.ListViewTxHistory_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            this.columnHeader1.Width = 20;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Send History";
            this.columnHeader2.Width = 200;
            // 
            // contextMenuStripTxHistory
            // 
            this.contextMenuStripTxHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendToolStripMenuItemTxHist,
            this.removeToolStripMenuItemTxHist,
            this.removeAllToolStripMenuItemTxHist});
            this.contextMenuStripTxHistory.Name = "contextMenuStripTxHistory";
            this.contextMenuStripTxHistory.Size = new System.Drawing.Size(135, 70);
            this.contextMenuStripTxHistory.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStripTxHistory_Opening);
            // 
            // sendToolStripMenuItemTxHist
            // 
            this.sendToolStripMenuItemTxHist.Name = "sendToolStripMenuItemTxHist";
            this.sendToolStripMenuItemTxHist.Size = new System.Drawing.Size(134, 22);
            this.sendToolStripMenuItemTxHist.Text = "Send";
            this.sendToolStripMenuItemTxHist.Click += new System.EventHandler(this.SendToolStripMenuItemTxHist_Click);
            // 
            // removeToolStripMenuItemTxHist
            // 
            this.removeToolStripMenuItemTxHist.Name = "removeToolStripMenuItemTxHist";
            this.removeToolStripMenuItemTxHist.Size = new System.Drawing.Size(134, 22);
            this.removeToolStripMenuItemTxHist.Text = "Remove";
            this.removeToolStripMenuItemTxHist.Click += new System.EventHandler(this.RemoveToolStripMenuItem_Click);
            // 
            // removeAllToolStripMenuItemTxHist
            // 
            this.removeAllToolStripMenuItemTxHist.Name = "removeAllToolStripMenuItemTxHist";
            this.removeAllToolStripMenuItemTxHist.Size = new System.Drawing.Size(134, 22);
            this.removeAllToolStripMenuItemTxHist.Text = "Remove All";
            this.removeAllToolStripMenuItemTxHist.Click += new System.EventHandler(this.RemoveAllToolStripMenuItem_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSend.Location = new System.Drawing.Point(725, 3);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(88, 45);
            this.buttonSend.TabIndex = 0;
            this.buttonSend.Text = "&Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonList,
            this.comboBoxPortName,
            this.comboBoxBaudRate,
            this.buttonConnect,
            this.toolStripButtonCopyText,
            this.ButtonClear});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(834, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonList
            // 
            this.toolStripButtonList.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButtonList.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonList.Image")));
            this.toolStripButtonList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonList.Name = "toolStripButtonList";
            this.toolStripButtonList.Size = new System.Drawing.Size(97, 22);
            this.toolStripButtonList.Text = "Serial Ports";
            this.toolStripButtonList.Click += new System.EventHandler(this.ToolStripButtonList_Click);
            // 
            // comboBoxPortName
            // 
            this.comboBoxPortName.AutoSize = false;
            this.comboBoxPortName.AutoToolTip = true;
            this.comboBoxPortName.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.comboBoxPortName.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPortName.Name = "comboBoxPortName";
            this.comboBoxPortName.Size = new System.Drawing.Size(100, 23);
            this.comboBoxPortName.DropDown += new System.EventHandler(this.ComboBoxPortList_DropDown);
            this.comboBoxPortName.SelectedIndexChanged += new System.EventHandler(this.ComboBoxPortName_SelectedIndexChanged);
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.AutoToolTip = true;
            this.comboBoxBaudRate.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.comboBoxBaudRate.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(100, 25);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConnect.Image = ((System.Drawing.Image)(resources.GetObject("buttonConnect.Image")));
            this.buttonConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 22);
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.Click += new System.EventHandler(this.ToolStripButtonConnect_Click);
            // 
            // toolStripButtonCopyText
            // 
            this.toolStripButtonCopyText.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.toolStripButtonCopyText.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCopyText.Image")));
            this.toolStripButtonCopyText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCopyText.Name = "toolStripButtonCopyText";
            this.toolStripButtonCopyText.Size = new System.Drawing.Size(85, 22);
            this.toolStripButtonCopyText.Text = "Copy Text";
            this.toolStripButtonCopyText.Click += new System.EventHandler(this.ToolStripButtonCopyText_Click);
            // 
            // ButtonClear
            // 
            this.ButtonClear.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonClear.Image = ((System.Drawing.Image)(resources.GetObject("ButtonClear.Image")));
            this.ButtonClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(58, 22);
            this.ButtonClear.Text = "Clear";
            this.ButtonClear.Click += new System.EventHandler(this.ToolStripButtonClear_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 749);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(430, 370);
            this.Name = "MainForm";
            this.Text = "Serial COM";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBoxRx.ResumeLayout(false);
            this.contextMenuStripRx.ResumeLayout(false);
            this.groupBoxTx.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.contextMenuStripTx.ResumeLayout(false);
            this.contextMenuStripTxHistory.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSetDtrOnConnect;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemOptions;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBoxTx;
        private System.Windows.Forms.GroupBox groupBoxRx;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTxAppendCR;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTxAppendNL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAwaysOnTop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox comboBoxPortName;
        private System.Windows.Forms.ToolStripComboBox comboBoxBaudRate;
        private System.Windows.Forms.ToolStripButton buttonConnect;
        private System.Windows.Forms.ToolStripButton ButtonClear;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStripMenuItem encodeMixedToolStripMenuItemTx;
        private System.Windows.Forms.ToolStripMenuItem encodeASCIIToolStripMenuItemTx;
        private System.Windows.Forms.ToolStripMenuItem encodeHEXToolStripMenuItemTx;
        private System.Windows.Forms.ToolStripMenuItem decodeMixedToolStripMenuItemRx;
        private System.Windows.Forms.ToolStripMenuItem decodeASCIIToolStripMenuItemRx;
        private System.Windows.Forms.ToolStripMenuItem decodeHEXToolStripMenuItemRx;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRxAppendNL;
        private System.Windows.Forms.ToolStripMenuItem sendOnKeyPressToolStripMenuItemTx;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemWmiPortNames;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBoxTxData;
        private System.Windows.Forms.ToolStripStatusLabel toolStripPortDetails;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopyText;
        private RichTextBoxEx richTextBoxExEventLog;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTxAppendTs;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemWordWrap;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAutoScroll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRxAppendTS;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRx;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItemRx;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTx;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItemTx;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItemTx;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItemTx;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripStatusLabel labelRxSelection;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel labelTxSelection;
        private System.Windows.Forms.ToolStripButton toolStripButtonList;
        private System.Windows.Forms.ToolStripMenuItem selectAllOnSendToolStripMenuItemTx;
        private System.Windows.Forms.ListView listViewTxHistory;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTxHistory;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItemTxHist;
        private System.Windows.Forms.ToolStripMenuItem removeAllToolStripMenuItemTxHist;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItemRx;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItemTx;
        private System.Windows.Forms.ToolStripMenuItem sendToolStripMenuItemTxHist;
        private System.Windows.Forms.ToolStripMenuItem copyAllToolStripMenuItemRx;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRxPreserveEventLog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem appendNewlineToolStripMenuItemTx;
    }
}

