using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wattpad_1.PageObjects
{
    class LibraryPage
    {
        private IWebDriver driver;

        public LibraryPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By readingList => By.XPath("//*[@class='pull-left']/ul/li[3]/a");
        private IWebElement BtnReadingList()
        {
            return driver.FindElement(readingList);
        }

        private By list = By.XPath("//div[@class='story-info vcenter']/h3/a[1]/strong");
        private IList<IWebElement> LstReadingList => driver.FindElements(list);

        private By thisReadingList => By.XPath("//div[@class='story-info vcenter']/h3/a[1]/strong");
        private IWebElement ThisList()
        {
            return driver.FindElement(thisReadingList);
        }
        //creem un element care va selecta cartea "Distorted"
        private IWebElement SelectList => LstReadingList.FirstOrDefault(element => element.Text.Contains(new BookHomePageBO().TxtOption))?.FindElement(thisReadingList);

        //Assert pentru AddBookToReadingList 

        private By ourBooks => By.CssSelector("div[class='content']");
        private IList<IWebElement> LstOurBooks => driver.FindElements(ourBooks);
        private By distortedBook => By.CssSelector("div[class='content']");
        private IWebElement OurBook()
        {
            return driver.FindElement(distortedBook);
        }
        //Identificam cartea noastra din lista de carti
        public IWebElement LblBookTitle => LstOurBooks.FirstOrDefault(element => element.Text.Contains(new BookHomePageBO().TxtBookTitle))?.FindElement(distortedBook);
        //public string BookTitleText() => LblBookTitle.Text;

        public void GoToReadingList()
        {
            BtnReadingList().Click();
        }

        public void SelectReadingList()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(4));
            wait.Until(ExpectedConditions.ElementExists(thisReadingList));
            SelectList.Click();
        }

        
    }
}
