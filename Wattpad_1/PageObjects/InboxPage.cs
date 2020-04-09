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
    class InboxPage
    {
        private IWebDriver driver;

        public InboxPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By NewMessage => By.XPath("//*[@id='inbox']/div/div[1]/button");

        private IWebElement NewMessageButton()
        {
            return driver.FindElement(NewMessage);
        }
        public void ClickNewMessageButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementToBeClickable(NewMessage));
            NewMessageButton().Click();
        }

        //
        private By Receiver => By.XPath("//div[@id='inbox']/div[@class='threads-container']/div[@class='threads-header']/div[3]//input");

        private IWebElement ReceiverInput()
        {
            return driver.FindElement(Receiver);
        }
        public void WriteReceiverInput(string receiver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(Receiver));
            ReceiverInput().SendKeys(receiver);
            ReceiverInput().SendKeys(Keys.Space);
            ReceiverInput().SendKeys(Keys.Space);
        }
        //
        private By Person => By.XPath("//div[@id='inbox']/div[@class='threads-container']/div[@class='threads-header']/div[3]//p[.='AutomationTesting4']");

        private IWebElement PersonInput()
        {
            return driver.FindElement(Person);
        }
        public void ClickPersonInput()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(Person));
            PersonInput().Click();
        }
        //

        private By Chat => By.XPath("//div[@id='inbox']/div[@class='conversation-container']//form//textarea[@placeholder='Write a message...']");

        private IWebElement ChatTextarea()
        {
            return driver.FindElement(Chat);
        }
        public void WriteChatTextarea(string message)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(Chat));
            ChatTextarea().SendKeys(message);
        }
        //div[@id='inbox']/div[@class='conversation-container']//form//button[@type='submit']

        private By Send => By.XPath("//div[@id='inbox']/div[@class='conversation-container']//form//button[@type='submit']");
        private IWebElement SendButton()
        {
            return driver.FindElement(Send);
        }
        public void ClickSendButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(Send));
            SendButton().Click();
        }

        //div[@id='inbox']/div[@class='conversation-container']/div[@class='column main']//span[.='asdas']

        private By Message => By.XPath("//*[@id='inbox']/div/div[2]/div[2]/div[2]/div/span");
        //*[@id="inbox"]/div/div[2]/div[2]/div[2]/div/span
        private IWebElement ChatMessageSpan => driver.FindElement(Message);

        public string ChatMessage => ChatMessageSpan.Text;

        public void AssertWriteMessageTest()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(Message));
            string expectedResult = "hello";
            Assert.AreEqual(expectedResult, ChatMessage);
        }

        //

        private By Delete => By.XPath("//div[@id='inbox']/div[@class='conversation-container']/div[3]//div[@class='user-safety-operations']/button[2]");
        private IWebElement DeleteButton()
        {
            return driver.FindElement(Delete);
        }
        public void ClickDeleteButton()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(Delete));
            DeleteButton().Click();
            driver.SwitchTo().Alert().Accept();
        }
    }
}
