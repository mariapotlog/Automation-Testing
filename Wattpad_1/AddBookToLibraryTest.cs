﻿using System;
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
        private BooksFoundPage booksFoundPage;
        private BookSelectedPage bookSelectedPage;
        private LoginPage loginPage;
        private HomePage homePage;
        private LibraryPage libraryPage;
        private LoginCredentialsBo loginCredentials = new LoginCredentialsBo();
        private BookHomePageBO bookHomePageBO = new BookHomePageBO();

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            bookSelectedPage = new BookSelectedPage(driver);
            booksFoundPage = new BooksFoundPage(driver);
            libraryPage = new LibraryPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.wattpad.com/");
            loginPage.NavigateToLoginPage();
            loginPage.LoginApplication(loginCredentials.Username, loginCredentials.Password);
        }

        [TestMethod]
        public void AddBookToLibrary()
        {
            homePage.SearchForBook(bookHomePageBO.BookTitle);
            homePage.NavigateToBooksFoundPage();
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
