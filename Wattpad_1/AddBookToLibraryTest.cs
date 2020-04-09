using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Wattpad_1.PageObjects;

namespace Wattpad_1
{

    [TestClass]
    public class AddBookToLibraryTest
    {
        private IWebDriver driver;
        private HomePage searchBook;
        private BooksFoundPage booksFoundPage;
        private BookSelectedPage bookSelectedPage;
        private LoginPage loginPage;
        private HomePage homePage;
        private LibraryPage libraryPage;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
            searchBook = new HomePage(driver);
            homePage = new HomePage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.wattpad.com/");
            loginPage.NavigateToLoginPage();
            loginPage.LoginApplication("stefanatoma98@gmail.com", "testareautomata");
            booksFoundPage = homePage.NavigateToBooksFoundPage();
            bookSelectedPage = new BookSelectedPage(driver);
            libraryPage = new LibraryPage(driver);
        }

        [TestMethod]
        public void AddBookToLibrary()
        {
            searchBook.SearchForBook("Radioactive Evolution");
            booksFoundPage.SelectThisBook();
            bookSelectedPage.ApasaPePlus();
            bookSelectedPage.CheckReadingList();
            homePage.NavigateToLibraryDropdown();
            homePage.NavigateToLibraryPage();
            libraryPage.GoToReadingList();
            libraryPage.SelectReadingList();

            libraryPage.AssertAddBookToLibraryTest();
        }

        [TestCleanup]
        public void CleanUp()
        {
            libraryPage.DeleteBookFromLibrary();
            bookSelectedPage.ApasaPePlus();
            bookSelectedPage.CheckReadingList();
            driver.Quit();
        }
    }
}
