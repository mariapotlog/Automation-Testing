using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wattpad_1.PageObjects.ChangeStoryNotes;

namespace Wattpad_1.PageObjects
{
    class StoryNotesPage
    {
        private IWebDriver driver;

        public StoryNotesPage(IWebDriver browser)
        {
            driver = browser;

        }
        private By storyNotes => By.CssSelector("div[id='story-planner-tab']");
        private IWebElement BtnStoryNotes()
        {
            return driver.FindElement(storyNotes);
        }

        public void SelectStoryNotesEdit()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(storyNotes));
            BtnStoryNotes().Click();
        }

        private By protagonistName => By.XPath("//*[@id='protagonist-form']/div[3]/div[2]/textarea");
        private IWebElement TxtProtagonistName => driver.FindElement(protagonistName);

        private By pronoun => By.XPath("//div[@class='form-field']/select[@name='protagonist.pronoun']");
        private IWebElement DdlPronoun => driver.FindElement(pronoun);

        private By extrovert => By.XPath("//input[@name='protagonist.extrovert_introvert']");
        private IWebElement RangeExtrovert => driver.FindElement(extrovert);

        private By unlikable => By.XPath("//input[@name='protagonist.likeable']");
        private IWebElement RangeUnlikable => driver.FindElement(unlikable);

        private By future => By.XPath("//input[@name='protagonist.focus_past_future']");
        private IWebElement RangeFuture => driver.FindElement(future);

        private By usesHeart => By.XPath("//input[@name='protagonist.thinking_feeling']");
        private IWebElement RangeUsesHeart => driver.FindElement(usesHeart);

        private By feelingGood => By.Id("protagonist_goal.outcome_feeling-Good");
        private IWebElement FeelingGood => driver.FindElement(feelingGood);

        private By saveStory => By.XPath("//*[@id='story-planner-save-btn']/button");
        private IWebElement BtnSave => driver.FindElement(saveStory);

        private By saved => By.XPath("//*[@id='story-planner-save-btn']/button");
        private IWebElement LblSaved => driver.FindElement(saved);
        public string Saved => LblSaved.Text;


        public void MakeChanges(StoryNotesBO story)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(protagonistName));
            TxtProtagonistName.SendKeys(Keys.Control + "a");
            TxtProtagonistName.SendKeys(Keys.Backspace);
            TxtProtagonistName.SendKeys(story.TxtProtagonistName);
            var selectPronoun = new SelectElement(DdlPronoun);
            selectPronoun.SelectByText(story.DdlPronoun);
        }

        //
        public static int GetPixelsToMoveExtrovert(IWebElement RangeExtrovert, decimal Amount, decimal RangeMax, decimal RangeMin)
        {
            int pixels = 0;
            decimal tempPixels = RangeExtrovert.Size.Width;
            tempPixels = tempPixels / (RangeMax - RangeMin);
            tempPixels = tempPixels * (Amount - RangeMin);
            pixels = Convert.ToInt32(tempPixels);
            return pixels;
        }

        public void ChangeRangeExtrovert()
        {
            int pixelsToMove = GetPixelsToMoveExtrovert(RangeExtrovert, 3, 5, -5);
            Actions action = new Actions(driver);
            action.ClickAndHold(RangeExtrovert).MoveByOffset((-(int)RangeExtrovert.Size.Width / 2), 0).MoveByOffset(pixelsToMove, 0).Release().Perform();
        }

        //

        public static int GetPixelsToMoveUnlikable(IWebElement RangeUnlikable, decimal Amount, decimal RangeMax, decimal RangeMin)
        {
            int pixels = 0;
            decimal tempPixels = RangeUnlikable.Size.Width;
            tempPixels = tempPixels / (RangeMax - RangeMin);
            tempPixels = tempPixels * (Amount - RangeMin);
            pixels = Convert.ToInt32(tempPixels);
            return pixels;
        }

        public void ChangeRangeUnlikable()
        {
            int pixelsToMove = GetPixelsToMoveUnlikable(RangeUnlikable, -2, 5, -5);
            Actions action = new Actions(driver);
            action.ClickAndHold(RangeUnlikable).MoveByOffset((-(int)RangeUnlikable.Size.Width / 2), 0).MoveByOffset(pixelsToMove, 0).Release().Perform();
        }

        //

        public static int GetPixelsToMoveFuture(IWebElement RangeFuture, decimal Amount, decimal RangeMax, decimal RangeMin)
        {
            int pixels = 0;
            decimal tempPixels = RangeFuture.Size.Width;
            tempPixels = tempPixels / (RangeMax - RangeMin);
            tempPixels = tempPixels * (Amount - RangeMin);
            pixels = Convert.ToInt32(tempPixels);
            return pixels;
        }

        public void ChangeRangeFuture()
        {
            int pixelsToMove = GetPixelsToMoveFuture(RangeFuture, 3, 5, -5);
            Actions action = new Actions(driver);
            action.ClickAndHold(RangeFuture).MoveByOffset((-(int)RangeFuture.Size.Width / 2), 0).MoveByOffset(pixelsToMove, 0).Release().Perform();
        }

        //

        public static int GetPixelsToMoveUsesHeart(IWebElement RangeUsesHeart, decimal Amount, decimal RangeMax, decimal RangeMin)
        {
            int pixels = 0;
            decimal tempPixels = RangeUsesHeart.Size.Width;
            tempPixels = tempPixels / (RangeMax - RangeMin);
            tempPixels = tempPixels * (Amount - RangeMin);
            pixels = Convert.ToInt32(tempPixels);
            return pixels;
        }

        public void ChangeRangeUsesHeart()
        {
            int pixelsToMove = GetPixelsToMoveUsesHeart(RangeUsesHeart, 5, 5, -5);
            Actions action = new Actions(driver);
            action.ClickAndHold(RangeUsesHeart).MoveByOffset((-(int)RangeUsesHeart.Size.Width / 2), 0).MoveByOffset(pixelsToMove, 0).Release().Perform();
        }

        //

        public void CheckRadioBtnAndSave()
        {
            FeelingGood.Click();
            BtnSave.Click();
        }

        public void AssertChangeStoryNotesTest(string expectedResult)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(saved));
            Assert.AreEqual(expectedResult, Saved);
        }
    }
}
