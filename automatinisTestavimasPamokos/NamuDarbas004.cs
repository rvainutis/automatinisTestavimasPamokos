/*
    2021-11-08, Rimvydas Vainutis
    Optional uzduotis 1
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
    class NamuDarbas004
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]

        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.active.com/fitness/calculators/pace";
            _driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]

        public static void TearDown()
        {
            _driver.Quit();
        }

        [TestCase("1", "5", "13", TestName = "Pace calculator: 5 km per min")]

        public static void TestPaceCalculator (string val, string min, string distance)
        {
            IWebElement valInput = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(2) > div > label:nth-child(1) > input[type=number]"));
            valInput.Clear();
            valInput.SendKeys(val);

            IWebElement minInput = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(2) > div > label:nth-child(2) > input[type=number]"));
            minInput.Clear();
            minInput.SendKeys(min);

            IWebElement distanceInput = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(3) > div > label > input[type=number]"));
            distanceInput.Clear();
            distanceInput.SendKeys(distance);

            IWebElement metricListOpen = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(3) > div > span > span > span.selectboxit-text"));
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => metricListOpen.Displayed);
            metricListOpen.Click();

            IWebElement metricKmSelect = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(3) > div > span > span"));
            wait.Until(d => metricKmSelect.Displayed);
            metricKmSelect.Click();

            IWebElement paceListOpen = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(4) > div > span > span"));
            wait.Until(d => paceListOpen.Displayed);
            paceListOpen.Click();

            IWebElement paceKmSelect = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(4) > div > span > span > span.selectboxit-text"));
            wait.Until(d => paceKmSelect.Displayed);
            paceKmSelect.Click();

            IWebElement calculate = _driver.FindElement(By.CssSelector("#calculator-pace > form > div:nth-child(6) > div > a"));
            calculate.Click();

            IWebElement getPaceValue = _driver.FindElement(By.XPath("/html/body/div[6]/div[5]/div[3]/div/div/div[2]/div/div/div[1]/div/form/div[4]/div/label[2]/input"));
            wait.Until(d => getPaceValue.Displayed);
            string norimasRezultatas = "05";
            Assert.AreEqual(norimasRezultatas, getPaceValue.GetAttribute("value"), "Pace nera 5 min per km");
        }
    }
}
