using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Wattpad_1.PageObjects;
using Wattpad_1.PageObjects.ChangeStoryNotes;
using Wattpad_1.PageObjects.TestsBO;

namespace Wattpad_1
{
    [TestClass]
    public class ChangeStoryNotesTest
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private HomePage homePage;
        private MyStoriesPage myStories;
        private StoryNotesPage storyNotes;
        private LoginCredentialsBo loginCredentials = new LoginCredentialsBo();
        private ChangeStoryNotesBO changeStoryNotesBO = new ChangeStoryNotesBO();


        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            myStories = new MyStoriesPage(driver);
            storyNotes = new StoryNotesPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.wattpad.com/");
            loginPage.NavigateToLoginPage();
            loginPage.LoginApplication(loginCredentials.Username, loginCredentials.Password);
        }

        [TestMethod]
        public void ChangeStoryNotes()
        {
            homePage.NavigateToMyStoriesPage();
            myStories.NavigateToOurStory();
            storyNotes.SelectStoryNotesEdit();
            storyNotes.MakeChanges(new StoryNotesBO());
            storyNotes.ChangeRangeExtrovert();
            storyNotes.ChangeRangeUnlikable();
            storyNotes.ChangeRangeFuture();
            storyNotes.ChangeRangeUsesHeart();
            storyNotes.CheckRadioBtnAndSave();
            storyNotes.AssertChangeStoryNotesTest(changeStoryNotesBO.expectedMessage);
           
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
