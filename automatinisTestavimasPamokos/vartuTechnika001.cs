using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatinisTestavimasPamokos
{
    class vartuTechnika001
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://vartutechnika.lt");
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _driver.Manage().Window.Maximize();
            _driver.FindElement(By.Id("cookiescript_reject")).Click();
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }

        [TestCase("2000", "2000", true, false, "665.98€", TestName ="2000x2000 + Vartu automatika = 665.98€")]
        public static void TestVartuTechnikaPage(string width, string height, bool automatika, bool montavimoDarbai, string result)
        {
            IWebElement widthInput = _driver.FindElement(By.Id("doors_width"));
            widthInput.Clear();
            widthInput.SendKeys(width);

            IWebElement heightInput = _driver.FindElement(By.Id("doors_height"));
            heightInput.Clear();
            heightInput.SendKeys(height);

            IWebElement automatikaCheck = _driver.FindElement(By.Id("automatika"));

            if (automatika != automatikaCheck.Selected)     // tikriname, ar checkbox pazymetas, jeigu pazymetas -- nespaudziame, jei nepazymetas -- spaudziame
            {
                automatikaCheck.Click();
            }

            IWebElement montavimoDarbaiCheck = _driver.FindElement(By.Id("darbai"));
            
            if (montavimoDarbai != montavimoDarbaiCheck.Selected)
            {
                montavimoDarbaiCheck.Click();
            }
        }
    }
}