using OpenQA.Selenium;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace TestApp1.PageObjects
{
    public class TranslatePage
    {
        public IWebDriver driver;

        public IWebElement FirstTextArea => driver.FindElement(By.Id("first_textarea"));
        public IWebElement SecondTextArea => driver.FindElement(By.Id("second_textarea"));
        public IWebElement TranslateButton => driver.FindElement(By.Name("commit"));

        public TranslatePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void TranslatePhrase(string input)
        {
            FirstTextArea.SendKeys(input);
            TranslateButton.Click();
        }

        public void TranslatePhrase(string from, string to, string input)
        {
            FirstTextArea.SendKeys(input);
            TranslateButton.Click();
        }

    }
}
