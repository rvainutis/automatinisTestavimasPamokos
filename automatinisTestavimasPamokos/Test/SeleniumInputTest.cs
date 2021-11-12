using automatinisTestavimasPamokos.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatinisTestavimasPamokos.Test
{
    // Padaryti public, kad bendradarbiautu su Page folderiu
    public class SeleniumInputTest
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://demo.seleniumeasy.com/basic-first-form-demo.html";
            IWebElement popUp = _driver.FindElement(By.Id("at-cv-lightbox-close"));
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => popUp.Displayed);
            popUp.Click();
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }

        [Test]

        public void TestSeleniumInputFirstBlock()
        {
            SeleniumInputPage page = new SeleniumInputPage(_driver);

            string myTextA = "2";
            string myTextB = "2";
            string resultAB = "4";

            page.InsertTextA(myTextA);
            page.InsertTextB(myTextB);
            page.ClickShowMessageButton();
            page.CheckResult(resultAB);
        }
    }
}
