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
    class HomePage
    {
        public IWebDriver driver;

        public HomePage(IWebDriver driver) => this.driver = driver;

        public IWebElement LoginInput => driver.FindElement(By.Name("login"));
        public IWebElement PassInput => driver.FindElement(By.Name("pass"));
        public IWebElement SendButton =>  driver.FindElement(By.XPath("//input[@value='Увійти']"));

        public IWebElement TranstaleLink => driver.FindElement(By.LinkText("Перекладач"));

        public EMailBoxPage LogIn()
        {
            LoginInput.SendKeys(TestConfigurations.Username + Keys.Tab);
            PassInput.SendKeys(TestConfigurations.Password);

            SendButton.Click();
            return new EMailBoxPage(driver);
        }

        public TranslatePage GoToTranslatePage()
        {
            TranstaleLink.Click();
            return new TranslatePage(driver);
        }
    }
}
