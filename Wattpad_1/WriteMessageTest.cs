using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Wattpad_1.PageObjects;

namespace Wattpad_1
{
    [TestClass]
    public class WriteMessageTest
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private HomePage homePage;
        private InboxPage inboxPage;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            inboxPage = new InboxPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.wattpad.com/");
            loginPage.NavigateToLoginPage();
        }
        [TestMethod]
        public void Write_Message_Test()
        {
            loginPage.LoginApplication("stefanatoma98@gmail.com", "testareautomata");
            homePage.NavigateToProfileDropdown();
            homePage.ClickInboxButton();
            inboxPage.ClickNewMessageButton();
            inboxPage.WriteReceiverInput("automationtesting4");
            inboxPage.ClickPersonInput();
            inboxPage.WriteChatTextarea("hello");
            inboxPage.ClickSendButton();
            inboxPage.AssertWriteMessageTest();

        }
        [TestCleanup]
        public void CleanUp()
        {
            inboxPage.ClickDeleteButton();
            driver.Quit();
        }
    }
}
