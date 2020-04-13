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
        Auto,
        Ascii,
        Hex
    }

    [Serializable]
    public class AppConfig
    {
        public EncodeType TxEncode { get; set; } = EncodeType.Ascii;
        public EncodeType RxDecode { get; set; } = EncodeType.Ascii;

        public bool AppendCrOnTx { get; set; }
        public bool AppendNlOnTx { get; set; }
        public bool AppendTsOnTx { get; set; } = true;
        public bool SendOnKeyPress { get; set; }
        public bool SelectAllOnTx { get; set; }

        public bool AppendNlOnRx { get; set; }
        public bool AppendTsOnRx { get; set; }
        public bool RxAutoScroll { get; set; } = true;
        public bool RxWordWrap { get; set; } = true;

        public bool AlwaysOnTop { get; set; }
        public bool SetDtrOnConnect { get; set; }
        public bool ShowWmiPortNames { get; set; }

        public string PortName { get; set; } = "";
        public string BaudRate { get; set; } = "";

        public Size WindowSize { get; set; } = new Size();
        public Point WindowLocation { get; set; } = new Point();

        public int SendHistoryCount { get; set; }
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
