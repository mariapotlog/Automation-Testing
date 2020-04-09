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
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
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

        private By writeMeniu => By.XPath("//*[@id='header']/nav[2]/ul/li/a");
        private IWebElement BtnWrite => driver.FindElement(writeMeniu);

        private By myStories => By.XPath("//*[@id='header']/nav[2]/ul/li/div[2]/ul/li[2]/a");
        private IWebElement BtnMyStories => driver.FindElement(myStories);

        public void NavigateToMyStoriesPage()
        {
            BtnWrite.Click();
            BtnMyStories.Click();
        }
        private By btnSearch => By.CssSelector("span[class='fa fa-search fa-wp-neutral-1 ']");
        private IWebElement BtnSearch()
        {
            return driver.FindElement(btnSearch);
        }
        public BooksFoundPage NavigateToBooksFoundPage()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(driver => driver.FindElement(btnSearch));
            BtnSearch().Click();
            return new BooksFoundPage(driver);
        }
        //Acceseaza "search" din homepage
        private By iptSearch => By.XPath("//*[@id='search-query']");
        private IWebElement Search_Book()
        {
            return driver.FindElement(iptSearch);
        }
        public void SearchForBook(string book_name)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementExists(iptSearch));
            Search_Book().SendKeys(book_name);
            wait.Until(ExpectedConditions.TextToBePresentInElementValue(Search_Book(), book_name));
            BtnSearch().Click();
        }
        private By btnSettings => By.XPath("//*[@class='dropdown-menu dropdown-menu-right large']/ul/li[11]/a");

        private IWebElement BtnSettings()
        {
            return driver.FindElement(btnSettings);
        }

        public void NavigateToSettings()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(btnSettings));
            BtnSettings().Click();
        }
    }
}
