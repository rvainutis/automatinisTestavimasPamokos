using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace automatinisTestavimasPamokos.Page
{
    public class SkytechLoginPage : BasePage
    {
        // konstantos
        private const string PageAddress = "https://www.skytech.lt/login.php";
        private const string ManoDuomenys = "Mano duomenys";
        private const string ElPastas = "hohag62978@elastit.com";
        private const string Slaptazodis = "gediminas.testauskas123";

        //web elementai
        private IWebElement PrisijunkiteMain => Driver.FindElement(By.CssSelector("#body > div.pageouter > div.pagewrapper > div.topmenu-wrap > div > div > a.link-login"));
        private IWebElement ElPastoAdresasInput => Driver.FindElement(By.CssSelector("#checkout_login_login > div:nth-child(1) > div:nth-child(2) > input[type=text]"));
        private IWebElement SlaptazodisInput => Driver.FindElement(By.CssSelector("#checkout_login_login > div:nth-child(2) > div:nth-child(2) > input[type=password]"));
        private IWebElement PrisimintiMane => Driver.FindElement(By.CssSelector("#checkout_login_login > div:nth-child(3) > div.container > div.icon-check.remember_me"));
        private IWebElement PrisijungtiButton => Driver.FindElement(By.CssSelector("#submit-login > div > input"));
        private IWebElement ManoDuomenysCheck => Driver.FindElement(By.CssSelector("#centerpanel > div > table > tbody > tr > td.static-title > span"));
        public SkytechLoginPage(IWebDriver webDriver) : base(webDriver)
        {
            Driver.Url = PageAddress;
        }

        // veiksmai
        public SkytechLoginPage ClickLogin()
        {
            PrisijunkiteMain.Click();
            return this;
        }

        public SkytechLoginPage ClickElPastoAdresasInput()
        {
            ElPastoAdresasInput.Click();
            ElPastoAdresasInput.Clear();
            return this;
        }

        public SkytechLoginPage InputElPastoAdresasText(string elPastoAdresas)
        {
            ElPastoAdresasInput.SendKeys(elPastoAdresas);
            return this;
        }

        public SkytechLoginPage ClickSlaptazodisInput()
        {
            SlaptazodisInput.Click();
            SlaptazodisInput.Clear();
            return this;
        }

        public SkytechLoginPage InputSlaptazodisText(string slaptazodisText)
        {
            SlaptazodisInput.SendKeys(slaptazodisText);
            return this;
        }

        public SkytechLoginPage CheckmarkPrisimintiMane()
        {
            PrisimintiMane.Click();
            return this;
        }

        public SkytechLoginPage ClickPrisijungtiButton()
        {
            PrisijungtiButton.Click();
            return this;
        }

        public SkytechLoginPage ThreadSleep500()
        {
            Thread.Sleep(500);
            return this;
        }
        
        public SkytechLoginPage CheckLoginResult()
        {
            Assert.AreEqual(ManoDuomenys, ManoDuomenysCheck.Text, "Nesutampa/Neprisijunges");
            return this;
        }
    }
}
