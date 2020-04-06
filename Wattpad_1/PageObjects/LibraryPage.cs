<<<<<<< HEAD
﻿using OpenQA.Selenium;
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
        private By ReadingList => By.XPath("//*[@id='library-landing-page']/div[1]/div/div/nav/ul/li[3]/a");

        private IWebElement BtnReadingList()
        {
            return driver.FindElement(ReadingList);
        }
        public void ClickReadingListButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.FindElement(ReadingList));
            BtnReadingList().Click();
        }
        
        //
        private By NewReadingList => By.XPath("//*[@id='library-controls']/div[2]/button");

        private IWebElement BtnNewReadingList()
        {
            return driver.FindElement(NewReadingList);
        }
        public void ClickNewReadingListButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.FindElement(NewReadingList));
            BtnNewReadingList().Click();
        }

        //
        private By CreateReadingList => By.XPath("//*[@id='reading-list-name']");

        private IWebElement ReadingListInput()
        {
            return driver.FindElement(CreateReadingList);
        }
        public void ClickCreateReadingList(string listName)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.FindElement(Modal));
            System.Threading.Thread.Sleep(1000);
            ReadingListInput().SendKeys(listName);        
        }

        //
        private By Modal => By.XPath("//*[@id='generic-modal']/div/div/div");

        private IWebElement ReadingListModal()
        {
            return driver.FindElement(Modal);
        }

        //
        private By CreateList => By.XPath("//*[@id='reading-list-create']/div[2]/button[1]");

        private IWebElement BtnCreateList()
        {
            return driver.FindElement(CreateList);
        }
        public void ClickCreateListBtn()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.FindElement(CreateList));
            BtnCreateList().Click();
        }

        public By Book => By.XPath("//*[@id='reading-list']/div/div[2]/aside/div[1]/div[1]/div[2]/h1/span");    

        private IWebElement BookSpan()
        {
            return driver.FindElement(Book);
        }
        public string BookItemList => BookSpan().Text;
    }
}
=======
﻿using OpenQA.Selenium;
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
>>>>>>> 7ead512c9ccd1909b4f82320be879b10f7d48312
