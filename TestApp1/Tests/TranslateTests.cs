using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp1.Framework;
using TestApp1.PageObjects;

namespace TestApp1
{ 
    [TestFixture]
    [Category("TranslateFunctionality")]
    class TranslateTests : TestBase
    { 
        TranslatePage translatePage;

        public override void OneTimeSetUp()
        {
        translatePage = Navigator.OpenTranslatePage(driver);
       
        }

        [TestCase("кот", ExpectedResult = "cat")]
        [TestCase("пес", ExpectedResult = "dog")]
        public string Test1_EnglishToRusish(string input)
        {
            translatePage.TranslatePhrase(input);
            return translatePage.SecondTextArea.Text;
        }

        public override void TearDown()
        {
            translatePage.FirstTextArea.Clear();
        }
    }
}
