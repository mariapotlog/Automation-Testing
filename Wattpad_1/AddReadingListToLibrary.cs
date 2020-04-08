using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Wattpad_1.PageObjects;

namespace Wattpad_1
{
    [TestClass]
    public class AddReadingListToLibrary
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private HomePage homePage;
        private LibraryPage libraryPage;

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
        }
        [TestMethod]
        public void Add_Reading_List()
        {
            loginPage.LoginApplication("stefanatoma98@gmail.com", "testareautomata");
            homePage.NavigateToLibraryDropdown();
            homePage.NavigateToLibraryPage();
            libraryPage.ClickReadingListButton();
            libraryPage.ClickNewReadingListButton();
            libraryPage.ClickCreateReadingList("Fantasy books");
            libraryPage.ClickCreateListBtn();

            var expectedResult = "Fantasy books";
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(libraryPage.Book));
            //  System.Threading.Thread.Sleep(5000);
            Assert.AreEqual(expectedResult, libraryPage.BookItemList);
        }
        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
