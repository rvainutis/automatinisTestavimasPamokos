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
    public class nd03Test
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
        public void TestSingleCheckboxDemo(bool singleCheck)
        {
            nd03Page page = new nd03Page(_driver);
            page.checkSingleBox(singleCheck);
            page.checkInfoText();
        }

        [Test]
        public void TestMultipleCheckboxDemo()
        {
            nd03Page page = new nd03Page(_driver);
            page.checkAllCheckboxes();
            page.checkButtonName();
            page.pressButton();
            page.checkIfCheckboxesUnselected();
        }
    }
}
