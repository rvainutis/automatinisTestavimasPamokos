/*
    2021-11-07, Rimvydas Vainutis
    2 Namu darbai, 1 uzduotis (Firefox)
*/
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace automatinisTestavimasNDfirefox
{
    public class ND2firefox
    {
        private static IWebDriver _driverFF;

        [OneTimeSetUp]

        public static void SetUp2()
        {
            _driverFF = new FirefoxDriver();
            _driverFF.Url = "https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent";
            _driverFF.Manage().Window.Maximize();
        }

        [OneTimeTearDown]

        public static void TearDown2()
        {
            _driverFF.Quit();
        }

        [Test]

        public static void TestFirefox()
        {
            string currentBrowser2 = "Firefox 94";

            IWebElement browserCheck2 = _driverFF.FindElement(By.Id("primary-detection"));

            // Nukerpame gauto Elemento atsakyma nuo pradzios iki musu tikrinamos reiksmes ilgio.
            string substring2 = browserCheck2.Text.Substring(0, currentBrowser2.Length);

            // Ir palyginame mums reikiama atsakyma su nukirptu. Jei nesutampa, graziname atsakyma.
            Assert.AreEqual(currentBrowser2, substring2, "Narsykle atpazinta neteisingai.");
        }
    }
}
