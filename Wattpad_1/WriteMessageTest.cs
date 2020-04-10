using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Wattpad_1.PageObjects;
using Wattpad_1.PageObjects.TestsBO;

namespace Wattpad_1
{
    [TestClass]
    public class WriteMessageTest
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private HomePage homePage;
        private InboxPage inboxPage;
        private LoginCredentialsBo loginCredentials = new LoginCredentialsBo();
        private WriteMessageTestBO writeMessageTestBO = new WriteMessageTestBO();

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
            loginPage.LoginApplication(loginCredentials.Username, loginCredentials.Password);
        }
        [TestMethod]
        public void Write_Message_Test()
        {
            homePage.NavigateToProfileDropdown();
            homePage.ClickInboxButton();
            inboxPage.ClickNewMessageButton();
            inboxPage.WriteReceiverInput(writeMessageTestBO.receiver);
            inboxPage.ClickPersonInput();
            inboxPage.WriteChatTextarea(writeMessageTestBO.chatMessage);
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
