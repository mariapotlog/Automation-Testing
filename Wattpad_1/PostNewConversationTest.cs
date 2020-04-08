using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Wattpad_1.PageObjects;

namespace Wattpad_1
{
    [TestClass]
    public class PostNewConversationTest
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private ProfilePage profilePage;
        private HomePage homePage;

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
        }
        [TestMethod]
        public void Post_New_Conversation()
        {
            loginPage.LoginApplication("stefanatoma98@gmail.com", "testareautomata");
            homePage.NavigateToProfileDropdown();
            homePage.NavigateToProfilePage();
            profilePage.ClickKeepTrackButton();
            profilePage.ClickConversationsButton();
            profilePage.ClickWritePostMessage();
            profilePage.WritePostMessage("Automation testing is the best");
            profilePage.ClickPostCheckbox();
            profilePage.ClickGotItButton();
            profilePage.ClickAnnounceButton();
            
            var expectedResult = "a few seconds ago";

            Assert.AreEqual(expectedResult, profilePage.PostAddedTime);
        }
        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
