using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wattpad_1.PageObjects
{
    class BooksFoundPage
    {
        private IWebDriver driver;

        public BooksFoundPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By bookTitles = By.XPath("//h5[@class='story-title-heading']");
        private IList<IWebElement> LstBooks => driver.FindElements(bookTitles);

        private By thisBook => By.XPath("//h5[@class='story-title-heading']");
        private IWebElement ThisBook()
        {
            return driver.FindElement(thisBook);
        }
        //creem un element care va selecta cartea "Distorted"
        private IWebElement SelectBook => LstBooks.FirstOrDefault(element => element.Text.Contains(new BookHomePageBO().TxtBookTitle))?.FindElement(thisBook);

        public void SelectThisBook()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementExists(thisBook));
            SelectBook.Click();
        }

        public DistortedBookPage NavigateToDistortedBookPage()
        {
            SelectBook.Click();
            return new DistortedBookPage(driver);
        }
    }
}
