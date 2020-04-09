using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        private By login = By.XPath("//*[@id='authentication']/div[1]/button");
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
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(login));
            BtnLog_in().Click();
        }

        public void LoginApplication(string username, string password)
        {         
            TxtUserEmail().SendKeys(username);
            TxtPassword().SendKeys(password);
            BtnLogin().Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(btnGotIt));
            BtnGotIt().Click();
        }
        private By SignUp => By.XPath("//*[@id='authentication-panel']/footer/span/a");
        private IWebElement SignUpButton()
        {
            return driver.FindElement(SignUp);
        }
        public void ClickSignUpButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementExists(SignUp));
            SignUpButton().Click();            
        }

        private By RegisterUsername => By.Id("signup-username");
        private IWebElement RegisterUsernameInput()
        {
            return driver.FindElement(RegisterUsername);
        }
        private By RegisterEmail => By.Id("signup-email");
        private IWebElement RegisterEmailInput()
        {
            return driver.FindElement(RegisterEmail);
        }
        private By RegisterPassword => By.Id("signup-password");
        private IWebElement RegisterPasswordInput()
        {
            return driver.FindElement(RegisterPassword);
        }
        private By Month => By.Id("signup-month");

        private IWebElement SelectMonth => driver.FindElement(Month);

       
        private By Day => By.Id("signup-day");

        private IWebElement SelectDay => driver.FindElement(Day);

        private By Year => By.Id("signup-year");
        private IWebElement SelectYear => driver.FindElement(Year);

        private By StartReading => By.XPath("//*[@id='signupForm']/input[3]");
        private IWebElement StartReadingButton() 
        {
            return driver.FindElement(StartReading);
        }
        private By RegisterModal => By.XPath("//*[@id='landing']/div[8]/div");
        public void WriteRegisterInputs(string username, string email, string password)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementExists(RegisterModal));
            RegisterUsernameInput().SendKeys(username);
            RegisterEmailInput().SendKeys(email);
            RegisterPasswordInput().SendKeys(password);
        }
        public void SetMonth(string month)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.FindElement(Month));
            var select_Month = new SelectElement(SelectMonth);
            select_Month.SelectByText(month);
        }
        public void SetDay(string day)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.FindElement(Day));
            var select_Day = new SelectElement(SelectDay);
            select_Day.SelectByText(day);
        }
        public void SetYear(string year)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.FindElement(Year));
            var select_Year = new SelectElement(SelectYear);
            select_Year.SelectByText(year);
        }
        public void ClickStartReadingButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(StartReading));
            StartReadingButton().Click();
        }
        private By Greeting => By.XPath("//*[@id='component-onboardingwriterjourney-onboarding-writer-journey-/start/writerjourney']/div[2]/div/div/div/div/div/h4");

        public By FinishModalMessage => By.XPath("//*[@id='component-onboardingwriterjourney-onboarding-writer-journey-/start/writerjourney']/div[2]/div/div/div/div");
        private IWebElement GreetingMessageH4()
        {
            return driver.FindElement(Greeting);
        }
        public string FinalMessage => GreetingMessageH4().Text;

        public void AssertRegisterTest()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(FinishModalMessage));
            var expectedResult = "Hi @AutomationTesting4";
            Assert.AreEqual(expectedResult, FinalMessage);
        }
    }
}
