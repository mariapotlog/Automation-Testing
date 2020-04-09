using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Wattpad_1.PageObjects;
using Wattpad_1.PageObjects.ChangeSettings;

namespace Wattpad_1
{
    [TestClass]
    public class ChangeSettingsTest
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private HomePage homePage;
        private SettingsPage settings;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            settings = new SettingsPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.wattpad.com/");
            loginPage.NavigateToLoginPage();
            loginPage.LoginApplication("stefanatoma98@gmail.com", "testareautomata");
        }


        [TestMethod]
        public void ChangeSettings()
        {
            homePage.NavigateToProfileDropdown();
            homePage.NavigateToSettings();
            settings.ChangeSettings(new SettingsBO());

            Thread.Sleep(1000);
            string expectedResult = "Your changes were successful!";
            Assert.AreEqual(expectedResult, settings.Message);
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
