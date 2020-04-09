using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wattpad_1.PageObjects
{
    class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver browser)
        {
            driver = browser;
        }

        //Assert pentru username 
        private IWebElement LblUsername => driver.FindElement(By.CssSelector("h2[class='greeting-text']"));
        public string UsernameText => LblUsername.Text;
        //
        private By ProfileDropdown => By.XPath("//*[@id='profile-dropdown']/a/span[2]");
        private IWebElement ProfileDropdownSpan()
        {
            return driver.FindElement(ProfileDropdown);
        }
        public void NavigateToProfileDropdown()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(ProfileDropdown));
            ProfileDropdownSpan().Click();
        }
        private By MyProfile => By.XPath("//*[@id='profile-dropdown']/div[2]/ul/li[1]/a");
        //private By Greeting => By.CssSelector("h2[class='greeting-text']");
        private IWebElement MyProfileButton()
        {
            return driver.FindElement(MyProfile);
        }
        //*[@id="profile-dropdown"]/a/span[2]
        public void NavigateToProfilePage()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(MyProfile));
            MyProfileButton().Click();
        }
        //
        private By LibraryDropdown => By.XPath("//*[@id='profile-dropdown']/a");
        private IWebElement LibraryDropdownCaret()
        {
            return driver.FindElement(LibraryDropdown);
        }
        public void NavigateToLibraryDropdown()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(LibraryDropdown));
            LibraryDropdownCaret().Click();
        }
        private By MyLibrary => By.XPath("//*[@id='profile-dropdown']/div[2]/ul/li[6]/a");

        private IWebElement MyLibraryButton()
        {
            return driver.FindElement(MyLibrary);
        }
        public void NavigateToLibraryPage()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(MyLibrary));
            MyLibraryButton().Click();
        }
 
        //
        private By Write => By.XPath("//*[@id='header']/nav[2]/ul/li");

        private IWebElement WriteDropdownCaret()
        {
            return driver.FindElement(Write);
        }

        public void ClickWriteDropdown()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.FindElement(Write));
            WriteDropdownCaret().Click();
        }

        private By WriteDropdown => By.XPath("//*[@id='header']/nav[2]/ul/li/div[2]");
        //
        private By CreateStory => By.XPath("//*[@id='header']/nav[2]/ul/li/div[2]/ul/li[1]/a");

        private IWebElement BtnCreateStory()
        {
            return driver.FindElement(CreateStory);
        }
        public void ClickCreateStoryBtn()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(WriteDropdown));
            BtnCreateStory().Click();
        }

        private By Inbox => By.XPath(" //div[@id='profile-dropdown']/div[@role='menu']//a[@href='/inbox']");

        private IWebElement InboxButton()
        {
            return driver.FindElement(Inbox);
        }
        public void ClickInboxButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(Inbox));
            InboxButton().Click();
        }

        //



    }
}
