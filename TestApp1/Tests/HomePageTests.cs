using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestApp1.Framework;
using TestApp1.PageObjects;


namespace TestApp1
{
    class HomePageTests : TestBase
    {

        [Test]
        public void PageTitle()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.i.ua/");

            Assert.AreEqual("I.UA - твоя почта ", driver.Title);
            driver.Close();
        }


        [Test]
        public void LoginField()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.i.ua/");

            IWebElement loginField = driver.FindElement(By.Name("login"));
            Assert.IsTrue(loginField.Displayed);
            driver.Close();
        }

        [Test]
        public void FoodAndMoodLink()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.i.ua/");

            IWebElement foodAndMoodLink = driver.FindElement(By.LinkText("Food & Mood"));
            Assert.IsTrue(foodAndMoodLink.Displayed);
            driver.Close();
        }

        [Test]
        public void FoodAndMoodLink2()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.i.ua/");

            IWebElement foodAndMoodLink = driver.FindElement(By.PartialLinkText("Food & Moo"));
            Assert.IsTrue(foodAndMoodLink.Displayed);
            driver.Close();
        }

        [Test]
        public void AllLinks()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.i.ua/");

            IList<IWebElement> allLinks = driver.FindElements(By.TagName("a"));

            foreach (IWebElement link in allLinks)
            {
                Console.WriteLine(link.Text);
                Console.ReadKey();
                Assert.IsTrue(link.Displayed);
            }
            driver.Close();
        }

        [Test]
        public void LogIn_3_1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.i.ua/");

            IWebElement LoginInput = driver.FindElement(By.Name("login"));
            IWebElement PassInput = driver.FindElement(By.Name("pass"));
            IWebElement SendButton = driver.FindElement(By.XPath("//input[@value='Увійти']"));
            IWebElement DomainSelect = driver.FindElement(By.Name("domn"));

            //IJavaScriptExecutor JSDriver = (IJavaScriptExecutor)driver;
            //JSDriver.ExecuteScript("arguments[0].setAttribute('value', '" + "Test" + "')", LoginInput);

            LoginInput.SendKeys("autoTest1234" + Keys.Tab);
            PassInput.SendKeys("autoTest1234autoTest1234");

            SelectElement domainSelect = new SelectElement(DomainSelect);
            domainSelect.SelectByText("i.ua");
            domainSelect.SelectByValue("i.ua");
            domainSelect.SelectByIndex(2);
            string selectedOption = domainSelect.SelectedOption.Text;
            domainSelect.SelectByValue("i.ua");

            Actions action = new Actions(driver);
            action.Click(SendButton).Perform();
            //action.DoubleClick(SendButton).Perform();
            //action.ClickAndHold(SendButton).Perform();
            //action.MoveToElement(SendButton).Perform();
            Assert.IsTrue(driver.Title.Contains(@"Вхідні"));


            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(p => driver.FindElement(By.Name("q")).Displayed);
        }


        [Test]
        public void LogIn_3_2()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.i.ua/");

            IWebElement LoginInput = driver.FindElement(By.Name("login"));
            IWebElement PassInput = driver.FindElement(By.Name("pass"));
            IWebElement SendButton = driver.FindElement(By.XPath("//input[@value='Увійти']"));
            IWebElement DomainSelect = driver.FindElement(By.Name("domn"));
            IWebElement RegistrationLink = driver.FindElement(By.XPath("//a[@href='//passport.i.ua/']"));

            string registrationLink = RegistrationLink.Text;

            LoginInput.SendKeys("autoTest1234" + Keys.Tab);
            string loginValue1 = LoginInput.Text;
            string loginValue2 = LoginInput.GetAttribute("value");
            string loginValue3 = LoginInput.GetAttribute("innerHTML");

            PassInput.SendKeys("autoTest1234autoTest1234");
            string passValue1 = PassInput.Text;
            string passValue2 = PassInput.GetAttribute("value");
            string passValue3 = PassInput.GetAttribute("innerHTML");

            SelectElement domainSelect = new SelectElement(DomainSelect);
            string selectedDomain = domainSelect.SelectedOption.Text;

            bool logInput = LoginInput.Displayed;
        }

        [Test]
        public void LogIn_3_4()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.i.ua/");

            IWebElement LoginInput = driver.FindElement(By.Name("login"));
            IWebElement PassInput = driver.FindElement(By.Name("pass"));
            IWebElement SendButton = driver.FindElement(By.XPath("//input[@value='Увійти']"));
            IWebElement DomainSelect = driver.FindElement(By.Name("domn"));
            IWebElement RegistrationLink = driver.FindElement(By.XPath("//a[@href='//passport.i.ua/']"));

            string login = "autoTest1234";
            string password = "autoTest1234autoTest1234";
            Assert.Pass("Yahooo");

            Assert.True(!RegistrationLink.Displayed, "Element is not displayed");

            LoginInput.SendKeys(login + Keys.Tab);
            string actualLoginValue = LoginInput.GetAttribute("value");

            Assert.AreEqual(login, actualLoginValue);

            PassInput.SendKeys(password);
            string actualPasswordValue = PassInput.GetAttribute("value");

            Assert.AreEqual(login, actualLoginValue);

            SelectElement domainSelect = new SelectElement(DomainSelect);
            string selectedDomain = domainSelect.SelectedOption.Text;

            bool logInput = LoginInput.Displayed;
        }

        [Test]
        public void EmailHoverOver_3_3()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.i.ua/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);

            IWebElement LoginInput = driver.FindElement(By.Name("login"));
            IWebElement PassInput = driver.FindElement(By.Name("pass"));
            IWebElement SendButton = driver.FindElement(By.XPath("//input[@value='Увійти']"));

            LoginInput.SendKeys("autoTest1234" + Keys.Tab);
            PassInput.SendKeys("autoTest1234autoTest1234");
            SendButton.Click();

            IWebElement MailLink = driver.FindElement(By.XPath("//span[text()='Ласкаво просимо на I.UA!']"));
            IWebElement MailLink2 = driver.FindElement(By.XPath("//span[text()='Обережно шахраї!']"));
            //Thread.Sleep(3000);
            Actions action = new Actions(driver);
            action.ClickAndHold(MailLink).Build().Perform();

            //Thread.Sleep(3000);
            IWebElement MailPopUp = driver.FindElement(By.Id("prflpudvmbox_userInfoPopUp"));
            IWebElement MailPopUpText = MailPopUp.FindElement(By.XPath(".//li[contains(., 'Ми раді')]"));
            IWebElement Title = driver.FindElement(By.ClassName("sn_menu_title"));

            Assert.True(MailPopUpText.Displayed);

            Actions action2 = new Actions(driver);
            action2.MoveToElement(Title).Build().Perform();

            Assert.True(MailPopUpText.Displayed);
            Assert.Throws<NoSuchElementException>(() => driver.FindElement(By.ClassName("sn_menu_titledfg")));


            //.True(popUpText1.Contains("Ми раді вітати Вас на новій українській пошт"));
        }


        [Test]
        public void EmailPage()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.i.ua/");

            IWebElement EmailLink = driver.FindElement(By.ClassName("mail_16"));

            driver.WaitForElementDisplayed(EmailLink);

            string OriginalStyle = EmailLink.GetAttribute("style");

            EmailLink.Click();
            string title = driver.Title;
        }

        [Test]
        public void Assert4_1()
        {
            object boxedFirstNumber = true;
            object boxedSecondNumber = true;
            Assert.AreSame(boxedFirstNumber, boxedSecondNumber);
        }

        [Test]
        public void LogIn_4_2()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.i.ua/");

            IWebElement LoginInput = driver.FindElement(By.Name("login"));
            IWebElement PassInput = driver.FindElement(By.Name("pass"));

            string login = "autoTest1234";
            string password = "autoTest1234autoTest1234";

            LoginInput.SendKeys(login + Keys.Tab);
            PassInput.SendKeys(password);

            string actualLoginValue = LoginInput.GetAttribute("value");
            string actualPasswordValue = PassInput.GetAttribute("value");

            Assert.Multiple(() =>
            {
                Assert.AreEqual("Chicho", actualLoginValue);
                Assert.AreEqual("VerySecurePassword", actualPasswordValue);
            });

            IWebElement element = driver.FindElement(By.Name("q"));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(p => element.Displayed);


        }

        [Test]
        public void Translate()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.i.ua/");
            IWebElement body = driver.FindElement(By.TagName("body"));
            body.SendKeys(Keys.Control + "t");
            Actions action = new Actions(driver);
            action.KeyDown(Keys.Control).MoveToElement(body).Click().Perform();
             
        }


        [Test]
        public void Test_GoToTranslatePage()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.i.ua/");

            HomePage homePage = new HomePage(driver);
            TranslatePage translatePage = homePage.GoToTranslatePage();
            
            translatePage.TranslatePhrase("kit");
            Assert.AreEqual("кіт", translatePage.SecondTextArea.Text);
        }
    }
}
