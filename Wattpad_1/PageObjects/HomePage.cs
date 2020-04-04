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
        private IWebElement LblUsername => driver.FindElement(By.CssSelector("span[class='username hidden-xs  hidden-sm hidden-md ']"));
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

        public void SelectThisBook()
        {
            SelectBook.Click();
        }

    }
}
