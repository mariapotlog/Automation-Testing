using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Wattpad_1.PageObjects;

namespace Wattpad_1
{
    [TestClass]
    public class AddStoryTest
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private HomePage homePage;
        private StoryPage storyPage;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            storyPage = new StoryPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.wattpad.com/");
            loginPage.NavigateToLoginPage();
        }

        [TestMethod]
        public void Add_Story()
        {
            loginPage.LoginApplication("stefanatoma98@gmail.com", "testareautomata");
            homePage.ClickWriteDropdown();
            homePage.ClickCreateStoryBtn();
            storyPage.WriteMainCharacter("Magnus");
            storyPage.WriteTag("Adventure");
            storyPage.SetTargetAudience("Young Adult (13-18 years of age)");
            storyPage.SetLanguage("English");
            storyPage.SetCopyright("Public Domain");
            storyPage.ClickRatingButton();
            storyPage.ClickNextButton();
            storyPage.WriteFinalStoryBody("Hop into an adventure with Magnus, future Lord of the Mountain.");
            storyPage.WriteFinalStoryTitle("A book for adventurers");
            storyPage.ClickPublishButton();
            storyPage.SetGenre("Adventure");
            storyPage.WriteStoryTitle("The Lord Of the Mountain");
            storyPage.WriteDescription("The book is about a courageous lord who wanted to conquer the high mountains of Zeeya");
            storyPage.ClickPublishModalButton();

            storyPage.AssertAddStoryTest();
        }

        [TestCleanup]
        public void CleanUp()
        {
            storyPage.ClickFinishModalCloseButton();
            homePage.ClickWriteDropdown();
            storyPage.ClickMyStoriesButton();
            storyPage.ClickStoryDropdownButton();
            storyPage.ClickDeleteStoryButton();
            storyPage.ClickPopupDeleteButton();
            storyPage.ClickPopupDeleteConfirmatioButton();
            driver.Quit();
        }
    }
}
