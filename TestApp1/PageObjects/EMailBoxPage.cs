using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp1.PageObjects;

namespace TestApp1.PageObjects
{
    class EMailBoxPage
    {
        public IWebDriver driver;

        public EMailBoxPage(IWebDriver driver) => this.driver = driver;

        public EMailBoxPage()
        {
        }

        public IWebElement InboxLink => driver.FindElement(By.LinkText("Вхідні"));

        public InboxPage InboxPage()
        {
            InboxLink.Click();
            return new InboxPage(driver);
        }
    }
}
