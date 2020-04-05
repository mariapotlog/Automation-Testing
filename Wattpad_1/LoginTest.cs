using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Wattpad_1.PageObjects;

namespace Wattpad_1
{
    [TestClass]
    public class LoginTest
    {
        private IWebDriver driver;
        private LoginPage loginPage;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.wattpad.com/");
            loginPage.NavigateToLoginPage();
        }
        
        [TestMethod]
        public void Login()
        {
            loginPage.LoginApplication("stefanatoma98@gmail.com", "testareautomata");
            var expectedResult = "Welcome home, Stefana_QA!";
            var homePage = new HomePage(driver);

            Assert.AreEqual(expectedResult, homePage.UsernameText);
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
