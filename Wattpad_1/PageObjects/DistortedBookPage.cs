using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wattpad_1.PageObjects
{
    class DistortedBookPage
    {
        private IWebDriver driver;

        public DistortedBookPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By plusSign => By.CssSelector("button[class*='btn btn-orange btn-sm btn-left-align btn-right-align btn-story-lists on-lists-add-clicked']");
        private IWebElement BtnPlusSign()
        {
            return driver.FindElement(plusSign);
        }

        private By thisOption => By.XPath("//*[@class='dropdown-menu dropdown-menu-right add-to-library']/ul/li[2]/a");
        private IWebElement SelectOption()
        {
            return driver.FindElement(thisOption);
        }

        private By account => By.CssSelector("span[class='username hidden-xs  hidden-sm hidden-md ']");
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
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(driver => driver.FindElement(plusSign));
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
            BtnAccount().Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(driver => driver.FindElement(library));
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
