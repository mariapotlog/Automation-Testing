using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Wattpad_1.PageObjects;
using Wattpad_1.PageObjects.TestsBO;

namespace Wattpad_1
{
    [TestClass]
    public class AddReadingListToLibraryTest
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private HomePage homePage;
        private LibraryPage libraryPage;
        private LoginCredentialsBo loginCredentials = new LoginCredentialsBo();
        private AddReadingListToLibraryTestBO addReadingListToLibraryTestBO = new AddReadingListToLibraryTestBO();

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            libraryPage = new LibraryPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.wattpad.com/");
            loginPage.NavigateToLoginPage();
            loginPage.LoginApplication(loginCredentials.Username, loginCredentials.Password);
        }
        [TestMethod]
        public void Add_Reading_List()
        {
            homePage.NavigateToLibraryDropdown();
            homePage.NavigateToLibraryPage();
            libraryPage.ClickReadingListButton();
            libraryPage.ClickNewReadingListButton();
            libraryPage.ClickCreateReadingList(addReadingListToLibraryTestBO.readingList);
            libraryPage.ClickCreateListBtn();

            libraryPage.AssertAddReadingListToLibraryTest(addReadingListToLibraryTestBO.assertString);
        }
        [TestCleanup]
        public void CleanUp()
        {
            libraryPage.ClickMyReadingListButton();
            libraryPage.ClickBookDropdownButton();
            libraryPage.ClickDeleteListButton();
            driver.Quit();
        }
    }
}
