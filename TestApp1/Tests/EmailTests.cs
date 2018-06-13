using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp1.PageObjects;
namespace TestApp1.Tests
{
    class EmailTests
    {
        IWebDriver driver;
        EMailBoxPage passportPage;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = WebDriverFactory.GetInstance();
            passportPage = Navigator.OpenPassportPage(driver);
        }

    }
}
