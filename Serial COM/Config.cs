using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace Serial_COM
{
    public static class Config
    {
        public static string PortName { get; set; }
        public static string BaudRate { get; set; }
        public static string WindowSize { get; set; }
        public static string WindowLocation { get; set; }

        public static void Load()
        {
            var config = GetConfiguration();
            PortName = config.AppSettings.Settings["PortName"].Value;
            BaudRate = config.AppSettings.Settings["BaudRate"].Value;
            WindowSize = config.AppSettings.Settings["WindowSize"].Value;
            WindowLocation = config.AppSettings.Settings["WindowLocation"].Value;
        }

        public static void Save()
        {
            var config = GetConfiguration();
            config.AppSettings.Settings["PortName"].Value = PortName;
            config.AppSettings.Settings["BaudRate"].Value = BaudRate;
            config.AppSettings.Settings["WindowSize"].Value = WindowSize;
            config.AppSettings.Settings["WindowLocation"].Value = WindowLocation;
            config.Save(ConfigurationSaveMode.Modified);
        }

        private static Configuration GetConfiguration()
        {
            var roamingConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoaming);
            if (!File.Exists(roamingConfig.FilePath))
            {
                var localConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                localConfig.SaveAs(roamingConfig.FilePath);
            }
            var roamingConfigMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = roamingConfig.FilePath
            };
            return ConfigurationManager.OpenMappedExeConfiguration(roamingConfigMap, ConfigurationUserLevel.None);
        }
    }
}
