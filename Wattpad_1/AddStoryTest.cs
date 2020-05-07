using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Wattpad_1.PageObjects;
using Wattpad_1.PageObjects.TestsBO;

namespace Wattpad_1
{
    [TestClass]
    public class AddStoryTest
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private HomePage homePage;
        private StoryPage storyPage;
        private LoginCredentialsBo loginCredentials = new LoginCredentialsBo();
        private AddStoryTestBO addStoryTestBo = new AddStoryTestBO();

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
            loginPage.LoginApplication(loginCredentials.Username, loginCredentials.Password);
        }

        [TestMethod]
        public void Add_Story()
        {
            homePage.ClickWriteDropdown();
            homePage.ClickCreateStoryBtn();
            storyPage.WriteMainCharacter(addStoryTestBo.mainCharacter);
            storyPage.WriteTag(addStoryTestBo.tag);
            storyPage.SetTargetAudience(addStoryTestBo.setTargetAudience);
            storyPage.SetLanguage(addStoryTestBo.language);
            storyPage.SetCopyright(addStoryTestBo.copyRight);
            storyPage.ClickRatingButton();
            storyPage.ClickNextButton();
            storyPage.WriteFinalStoryBody(addStoryTestBo.finalStoryBody);
            storyPage.WriteFinalStoryTitle(addStoryTestBo.finalStoryTitle);
            storyPage.ClickPublishButton();
            storyPage.SetGenre(addStoryTestBo.genre);
            storyPage.WriteStoryTitle(addStoryTestBo.storyTitle);
            storyPage.WriteDescription(addStoryTestBo.storyDescription);
            storyPage.ClickOriginalWorkCheckBox();
            storyPage.ClickPublishModalButton();

            storyPage.AssertAddStoryTest(addStoryTestBo.assertMessage);
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
