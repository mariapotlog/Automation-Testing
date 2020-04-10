using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Wattpad_1.PageObjects;
using Wattpad_1.PageObjects.TestsBO;

namespace Wattpad_1
{
    [TestClass]
    public class ChangeProfileLocationTest
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private ProfilePage profilePage;
        private HomePage homePage;
        private LoginCredentialsBo loginCredentials = new LoginCredentialsBo();
        private ChangeProfileLocationBO changeProfileLocationBO = new ChangeProfileLocationBO();


        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            profilePage = new ProfilePage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.wattpad.com/");
            loginPage.NavigateToLoginPage();
            loginPage.LoginApplication(loginCredentials.Username, loginCredentials.Password);
        }
        [TestMethod]
        public void Change_Profile_Location()
        {
            homePage.NavigateToProfileDropdown();
            homePage.NavigateToProfilePage();
            profilePage.ClickKeepTrackButton();
            profilePage.ClickEditButton();
            profilePage.ClickAndWriteLocationInput(changeProfileLocationBO.location);

            profilePage.AssertChangeProfileLocation(changeProfileLocationBO.assertMessage);
        }
        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
