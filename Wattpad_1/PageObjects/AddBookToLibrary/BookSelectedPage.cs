using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wattpad_1.PageObjects
{
    class BookSelectedPage
    {
        private IWebDriver driver;

        public BookSelectedPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By plusSign => By.XPath("//*[@id='story-landing']/div/div[1]/main/div/div[1]/div/button");
        private IWebElement BtnPlusSign()
        {
            return driver.FindElement(plusSign);
        }

        private By thisOption => By.XPath("//*[@id='story-landing']/div/div[1]/main/div/div[1]/div/div[2]/ul/li[2]/a");
        private IWebElement SelectOption()
        {
            return driver.FindElement(thisOption);
        }

        private By account => By.XPath("//*[@id='profile-dropdown']/a/span[1]");
        private IWebElement BtnAccount()
        {
            return driver.FindElement(account);
        }

        private By library => By.XPath("//*[@id='profile-dropdown']/div[2]/ul/li[6]/a");
        private IWebElement BtnLibrary()
        {
            return driver.FindElement(library);
        }

        public void ApasaPePlus()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(plusSign));
            BtnPlusSign().Click();
        }

        public void CheckReadingList()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(driver => driver.FindElement(thisOption));
            SelectOption().Click();
        }

        public void GoToLibrary()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementToBeClickable(library));
            BtnLibrary().Click();
        }

        public LibraryPage NavigateToLibraryPage()
        {
            BtnAccount().Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(driver => driver.FindElement(library));
            BtnLibrary().Click();
            return new LibraryPage(driver);
        }
    }
}
