using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private By EditProfileButton => By.XPath("//*[@id='page-navigation']/div[2]/div/div/button");
        //*[@id='page-navigation']/div[2]/div/div/button

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

        private By EditLocationInput => By.Id("update-location");
        private IWebElement InputLocation()
        {
            return driver.FindElement(EditLocationInput);
        }
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

        private By ProfileLocation => By.XPath("//*[@id='profile-about']/div/div/ul/li[1]/span");
        private IWebElement LblProfileLocation()
        {
            return driver.FindElement(ProfileLocation);
        }
        public string UserProfileLocation => LblProfileLocation().Text;
    }
}
