/*
    2021-11-04, Rimvydas Vainutis, Namu darbas 001
*/

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace automatinisTestavimasPamokos
{
    class NamuDarbas001
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

        [TestCase("2", "2", "4", TestName = "2 + 2 = 4")]

        // 001 Testas: 2 + 2
        [Test]
        public static void TestTwoInputFields(string a, string b, string sumAB)
        {
            //Randame laukeli, kuriam paduosime "a" reiksme:
            IWebElement inputA = _driver.FindElement(By.Id("sum1"));

            //"a" laukeliui duodame reiksme:
            inputA.Clear();
            inputA.SendKeys(a);

            //Randame laukeli, kuriam paduosime "b" reiksme:
            IWebElement inputB = _driver.FindElement(By.Id("sum2"));

            //"b" laukeliui duodame reiksme:
            inputB.Clear();
            inputB.SendKeys(b);

            //Randame "Get Total" mygtuka ir ji paspaudziame:
            IWebElement buttonGetTotal = _driver.FindElement(By.CssSelector("#gettotal > button"));
            buttonGetTotal.Click();

            //Randame laukeli, kuris parodo atsakyma ir ji patikriname:
            IWebElement atsakymas = _driver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual(sumAB, atsakymas.Text, $"{a} + {b} nera lygu {sumAB}.");                        
        }

        [TestCase("-5", "3", "-2", TestName = "-5 + 3 = -2")]
        // 002 Testas: -5 + 2
        [Test]
        public static void TestTwoInputFields2(string a, string b, string sumAB)
        {
            IWebElement inputA = _driver.FindElement(By.Id("sum1"));

            inputA.Clear();
            inputA.SendKeys(a);
                        
            IWebElement inputB = _driver.FindElement(By.Id("sum2"));
            
            inputB.Clear();
            inputB.SendKeys(b);
            
            IWebElement buttonGetTotal = _driver.FindElement(By.CssSelector("#gettotal > button"));
            buttonGetTotal.Click();

            IWebElement atsakymas = _driver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual(sumAB, atsakymas.Text, $"{a} + {b} nera lygu {sumAB}.");
        }

        [TestCase("a", "b", "NaN", TestName = "a + b = NaN")]
        // 003 Testas: a + b
        [Test]
        public static void TestTwoInputFields3(string a, string b, string sumAB)
        {   
            IWebElement inputA = _driver.FindElement(By.Id("sum1"));

            inputA.Clear();
            inputA.SendKeys(a);

            IWebElement inputB = _driver.FindElement(By.Id("sum2"));

            inputB.Clear();
            inputB.SendKeys(b);

            IWebElement buttonGetTotal = _driver.FindElement(By.CssSelector("#gettotal > button"));
            buttonGetTotal.Click();

            IWebElement atsakymas = _driver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual(sumAB, atsakymas.Text, $"{a} + {b} nera lygu {sumAB}.");
        }
    }
}
