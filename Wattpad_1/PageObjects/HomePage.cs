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

        //Acceseaza "search" din homepage
        private By iptSearch =>By.Id("search-query");
        private IWebElement Search_Book()
        {
            return driver.FindElement(iptSearch);
        }

        private By btnSearch => By.CssSelector("span[class='fa fa-search fa-wp-neutral-1 ']");
        private IWebElement BtnSearch()
        {
            return driver.FindElement(btnSearch);
        }
        //De aici am inceput cu lista de titluri de carti
        private By bookTitles = By.XPath("//h5[@class='story-title-heading']");
        private IList<IWebElement> LstBooks => driver.FindElements(bookTitles);

        private By thisBook => By.XPath("//h5[@class='story-title-heading']");
        private IWebElement ThisBook()
        {
            return driver.FindElement(thisBook);
        }
        //creem un element care va selecta cartea "Distorted"
        private IWebElement SelectBook => LstBooks.FirstOrDefault(element => element.Text.Contains(new BookHomePageBO().TxtBookTitle))?.FindElement(thisBook);

        public void SearchForBook(string book_name)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
            wait.Until(ExpectedConditions.ElementExists(iptSearch));
            Search_Book().SendKeys(book_name);
            BtnSearch().Click();
        }
        //
        private By btnMyProfile => By.XPath("//*[@id='profile-dropdown']/div[2]/ul/li[1]/a");
        private By lblGreeting => By.CssSelector("h2[class='greeting-text']");
        private IWebElement BtnShowProfile()
        {
            return driver.FindElement(btnMyProfile);
        }

        private By ProfileCaret => By.XPath("//*[@id='profile-dropdown']/a/span[2]");
        private IWebElement BtnMyProfile()
        {
            return driver.FindElement(ProfileCaret);
        }
        private By ProfileDropdown => By.XPath("//*[@id='profile-dropdown']/div[2]");
        public void NavigateToProfileDropdown()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.FindElement(lblGreeting));
            BtnMyProfile().Click();
        }
        public void NavigateToProfilePage()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.FindElement(ProfileDropdown));
            BtnShowProfile().Click();
        }
        //
        private By btnMyLibrary => By.XPath("//*[@id='profile-dropdown']/div[2]/ul/li[6]/a");

        private IWebElement BtnShowLibrary()
        {
            return driver.FindElement(btnMyLibrary);
        }
        private By ProfileCaret_2 => By.XPath("//*[@id='profile-dropdown']/a/span[2]");
        private IWebElement BtnMyLibrary()
        {
            return driver.FindElement(ProfileCaret_2);
        }
        private By LibraryDropdown => By.XPath("//*[@id='profile-dropdown']/div[2]");
        public void NavigateToLibraryDropdown()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.FindElement(lblGreeting));
            BtnMyLibrary().Click();
        }
        public void NavigateToLibraryPage()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(LibraryDropdown));
            BtnShowLibrary().Click();
        }
        //
        public void SelectThisBook()
        {
            SelectBook.Click();
        }

    }
}
