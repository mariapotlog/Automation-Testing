using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Wattpad_1.PageObjects;

namespace Wattpad_1
{
    [TestClass]
    public class RegisterTest
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private HomePage homePage;
        private StoryPage storyPage;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            storyPage = new StoryPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.wattpad.com/");
            loginPage.NavigateToLoginPage();
        }
        [TestMethod]
        public void Register()
        {
            //System.Threading.Thread.Sleep(5000);
            loginPage.ClickSignUpButton();
            loginPage.WriteRegisterInputs("AutomationTesting4","jeanribac95@gmail.com","automationtesting");
            loginPage.SetMonth("Apr");
            loginPage.SetDay("1");
            loginPage.SetYear("1999");
            loginPage.ClickStartReadingButton();
            loginPage.AssertRegisterTest();
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
