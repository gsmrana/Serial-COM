using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Serial_COM
{
    public enum EncodeType
    {
        Ascii,
        Hex,
        Mixed,
    }

    [Serializable]
    public class AppConfig
    {
        public EncodeType TxEncode { get; set; } = EncodeType.Ascii;
        public EncodeType RxDecode { get; set; } = EncodeType.Ascii;

        public bool AppendCrWithTxData { get; set; }
        public bool AppendNlWithTxData { get; set; }
        public bool AppendTsBeforeTxView { get; set; } = true;
        public bool AppendNlAfterTxView { get; set; }
        public bool SendOnKeyPress { get; set; }
        public bool SelectAllAfterTx { get; set; }

        public bool AppendNlBeforeRxView { get; set; }
        public bool AppendTsBeforeRxView { get; set; }
        public int AppendTsOnRxIntervalMs { get; set; } = 20;
        public bool RxAutoScroll { get; set; } = true;
        public bool RxWordWrap { get; set; } = true;
        public bool PreserveHistory { get; set; } = true;

        public bool AlwaysOnTop { get; set; }
        public bool SetDtrOnConnect { get; set; }
        public bool ShowWmiPortNames { get; set; }

        public string SerialPortName { get; set; } = "";
        public string SerialBaudRate { get; set; } = "";

        public Size WindowSize { get; set; } = new Size();
        public Point WindowLocation { get; set; } = new Point();

        public int SendHistoryCapacity { get; set; } = 100;
        public List<string> SendHistory { get; } = new List<string>();

        public static AppConfig Load(string filename)
        {
            using (var stream = File.OpenRead(filename))
            {
                var xmlser = new XmlSerializer(typeof(AppConfig));
                return xmlser.Deserialize(stream) as AppConfig;
            }
        }

        public static void Save(string filename, AppConfig obj)
        {
            using (var sw = new StreamWriter(filename))
            {
                var xmlser = new XmlSerializer(typeof(AppConfig));
                xmlser.Serialize(sw, obj);
            }
        }
    }
}
