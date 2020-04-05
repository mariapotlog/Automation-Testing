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
        private By KeepTrackTooltip => By.XPath("//*[@id='component-walletwithonboarding-profile-/user/stefana_qa']/div/div[2]/div/button");
        
        private IWebElement BtnGotIt()
        {
            return driver.FindElement(KeepTrackTooltip);
        }
        public void ClickKeepTrackButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.FindElement(KeepTrackTooltip));
            BtnGotIt().Click();

        }

        //
        private By EditProfileButton => By.XPath("//*[@id='page-navigation']/div[2]/div/div/button");
        private IWebElement BtnEditButton()
        {
            return driver.FindElement(EditProfileButton);
        }

        public void ClickEditButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.FindElement(EditProfileButton));
            BtnEditButton().Click();

        }
        //
        private By EditLocationInput => By.Id("update-location");
        private IWebElement InputLocation()
        {
            return driver.FindElement(EditLocationInput);
        }
        //
        private By SaveChangesButton => By.CssSelector("button[class='btn btn-orange on-edit-save']");
        private IWebElement ClickSaveChangesButton()
        {
            return driver.FindElement(SaveChangesButton);
        }
        public void ChangeLocation(string location)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(driver => driver.FindElement(EditProfileButton));
            InputLocation().Clear();
            InputLocation().SendKeys(location);
            ClickSaveChangesButton().Click();
        }
        //
        private By ProfileLocation => By.XPath("//*[@id='profile-about']/div/div/ul/li[1]/span");
        private IWebElement LblProfileLocation()
        {
            return driver.FindElement(ProfileLocation);
        }
        public string UserProfileLocation => LblProfileLocation().Text;
        //

        private By Conversations => By.XPath("//*[@id='page-navigation']/div[2]/div/nav/ul/li[2]/a");

        private IWebElement btnConversations()
        {
            return driver.FindElement(Conversations);
        }
        public void ClickConversationsButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(driver => driver.FindElement(EditProfileButton));
            btnConversations().Click();
        }
        //
        private By postMessage => By.XPath("//*[@id='broadcast-container']/div[2]/textarea");
        private IWebElement inputPostMessage()
        {
            return driver.FindElement(postMessage);
        }
        private By postMessageActive => By.CssSelector("textarea[class='form-control count-input new-textarea active']");
        private IWebElement inputPostMessageActive()
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
            inputPostMessage().Click();
            System.Threading.Thread.Sleep(100);
        }
        public void WritePostMessage(string post)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementExists(postMessageActive));
            inputPostMessageActive().SendKeys(post);
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
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(driver => driver.FindElement(GotIt));
            AnnounceButton().Click();
            System.Threading.Thread.Sleep(500);

        }

        private By PostTime => By.CssSelector("time[class='timestamp']");
        private IWebElement PostTimer()
        {
            return driver.FindElement(PostTime);
        }
        public string PostAddedTime => PostTimer().Text;
        //
        private By Pinned => By.XPath("//*[@id='profile-messages']/div/article");
        private IWebElement PinnedPost()
        {
            return driver.FindElement(Pinned);
        }
        public string PostPinned => PinnedPost().Text;
    }
}
