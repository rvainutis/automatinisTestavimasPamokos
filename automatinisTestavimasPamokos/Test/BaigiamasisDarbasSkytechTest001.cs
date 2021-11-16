using automatinisTestavimasPamokos.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatinisTestavimasPamokos.Test
{
    public class SkytechLoginTest
    {
        private static SkytechLoginPage _page;

        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _page = new SkytechLoginPage(driver);
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _page.CloseBrowser();
        }
        
        [TestCase("hohag62978@elastit.com", "gediminas.testauskas123", TestName = "01 Skytech Login Test")]
        public void TestLogin(string elPastoAdresas, string slaptazodisText)
        {
            _page.ClickLogin()
                .ClickElPastoAdresasLoginInput()
                .InputElPastoAdresasLoginText(elPastoAdresas)
                .ThreadSleep500()
                .ClickSlaptazodisLoginInput()
                .InputSlaptazodisLoginText(slaptazodisText)
                .ThreadSleep500()
                .CheckmarkPrisimintiManeLogin()
                .ThreadSleep500()
                .ClickPrisijungtiButtonLogin()
                .CheckLoginResult();
        }

        [TestCase("vardas", "pavarde", "telefono_nr", "el_pastas", "slaptazodis", "slaptazodis_kartoti", TestName = "02 Skytech Register Test")]
        public void TestRegister(string vardas, string pavarde, string telNr, string elPastas, string slaptazodis, string slaptazodisKartoti)
        {
            _page.ClickRegister()
                .ClickVardasRegisterInput()
                .InputVardasTextRegister(vardas)
                .ThreadSleep500()
                .ClickPavardeRegisterInput()
                .InputPavardeTextRegister(pavarde)
                .ThreadSleep500()
                .ClickTelNrRegisterInput()
                .InputTelNrTextRegister(telNr)
                .ThreadSleep500()
                .ClickElPastasRegisterInput()
                .InputElPastasTextRegister(elPastas)
                .ThreadSleep500()
                .ClickSlaptazodisRegisterInput()
                .InputSlaptazodisTextRegister(slaptazodis)
                .ThreadSleep500()
                .
        }
    }
}