using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatinisTestavimasPamokos.Page
{
    public class AlertPage : BasePage
    {
        private const string PageAddress = "https://demo.seleniumeasy.com/javascript-alert-box-demo.html";
        private IWebElement AlertButton => Driver.FindElement(By.XPath("//button[@onclick='myAlertFunction()']"));
        private IWebElement ConfirmationAlertButton => Driver.FindElement(By.XPath("//button[@onclick='myConfirmFunction()']"));
        private IWebElement ClickMeButton => Driver.FindElement(By.XPath("//button[@onclick='myPromptFunction()']"));

        public AlertPage(IWebDriver webDriver) : base(webDriver)
        { }
        public AlertPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public AlertPage ClickAlertButton()
        {
            AlertButton.Click();
            return this;
        }
        public AlertPage AcceptAlert()
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.Accept();
            return this;
        }
        public AlertPage ClickConfirmationAlertButton()
        {
            ConfirmationAlertButton.Click();
            return this;
        }
        public AlertPage ClickClickMeButton()
        {
            ClickMeButton.Click();
            return this;
        }
    }
}
