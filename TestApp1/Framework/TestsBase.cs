using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp1.PageObjects;


namespace TestApp1.Framework
{

    public class TestBase
    { 

    public IWebDriver driver;

    [OneTimeSetUp]
    public void BaseOneTimeSetUp()
    {
        driver = WebDriverFactory.GetInstance();
        OneTimeSetUp();
    }

        public virtual void OneTimeSetUp()
        { }
     

    [SetUp]
    public void BaseSetUp()
    {
            Console.WriteLine(TestContext.CurrentContext.Test.Name);
    }


    [TearDown]
    public void BaseTearDown()
    {
            Console.WriteLine(TestContext.CurrentContext.Result.Outcome.Status);
            TearDown();
    }

     public void TearDown()
    { }

    [OneTimeTearDown]
    public void BaseOneTimeTearDown()
    {
        driver.Quit();
    }
}
}
