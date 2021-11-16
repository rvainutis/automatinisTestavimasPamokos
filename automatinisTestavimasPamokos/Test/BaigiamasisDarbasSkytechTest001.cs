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
                .ClickElPastoAdresasInput()
                .InputElPastoAdresasText(elPastoAdresas)
                .ThreadSleep500()
                .ClickSlaptazodisInput()
                .InputSlaptazodisText(slaptazodisText)
                .ThreadSleep500()
                .CheckmarkPrisimintiMane()
                .ThreadSleep500()
                .ClickPrisijungtiButton()
                .CheckLoginResult();
        }
    }
}