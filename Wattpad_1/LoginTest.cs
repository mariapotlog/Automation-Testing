using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Wattpad_1.PageObjects;

namespace Wattpad_1
{
    [TestClass]
    public class LoginTest
    {
        private IWebDriver driver;
        private LoginPage loginPage;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.wattpad.com/");
            Thread.Sleep(5000);
            //Aici cred ca e problema, aceasta metoda incerc sa o accesez si imi pica 
            loginPage.NavigateToLoginPage();           
            Thread.Sleep(3000);
        }
        
        [TestMethod]
        public void Login()
        {
            loginPage.LoginApplication("stefanatoma98@gmail.com", "testareautomata");
        }

        /*[TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }*/
    }
}
