using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp1
{
    class HomePageTests
    {
        static void Main(string[] args)
        {
        }

        [Test]
        public void HomePageTitle()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.i.ua/");

            Assert.AreEqual("I.UA - твоя почта ", driver.Title);
            driver.Close();
        }


    }
}
