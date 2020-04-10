using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Wattpad_1.PageObjects;
using Wattpad_1.PageObjects.TestsBO;

namespace Wattpad_1
{
    [TestClass]
    public class PostNewConversationTest
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private ProfilePage profilePage;
        private HomePage homePage;
        private LoginCredentialsBo loginCredentials = new LoginCredentialsBo();
        private PostNewConversationTestBO postNewConversationTestBO = new PostNewConversationTestBO();

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
        public void Post_New_Conversation()
        {
            homePage.NavigateToProfileDropdown();
            homePage.NavigateToProfilePage();
            profilePage.ClickKeepTrackButton();
            profilePage.ClickConversationsButton();
            profilePage.ClickWritePostMessage();
            profilePage.WritePostMessage(postNewConversationTestBO.postMessage);
            profilePage.ClickPostCheckbox();
            profilePage.ClickGotItButton();
            profilePage.ClickAnnounceButton();

            profilePage.AssertPostNewConversationTest(postNewConversationTestBO.assertMessage);
        }
        [TestCleanup]
        public void CleanUp()
        {
            profilePage.ClickMessageDropdownButton();
            profilePage.ClickMessageDeleteButton();
            driver.Quit();
        }
    }
}
