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
    //string testname =  TestContext.CurrentContext.Test.Name;

    [OneTimeSetUp]
    public void BaseOneTimeSetUp()
    {
       Logger.InitLogger();

        driver = WebDriverFactory.GetInstance();
        OneTimeSetUp();
    }

        public virtual void OneTimeSetUp()
        { }
     

    [SetUp]
    public void BaseSetUp()
    {
            Console.WriteLine("---------------------------------");
            Console.WriteLine(TestContext.CurrentContext.Test.Name);
            SetUp();
    }

     public  virtual void SetUp()
     {
            
     }

    [TearDown]
    public void BaseTearDown()
    {
            Console.WriteLine(TestContext.CurrentContext.Result.Outcome.Status);
            Console.WriteLine("---------------------------------");

            if (TestContext.CurrentContext.Result.Outcome.Status.ToString().Equals("Failed"))
            {
                Logger.Log.Error(TestContext.CurrentContext.Test.Name); 
                TakesScreenshot();
                
            }

            TearDown();
    }

    public virtual void TearDown()
    {

    }

        private void TakesScreenshot()
        {
            throw new NotImplementedException();
        }

        [OneTimeTearDown]
    public void BaseOneTimeTearDown()
    {
        driver.Quit();
    }
}
}
