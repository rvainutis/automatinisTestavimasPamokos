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
    public class NamuDarbai003Test
    {
        private static IWebDriver _driver;

        [OneTimeSetup]
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

        [TestCase(true, "Success - Check box is checked", TestName = "Single checkbox Demo")]

        public void TestSingleCheckboxDemo(bool singleCheck, string text)
        {
            NamuDarbai003Page page = new NamuDarbai003Page(_driver);

            page.checkSingleBox(singleCheck)
                .checkInfoText(text);
        }
    }
}
