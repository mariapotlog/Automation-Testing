using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wattpad_1.PageObjects
{
    class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By login = By.CssSelector("button[class*='btn btn-sm']");
        private IWebElement BtnLog_in()
        {
            return driver.FindElement(login);
        }

        private By email = By.Id("login-username");
        private IWebElement TxtUserEmail()
        {
            return driver.FindElement(email);
        }

        private By password = By.Id("login-password");
        private IWebElement TxtPassword()
        {
            return driver.FindElement(password);
        }

        private By btnlogin = By.XPath("//input[@class='btn btn-lg btn-left-align btn-orange btn-block enable']");
        private IWebElement BtnLogin()
        {
            return driver.FindElement(btnlogin);
        }

        private By btnGotIt = By.XPath("//a[@class='btn-primary confirm-btn']");
        private IWebElement BtnGotIt()
        {
            return driver.FindElement(btnGotIt);
        }

        public void NavigateToLoginPage()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementExists(login));
            BtnLog_in().Click();
        }

        public void LoginApplication(string username, string password)
        {         
            TxtUserEmail().SendKeys(username);
            TxtPassword().SendKeys(password);
            BtnLogin().Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(btnGotIt));
            BtnGotIt().Click();
        }
    }
}
