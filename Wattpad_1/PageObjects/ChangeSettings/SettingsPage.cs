using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wattpad_1.PageObjects.ChangeSettings;



namespace Wattpad_1.PageObjects
{
    class SettingsPage
    {
        private IWebDriver driver;

        public SettingsPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By name => By.Id("name");
        private IWebElement TxtName => driver.FindElement(name);

        private By dateOfBirth => By.Id("birthdate");
        private IWebElement TxtBirthday => driver.FindElement(dateOfBirth);

        private By language => By.Id("language");
        private IWebElement DdlLanguage => driver.FindElement(language);

        private By appearOffline => By.Id("appearOffline");
        private IWebElement CheckBox => driver.FindElement(appearOffline);

        private By about => By.XPath("//*[@id='description']");
        private IWebElement TxtAbout => driver.FindElement(about);

        private By submit => By.XPath("//div[@class='row submit']/input[@class='btn btn-md btn-orange']");
        private IWebElement BtnSubmit => driver.FindElement(submit);

        private By assert => By.CssSelector("div[class='error-toast']");
        private IWebElement LblMessage()
        {
            return driver.FindElement(assert);
        }
        public string Message => LblMessage().Text;

        public void ChangeSettings(SettingsBO change)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(name));
            TxtName.Clear();
            TxtName.SendKeys(change.TxtName);
            TxtBirthday.SendKeys(change.TxtBirthdayMonth);
            TxtBirthday.SendKeys(Keys.Tab);
            TxtBirthday.SendKeys(change.TxtBirthdayDay);
            TxtBirthday.SendKeys(Keys.Tab);
            TxtBirthday.SendKeys(change.TxtBirthdayYear);
            var selectLanguage = new SelectElement(DdlLanguage);
            selectLanguage.SelectByText(change.TxtLanguage);
            CheckBox.Click();
            TxtAbout.SendKeys(Keys.Control + "a");
            TxtAbout.SendKeys(Keys.Backspace);
            TxtAbout.SendKeys(change.TxtAbout);
            BtnSubmit.Click();
        }


    }
}
