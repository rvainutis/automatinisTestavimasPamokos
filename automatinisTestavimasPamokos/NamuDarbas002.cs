/*
    2021-11-07, Rimvydas Vainutis
    2 Namu darbai, 1 uzduotis (Chrome)
*/
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatinisTestavimasPamokos
{
    class NamuDarbas002
    {
        private static IWebDriver _driverChr;

        [OneTimeSetUp]

        public static void SetUp()
        {
            _driverChr = new ChromeDriver();
            _driverChr.Url = "https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent";
            _driverChr.Manage().Window.Maximize();
        }

        [OneTimeTearDown]

        public static void TearDown()
        {
            _driverChr.Quit();
        }

        [Test]

        public static void TestChrome()
        {
            string currentBrowser = "Chrome 95";
            IWebElement browserCheck = _driverChr.FindElement(By.Id("primary-detection"));

            // Nukerpame gauto Elemento atsakyma nuo pradzios iki musu tikrinamos reiksmes ilgio.
            string substring = browserCheck.Text.Substring(0, currentBrowser.Length);

            // Ir palyginame mums reikiama atsakyma su nukirptu. Jei nesutampa, graziname atsakyma.
            Assert.AreEqual(currentBrowser, substring, "Narsykle atpazinta neteisingai.");
        }
    }
}
