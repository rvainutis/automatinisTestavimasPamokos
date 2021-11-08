/*
    2021-11-07, Rimvydas Vainutis
    2 Namu darbai, 2 uzduotis
*/
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
    class NamuDarbas003
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]

        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://demo.seleniumeasy.com/basic-checkbox-demo.html";
            _driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]

        public static void TearDown()
        {
            _driver.Quit();
        }

        [TestCase(true)]

        public static void TestSingleCheckboxDemo(bool singleCheck)
        {
            IWebElement checkSingleBox = _driver.FindElement(By.Id("isAgeSelected"));

            if (singleCheck != checkSingleBox.Selected)     // tikriname, ar checkbox pazymetas, jeigu pazymetas -- nespaudziame, jei nepazymetas -- spaudziame
            {
                checkSingleBox.Click();
            }

            string answer = "Success - Check box is checked";
            IWebElement checkInfoText = _driver.FindElement(By.CssSelector("#txtAge"));
            Assert.AreEqual(answer, checkInfoText.Text, "Varnele neuzdeta.");
        }

        [Test]

        public static void TestMultipleCheckboxDemo()
        {
            IReadOnlyCollection<IWebElement> multipleCheckboxList = _driver.FindElements(By.CssSelector(".cb1-element"));

            foreach (IWebElement element in multipleCheckboxList)
            {
                element.Click();
            }
            
            IWebElement checkButtonName = _driver.FindElement(By.Id("check1"));
            string text = "Uncheck All";
            Assert.AreEqual(text, checkButtonName.GetAttribute("value"), "Mygtukas nerodo Uncheck All");

            checkButtonName.Click();

            foreach (IWebElement element in multipleCheckboxList)
            {
                Assert.IsTrue(!element.Selected);
            }
        }
    }
}
