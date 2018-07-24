using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TestApp1
{
    public class TestConfigurations
    {
        public static string Browser;
        public static string Username;
        public static string Password;
        public static string Environment;

        private static TestConfigurations configs;
        private static readonly object obj = new object();


        private static string GetConfigFilePath()
        {
            string executingAssembly = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = new DirectoryInfo(executingAssembly).Parent.Parent.Parent.FullName;
            return Path.Combine(path, "MyTestConfigs.xml");
        }

        private static void GetConfigs()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(GetConfigFilePath());

            Browser = xmlDoc.DocumentElement.SelectSingleNode("browser").InnerText;
            Username = xmlDoc.DocumentElement.SelectSingleNode("username").InnerText;
            Password = xmlDoc.DocumentElement.SelectSingleNode("password").InnerText;
            Environment = xmlDoc.DocumentElement.SelectSingleNode("environment").InnerText;
        }

        public static TestConfigurations GetInstance()
        {
            if (configs == null)
            {
                lock (obj)
                {
                    if (configs == null)
                    {
                        GetConfigs();
                        configs = new TestConfigurations();
                    }
                }
            }
            return configs;
        }
    }
}
