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
    class InboxPage : EMailBoxPage
    {
        public InboxPage(IWebDriver driver) => this.driver = driver;

        public IWebElement Header => driver.FindElement(By.ClassName("folder_title clear"));
    }
}
