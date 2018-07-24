using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestApp1
{
    class WebDriverFactory
    {
        private const string chrome = "CH";
        private const string firefox = "FF";
        private const string internetExplorer = "IE";
        private const string edge = "Edge";


        private static IWebDriver driver;

        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                TestConfigurations configs = TestConfigurations.GetInstance();

                if (TestConfigurations.Browser == chrome)
                {
                   driver = new ChromeDriver();
                }
                else if (TestConfigurations.Browser == firefox)
                {
                    driver = new FirefoxDriver();
                }
                else if (TestConfigurations.Browser == internetExplorer)
                {
                    driver = new InternetExplorerDriver();
                }
                else
                {
                    throw new Exception("Invalid browser in the settings");
                }
            }
            return driver;
        }
    }
}

