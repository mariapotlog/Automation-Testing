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
        private SettingsPage settingsPage;
        private LoginCredentialsBo loginCredentials = new LoginCredentialsBo();

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            settingsPage = new SettingsPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.wattpad.com/");
            loginPage.NavigateToLoginPage();
            loginPage.LoginApplication(loginCredentials.Username, loginCredentials.Password);
        }


        [TestMethod]
        public void ChangeSettings()
        {
            homePage.NavigateToProfileDropdown();
            homePage.NavigateToSettings();
            settingsPage.ChangeSettings(new SettingsBO());

            settingsPage.AssertChangeSettingsTest("Your changes were successful!");
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
