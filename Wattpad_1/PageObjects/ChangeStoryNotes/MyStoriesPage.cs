using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wattpad_1.PageObjects.ChangeStoryNotes;

namespace Wattpad_1.PageObjects
{
    class MyStoriesPage
    {
        private IWebDriver driver;

        public MyStoriesPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By allStories => By.XPath("//*[@id='creation-works-listing']/div[1]/div/div[1]/div/section/div/div/div/div[2]/div[2]/h3/a/strong");
        private IWebElement BtnAllStories()
        {
            return driver.FindElement(allStories);
        }

        private By storiesTitles = By.XPath("//div[@class='pull-left story-info']/h3[@class='story-title']");
        private IList<IWebElement> LstStories => driver.FindElements(storiesTitles);

        private By thisStory => By.XPath("//div[@class='pull-left story-info']/h3[@class='story-title']");
        private IWebElement ThisBook()
        {
            return driver.FindElement(thisStory);
        }
        //creem un element care va selecta povestea "Our Story"
        private IWebElement SelectStory => LstStories.FirstOrDefault(element => element.Text.Contains(new StoryNotesBO().TxtStoryTitle))?.FindElement(thisStory);


        public void NavigateToOurStory()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(allStories));
            BtnAllStories().Click();
            var wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait2.Until(ExpectedConditions.ElementIsVisible(thisStory));
            SelectStory.Click();
        }

    }
}
