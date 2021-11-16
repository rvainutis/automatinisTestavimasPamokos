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
        //private const string ElPastas = "hohag62978@elastit.com";
        //private const string Slaptazodis = "gediminas.testauskas123";

        // web elementai
        
        // esamas vartotojas
        
        private IWebElement PrisijunkiteMain => Driver.FindElement(By.CssSelector("#body > div.pageouter > div.pagewrapper > div.topmenu-wrap > div > div > a.link-login"));
        private IWebElement ElPastoAdresasLoginInput => Driver.FindElement(By.CssSelector("#checkout_login_login > div:nth-child(1) > div:nth-child(2) > input[type=text]"));
        private IWebElement SlaptazodisLoginInput => Driver.FindElement(By.CssSelector("#checkout_login_login > div:nth-child(2) > div:nth-child(2) > input[type=password]"));
        private IWebElement PrisimintiMane => Driver.FindElement(By.CssSelector("#checkout_login_login > div:nth-child(3) > div.container > div.icon-check.remember_me"));
        private IWebElement PrisijungtiButton => Driver.FindElement(By.CssSelector("#submit-login > div > input"));
        private IWebElement ManoDuomenysCheck => Driver.FindElement(By.CssSelector("#centerpanel > div > table > tbody > tr > td.static-title > span"));

        // naujas vartotojas

        private IWebElement UzsiregistruotiButton => Driver.FindElement(By.CssSelector("#body > div.pageouter > div.pagewrapper > div.topmenu-wrap > div > div > a.link-register"));
        private IWebElement VardasRegisterInput => Driver.FindElement(By.CssSelector("#checkout_login_register > div:nth-child(1) > div:nth-child(2) > input[type=text]"));
        private IWebElement PavardeRegisterInput => Driver.FindElement(By.CssSelector("#checkout_login_register > div:nth-child(2) > div:nth-child(2) > input[type=text]"));
        private IWebElement TelNrRegisterInput => Driver.FindElement(By.CssSelector("#checkout_login_register > div:nth-child(3) > div:nth-child(2) > input[type=text]"));
        private IWebElement ElPastoAdresasRegisterInput => Driver.FindElement(By.CssSelector("#checkout_login_register > div:nth-child(1) > div:nth-child(2) > input[type=text]"));
        private IWebElement SlaptazodisRegisterInput => Driver.FindElement(By.CssSelector("#checkout_login_register > div:nth-child(5) > div:nth-child(2) > input[type=password]"));
        private IWebElement SlaptazodisKartotiRegisterInput => Driver.FindElement(By.CssSelector("#checkout_login_register > div:nth-child(6) > div:nth-child(2) > input[type=password]"));
        private IWebElement CheckTaisyklesRegister => Driver.FindElement(By.CssSelector("#checkout_login_register > div:nth-child(7) > div:nth-child(1) > input[type=checkbox]"));
        private IWebElement CheckPrivatumasRegister => Driver.FindElement(By.CssSelector("#checkout_login_register > div:nth-child(8) > div:nth-child(1) > input[type=checkbox]"));
        private IWebElement CheckNaujienosRegister => Driver.FindElement(By.CssSelector("#checkout_login_register > div:nth-child(9) > div > input[type=checkbox]"));

        public SkytechLoginPage(IWebDriver webDriver) : base(webDriver)
        {
            Driver.Url = PageAddress;
        }

        // bendri

        public SkytechLoginPage ClickLogin()
        {
            PrisijunkiteMain.Click();
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

        // veiksmai
        // esamas vartotojas

        public SkytechLoginPage ClickElPastoAdresasLoginInput()
        {
            ElPastoAdresasLoginInput.Click();
            ElPastoAdresasLoginInput.Clear();
            return this;
        }

        public SkytechLoginPage InputElPastoAdresasLoginText(string elPastoAdresas)
        {
            ElPastoAdresasLoginInput.SendKeys(elPastoAdresas);
            return this;
        }

        public SkytechLoginPage ClickSlaptazodisLoginInput()
        {
            SlaptazodisLoginInput.Click();
            SlaptazodisLoginInput.Clear();
            return this;
        }

        public SkytechLoginPage InputSlaptazodisLoginText(string slaptazodisText)
        {
            SlaptazodisLoginInput.SendKeys(slaptazodisText);
            return this;
        }

        public SkytechLoginPage CheckmarkPrisimintiManeLogin()
        {
            PrisimintiMane.Click();
            return this;
        }

        public SkytechLoginPage ClickPrisijungtiButtonLogin()
        {
            PrisijungtiButton.Click();
            return this;
        }

        // naujas vartotojas

        public SkytechLoginPage ClickRegister()
        {
            UzsiregistruotiButton.Click();
            return this;
        }

        public SkytechLoginPage ClickVardasRegisterInput()
        {
            VardasRegisterInput.Click();
            VardasRegisterInput.Clear();            
            return this;
        }
        
        public SkytechLoginPage InputVardasTextRegister(string vardas)
        {
            VardasRegisterInput.SendKeys(vardas);
            return this;
        }

        public SkytechLoginPage ClickPavardeRegisterInput()
        {
            PavardeRegisterInput.Click();
            PavardeRegisterInput.Clear();
            return this;
        }

        public SkytechLoginPage InputPavardeTextRegister(string pavarde)
        {
            PavardeRegisterInput.SendKeys(pavarde);
            return this;
        }

        public SkytechLoginPage ClickTelNrRegisterInput()
        {
            TelNrRegisterInput.Click();
            TelNrRegisterInput.Clear();
            return this;
        }

        public SkytechLoginPage InputTelNrTextRegister(string telNr)
        {
            TelNrRegisterInput.SendKeys(telNr);
            return this;
        }

        public SkytechLoginPage ClickElPastasRegisterInput()
        {
            ElPastoAdresasRegisterInput.Click();
            ElPastoAdresasRegisterInput.Clear();
            return this;
        }

        public SkytechLoginPage InputElPastasTextRegister(string elPastas)
        {
            ElPastoAdresasRegisterInput.SendKeys(elPastas);
            return this;
        }

        public SkytechLoginPage ClickSlaptazodisRegisterInput()
        {
            SlaptazodisRegisterInput.Click();
            SlaptazodisRegisterInput.Clear();
            return this;
        }

        public SkytechLoginPage InputSlaptazodisTextRegister(string slaptazodis)
        {
            SlaptazodisRegisterInput.SendKeys(slaptazodis);
            return this;
        }
    }
}
