using System;
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
        private BooksFoundPage booksFound;
        private DistortedBookPage plusSgn;
        private LoginPage loginPage;
        private HomePage homePage;
        private BooksFoundPage book;
        private LibraryPage library;

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
            booksFound = homePage.NavigateToBooksFoundPage();
            book = new BooksFoundPage(driver);
            plusSgn = new DistortedBookPage(driver);
            library = new LibraryPage(driver);
            
            
        }

        [TestMethod]
        public void AddBookToLibrary()
        {
            searchBook.SearchForBook("A Brilliant Plan");
            booksFound.SelectThisBook();
            plusSgn.ApasaPePlus();
            plusSgn.CheckReadingList();
            plusSgn.GoToLibrary();
            library.GoToReadingList();
            library.SelectReadingList();

            var expectedResult = "A Brilliant Plan";           
            Assert.AreEqual(expectedResult, library.LblBookTitle.Text);
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
