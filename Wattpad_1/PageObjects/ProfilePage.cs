using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Wattpad_1.PageObjects
{
    class ProfilePage
    {
        private IWebDriver driver;

        public ProfilePage(IWebDriver browser)
        {
            driver = browser;
        }
        private By KeepTrack => By.XPath("//*[@id='component-walletwithonboarding-profile-/user/stefana_qa']/div/div[2]/div/button");

        private IWebElement BtnGotIt()
        {
            return driver.FindElement(KeepTrack);
        }
        public void ClickKeepTrackButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(KeepTrack));
            BtnGotIt().Click();
        }

        //
        private By EditProfile => By.XPath("//*[@id='page-navigation']/div[2]/div/div/button");
        private IWebElement EditProfileButton()
        {
            return driver.FindElement(EditProfile);
        }

        public void ClickEditButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(EditProfile));
            EditProfileButton().Click();

        }
        //
        private By EditLocation => By.Id("update-location");
        private IWebElement EditLocationInput()
        {
            return driver.FindElement(EditLocation);
        }
        //
        private By SaveChanges => By.CssSelector("button[class='btn btn-orange on-edit-save']");
        private IWebElement SaveChangesButton()
        {
            return driver.FindElement(SaveChanges);
        }
        public void ClickAndWriteLocationInput(string location)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(driver => driver.FindElement(SaveChanges));
            EditLocationInput().Clear();
            EditLocationInput().SendKeys(location);
            SaveChangesButton().Click();
        }
        //
        private By ProfileLocation => By.XPath("//*[@id='profile-about']/div/div/ul/li[1]/span");
        private IWebElement ProfileLocationLbl()
        {
            return driver.FindElement(ProfileLocation);
        }
        public string UserProfileLocation => ProfileLocationLbl().Text;
        public void AssertChangeProfileLocation(string expectedResult)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementExists(ProfileLocation));
            Assert.AreEqual(expectedResult, UserProfileLocation);
        }
        //

        private By Conversations => By.XPath("//*[@id='page-navigation']/div[2]/div/nav/ul/li[2]/a");

        private IWebElement ConversationsButton()
        {
            return driver.FindElement(Conversations);
        }
        public void ClickConversationsButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementToBeClickable(Conversations));
            ConversationsButton().Click();
        }
        //
        private By postMessage => By.XPath("//*[@id='broadcast-container']/div[2]/textarea");
        private IWebElement PostMessageInput()
        {
            return driver.FindElement(postMessage);
        }
        private By postMessageActive => By.CssSelector("textarea[class='form-control count-input new-textarea active']");
        private IWebElement PostMessageActiveInput()
        {
            return driver.FindElement(postMessageActive);
        }
        private By AnnounceToFollowers => By.XPath("//*[@id='broadcast-container']/div[2]/div[2]/div/input");
        private IWebElement AnnounceCheckbox()
        {
            return driver.FindElement(AnnounceToFollowers);
        }
        private By GotIt => By.XPath("//*[@id='component-announcementmodal-announcement-modal-/user/stefana_qa/conversations']/div/div[2]/button");
        private IWebElement GotItButton()
        {
            return driver.FindElement(GotIt);
        }
        private By Announce => By.XPath("//*[@id='broadcast-submit']");
        private IWebElement AnnounceButton()
        {
            return driver.FindElement(Announce);
        }
        public void ClickWritePostMessage()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(driver => driver.FindElement(postMessage));
            PostMessageInput().Click();
            System.Threading.Thread.Sleep(100);
        }
        public void WritePostMessage(string post)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementExists(postMessageActive));
            PostMessageActiveInput().SendKeys(post);
            System.Threading.Thread.Sleep(100);
        }
        public void ClickPostCheckbox()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(driver => driver.FindElement(postMessageActive));
            AnnounceCheckbox().Click();
            System.Threading.Thread.Sleep(150);

        }
        public void ClickGotItButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(driver => driver.FindElement(GotIt));
            GotItButton().Click();
        }

        public void ClickAnnounceButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(GotIt));
            AnnounceButton().Click();
            System.Threading.Thread.Sleep(500);

        }

    //
    private By TextMessage => By.XPath("//section[@id='profile-messages']//article[@class='feed-item-new panel pinned-item']//pre[.='Automation testing is the best']");
        private IWebElement TextMessagePre()
        {
            return driver.FindElement(TextMessage);
        }
        public string ConversationMessage => TextMessagePre().Text;

        public void AssertPostNewConversationTest(string expectedResult)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementExists(TextMessage));
            Assert.AreEqual(expectedResult, ConversationMessage);
        }
        //
        private By PinnedMessage => By.XPath("//*[@id='profile-messages']/div/article");
        private IWebElement PinnedMessagePost()
        {
            return driver.FindElement(PinnedMessage);
        }
        public string PostPinned => PinnedMessagePost().Text;

        private By MessageDropdown => By.XPath("//section[@id='profile-messages']//article[@class='feed-item-new panel pinned-item']//div[@class='button-group dropdown']/button/span");
        private By PinnedPost => By.XPath("//section[@id='profile-messages']//article[@class='feed-item-new panel pinned-item']/div[2]");
        private IWebElement MessageDropdownButton()
        {
            return driver.FindElement(MessageDropdown);
        }
        public void ClickMessageDropdownButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementExists(PinnedPost));
            MessageDropdownButton().Click();
        }

        private By MessageDelete => By.CssSelector("a[data-action='deleteMessage']");
        private IWebElement MessageDeleteButton()
        {
            return driver.FindElement(MessageDelete);
        }
        public void ClickMessageDeleteButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(MessageDelete));
            MessageDeleteButton().Click();
            driver.SwitchTo().Alert().Accept();
        }
    }
}
