using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wattpad_1.PageObjects
{
    class StoryPage
    {
        private IWebDriver driver;

        public StoryPage(IWebDriver browser)
        {
            driver = browser;
        }
        //
        //private By StoryTitle => By.XPath("//*[@id='main-edit-container']/div/div[2]/form/div[1]/div[1]/div");
        private By StoryTitle => By.XPath("//*[@id='main-edit-container']/div/div[2]/form/div[1]/div[1]/div");

        private IWebElement StoryTitleInput()
        {
            return driver.FindElement(StoryTitle);
        }

        public void WriteStoryTitle(string title)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(StoryTitle));
            StoryTitleInput().SendKeys(title);
        }
        //
        //private By Description => By.XPath("//*[@id='main-edit-container']/div/div[2]/form/div[1]/div[2]/textarea");
        private By Description => By.XPath("//*[@id='main-edit-container']/div/div[2]/form/div[1]/div[2]/textarea");
        private IWebElement DescriptionTextarea()
        {
            return driver.FindElement(Description);
        }
        public void WriteDescription(string description)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(Description));
            DescriptionTextarea().SendKeys(description);
        }
        //
        private By MainCharacter => By.XPath("//*[@id='main-edit-container']/div/div[2]/form/div[1]/div[3]/div[2]/div/input");
        private IWebElement MainCharacterInput()
        {
            return driver.FindElement(MainCharacter);
        }
        private By AddCharacter => By.XPath("//*[@id='main-edit-container']/div/div[2]/form/div[1]/div[3]/div[2]/div/div");
        private IWebElement AddCharacterBtn()
        {
            return driver.FindElement(AddCharacter);
        }

        public void WriteMainCharacter(string character_name)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(AddCharacter));
            MainCharacterInput().SendKeys(character_name);
            AddCharacterBtn().Click();
        }
        //

        private By Tag => By.CssSelector("div#add-tag");

        private IWebElement AddTag()
        {
            return driver.FindElement(Tag);
        }

        private By TagInput => By.CssSelector("input#tag-input");
        private IWebElement AddTagInput()
        {
            return driver.FindElement(TagInput);
        }
        public void WriteTag(string tag)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(Tag));
            AddTag().Click();
            wait.Until(driver => driver.FindElement(TagInput));
            AddTagInput().SendKeys(tag);
        }
        //
        private By Genre => By.XPath("//*[@id='categoryselect']");

        private IWebElement SelectGenre => driver.FindElement(Genre);

        public void SetGenre(string genre)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(Genre));
            var selectGenre = new SelectElement(SelectGenre);
            selectGenre.SelectByText(genre);
        }

        //
        private By TargetAudience => By.XPath("//*[@id='target-audience']");

        private IWebElement SelectTargetAudience => driver.FindElement(TargetAudience);

        public void SetTargetAudience(string audience)
        {
            var SelectAudience = new SelectElement(SelectTargetAudience);
            SelectAudience.SelectByText(audience);
        }
        //
        private By Language => By.XPath("//*[@id='languageselect']");

        private IWebElement SelectLanguage => driver.FindElement(Language);

        public void SetLanguage(string language)
        {
            var SelectLang = new SelectElement(SelectLanguage);
            SelectLang.SelectByText(language);
        }
        //
        private By Copyright => By.XPath("//*[@id='copyrightSelect']");

        private IWebElement SelectCopyright => driver.FindElement(Copyright);

        public void SetCopyright(string copyright)
        {
            var SelectCopyRight = new SelectElement(SelectCopyright);
            SelectCopyRight.SelectByText(copyright);
        }
   
        //

        private By Rating => By.XPath("//*[@id='main-edit-container']/div/div[2]/form/div[3]/div[2]/div/div/label/span");
        private IWebElement RatingSwitch()
        {
            return driver.FindElement(Rating);
        }
        public void ClickRatingButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.FindElement(Rating));
            RatingSwitch().Click();
        }

        //
        private By Next => By.XPath("//*[@id='edit-controls']/div[2]/button[2]");
        private IWebElement NextButton()
        {
            return driver.FindElement(Next);
        }
        public void ClickNextButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(Next));
            NextButton().Click();
        }
        //
        private By FinalStoryTitle => By.XPath("//*[@id='story-title']");
        private IWebElement StoryTitleH2()
        {
            return driver.FindElement(FinalStoryTitle);
        }
        public void WriteFinalStoryTitle(string title)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(FinalStoryTitle));

            for(int i = 0; i < 15; i++)
            {
                StoryTitleH2().SendKeys(Keys.Backspace);
            } 
            StoryTitleH2().SendKeys(title);

        }

        //
        private By FinalStoryBody => By.XPath("//div[@id='writer-editor']/div[@role='textbox']/p[1]");
        private IWebElement StoryBody()
        {
            return driver.FindElement(FinalStoryBody);
        }
        public void WriteFinalStoryBody(string body)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(FinalStoryBody));
            StoryBody().SendKeys(body);
        }
        //

        private By Publish => By.XPath("//*[@id='writer-navigation']/div[3]/button[1]");
        private IWebElement PublishButton()
        {
            return driver.FindElement(Publish);
        }
        public void ClickPublishButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(Publish));
            PublishButton().Click();
        }

        //

        private By PublishModal => By.XPath("//*[@id='edit-controls']/div[2]/button[2]");
        private By Modal => By.XPath("//*[@id='generic-modal']/div/div");
        private IWebElement PublishModalButton()
        {
            return driver.FindElement(PublishModal);
        }
        public void ClickPublishModalButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(Modal));
            PublishModalButton().Click();
        }
        //
        private By FinishModalMessage => By.XPath("//*[@id='generic-modal']/div/div/div[2]/div[1]/h4");
        private IWebElement FinishModalMessageH4()
        {
            return driver.FindElement(FinishModalMessage);
        }
        public string FinalMessage => FinishModalMessageH4().Text;

        public void AssertAddStoryTest(string expectedResult)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait.Until(ExpectedConditions.ElementIsVisible(FinishModalMessage));
            Assert.AreEqual(expectedResult, FinalMessage);
        }

        private By FinishModalClose => By.XPath("//*[@id='generic-modal']/div/header/div/span");
        private IWebElement FinishModalCloseButton()
        {
            return driver.FindElement(FinishModalClose);
        }
        public void ClickFinishModalCloseButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(FinishModalClose));
            FinishModalCloseButton().Click();
        }

        private By MyStories => By.XPath("//*[@id='header']/nav[2]/ul/li/div[2]/ul/li[2]/a");
        private IWebElement MyStoriesButton()
        {
            return driver.FindElement(MyStories);
        }
        public void ClickMyStoriesButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(MyStories));
            MyStoriesButton().Click();
        }

        //*[@id="quick-links"]/div[2]/button

        private By StoryDropdown => By.XPath("//*[@id='quick-links']/div[2]/button");
        private IWebElement StoryDropdownButton()
        {
            return driver.FindElement(StoryDropdown);
        }   
        public void ClickStoryDropdownButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(StoryDropdown));
            StoryDropdownButton().Click();
        }

        private By DeleteStory => By.XPath("/html//div[@id='quick-links']/div[2]/ul[@role='menu']/li[3]/a[@role='button']");
        private IWebElement DeleteStoryButton()
        {
            return driver.FindElement(DeleteStory);
        }
        public void ClickDeleteStoryButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(DeleteStory));
            DeleteStoryButton().Click();
        }

        //*[@id="delete-story-modal"]/button[2]
        private By Popup_1 => By.XPath("/html//div[@id='delete-story-modal']");
        private By PopupDelete => By.XPath("/html//div[@id='delete-story-modal']/button[@class='btn btn-red']");
        private IWebElement PopupDeleteButton()
        {
            return driver.FindElement(PopupDelete);
        }
        public void ClickPopupDeleteButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(Popup_1));
            PopupDeleteButton().Click();
        }

        private By PopupDeleteConfirmation => By.XPath("//div[@id='delete-only-modal']/div[@class='modal-dialog']//div[@id='delete-story-modal']/button[@class='btn btn-red on-delete']");
        private By Popup_2 => By.XPath("//div[@id='delete-only-modal']/div[@class='modal-dialog']//div[@id='delete-story-modal']//ul/li[.='All comments for this story will be deleted.']");
        private IWebElement PopupDeleteConfirmatioButton()
        {
            return driver.FindElement(PopupDeleteConfirmation);
        }
        public void ClickPopupDeleteConfirmatioButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(Popup_2));
            PopupDeleteConfirmatioButton().Click();
        }
    }
}
