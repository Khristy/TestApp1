using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp1.PageObjects
{
    static class Navigator
    {
        public static TranslatePage OpenTranslatePage(this IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://perevod.i.ua/");
            return new TranslatePage(driver);
        }

        public static HomePage OpenHomePage(this IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://i.ua/");
            return new HomePage(driver);
        }

        public static EMailBoxPage OpenPassportPage(this IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://i.ua/");
            HomePage homePage = new HomePage(driver);
            homePage.LogIn();
            return new EMailBoxPage(driver);
        }
    }
}
