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

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            var loginPage = new LoginPage(driver);
            searchBook = new HomePage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.wattpad.com/");
            loginPage.NavigateToLoginPage();
            loginPage.LoginApplication("stefanatoma98@gmail.com", "testareautomata");
        }

        [TestMethod]
        public void AddBookToLibrary()
        {
            searchBook.SearchForBook("Distorted");
           // searchBook.SelectThisBook();
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}