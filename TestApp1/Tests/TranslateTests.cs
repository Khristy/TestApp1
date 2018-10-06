using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
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
    [AllureNUnit]
    [Category("TF")]
    class TranslateTests : TestBase
    { 
        TranslatePage translatePage;

        //public override void OneTimeSetUp()
        //{
        //translatePage = Navigator.OpenTranslatePage(driver);
       
        //}

        [Test]
       
        [AllureTms("I'm a test")]
        [AllureTag("NUnit", "Debug")]
        [AllureIssue("GitHub#1", "https://github.com/unickq/allure-nunit")]
        [AllureFeature("Core")]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://google.com");
            //AllureLifecycle cycle = AllureLifecycle.Instance;
            //cycle.AddAttachment();
            AllureLifecycle.Instance.AddAttachment($"Screenshot [{DateTime.Now:HH:mm:ss}]",
            "image/png", driver.TakeScreenshot().AsByteArray);
            Assert.Inconclusive();
        }


        [AllureTms("I'm a test")]
        [AllureTag("NUnit", "Debug")]
        [AllureIssue("GitHub#1", "https://github.com/unickq/allure-nunit")]
        [AllureFeature("Core")]
        public void Test2()
        {           
            Assert.True(true);
        }

        //[TestCase("кот", ExpectedResult = "cat")]
        //[TestCase("пес", ExpectedResult = "dog")]
        //[AllureTms("I'm a test")]
        //[AllureTag("NUnit", "Debug")]
        //[AllureIssue("GitHub#1", "https://github.com/unickq/allure-nunit")]
        //[AllureFeature("Core")]
        //public string Test1_EnglishToRusish(string input)
        //{
        //    translatePage.TranslatePhrase(input);
        //    return translatePage.SecondTextArea.Text;
        //}

        //public override void TearDown()
        //{
        //    translatePage.FirstTextArea.Clear();
        //}
    }

    [TestFixture]
    [AllureNUnit]
    [Category("Test")]
    class TestsAllure
    {
        [TestCase]
        [AllureTms("I'm a test")]
        [AllureTag("NUnit", "Debug")]
        [AllureIssue("GitHub#1", "https://github.com/unickq/allure-nunit")]
        [AllureFeature("Core")]
        public void Test1()
        {
            Assert.True(true);
        }
    }

}
