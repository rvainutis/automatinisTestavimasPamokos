using automatinisTestavimasPamokos.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testavimo_kursai_2021.Page
{
    public class Open24LoginPage : BasePage
    {
        public const string PageAddressOpenLogin = "https://www.open24.lt/lt/mano-duomenys/mano-uzsakymai/";
        public Open24LoginPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddressOpenLogin;
        }
        private IWebElement UserEmail => Driver.FindElement(By.Id("login_email"));
        private IWebElement UserPassword => Driver.FindElement(By.Id("login_password"));
        private IWebElement LogInButton => Driver.FindElement(By.CssSelector("#login_form > button"));
        private IWebElement LogInResult => Driver.FindElement(By.CssSelector("#content_layout_plain > div.tab_navs > ul > li.active > a"));
        private IWebElement LoyaltyButton => Driver.FindElement(By.CssSelector("#content_layout_plain > div.tab_navs > ul > li:nth-child(3) > a"));
        private IWebElement LoyaltyButtonResult => Driver.FindElement(By.CssSelector("#loyalty_points_history > div > h2"));
        public void InsertEmail(string text)
        {
            UserEmail.Clear();
            UserEmail.SendKeys(text);
        }
        public void InsertPassword(string text)
        {
            UserPassword.Clear();
            UserPassword.SendKeys(text);
        }
        public Open24LoginPage InsertEmailAndPassword(string email, string password)
        {
            InsertEmail(email);
            InsertPassword(password);
            return this;
        }
        public Open24LoginPage ClickLogInButton()
        {
            LogInButton.Click();
            return this;
        }
        public Open24LoginPage CheckLogInResult(string expectedResultLogIn)
        {
            Assert.AreEqual(expectedResultLogIn, LogInResult.Text, "Log in failed");
            return this;
        }
        public Open24LoginPage LoyaltyButtonClick()
        {
            LoyaltyButton.Click();
            return this;
        }
        public Open24LoginPage CheckLoyaltyButtonResult(string expectedResultLoyalty)
        {
            Assert.AreEqual(expectedResultLoyalty, LoyaltyButtonResult.Text, "Not the loyalty page result");
            return this;
        }

    }
}