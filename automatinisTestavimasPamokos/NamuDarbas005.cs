/*
    2021-11-08, Rimvydas Vainutis
    Optional uzduotis 2
*/
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace automatinisTestavimasPamokos
{
    class NamuDarbas005
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]

        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.seb.lt/privatiems/kreditai/busto-kreditas#1";
            _driver.Manage().Window.Maximize();
            _driver.SwitchTo().Frame(0);
        }

        [OneTimeTearDown]

        public static void TearDown()
        {
            _driver.Quit();
        }

        [TestCase(false)]

        public static void TestSebLoan(bool check)
        {
            string incomeNetto = "1000";
            int loanNeeded = 75000;

            IWebElement income = _driver.FindElement(By.Id("income"));
            income.Click();
            income.Clear();
            income.SendKeys(incomeNetto);

            IWebElement city = _driver.FindElement(By.Id("city"));
            city.Click();

            IWebElement cityList = _driver.FindElement(By.Id("city"));
            cityList.FindElement(By.XPath("//option[. = 'Klaipėda']")).Click();

            IWebElement calculate = _driver.FindElement(By.CssSelector("#calculate > .ng-binding"));
            calculate.Click();

            IWebElement answer = _driver.FindElement(By.XPath("/html/body/div/form[2]/div[2]/div/div[5]/div/span/strong"));
            string answerNoSpace = Regex.Replace(answer.Text, " ", "");
            int answerInt = Convert.ToInt32(answerNoSpace);

            if (answerInt <= loanNeeded)
            {
                Assert.IsTrue(check, "Paskolos negali gauti.");
            }            
        }
    }
}