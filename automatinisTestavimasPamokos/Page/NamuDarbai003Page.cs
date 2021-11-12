using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatinisTestavimasPamokos.Page
{
    public class NamuDarbai003Page
    {
        private static IWebDriver _driver;

        IWebElement _checkSingleBox => _driver.FindElement(By.Id("isAgeSelected"));
        IWebElement _checkInfoText => _driver.FindElement(By.CssSelector("#txtAge"));
        //IReadOnlyCollection<IWebElement> _multipleCheckboxList => _driver.FindElements(By.CssSelector(".cb1-element"));
        //IWebElement _checkButtonName => _driver.FindElement(By.Id("check1"));

        public NamuDarbai003Page(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        //public NamuDarbai003Page(IWebDriver webDriver) : base(webDriver)
        //{ }

        public NamuDarbai003Page checkSingleBox(bool singleCheck)
        {
            if (singleCheck != _checkSingleBox.Selected)     // tikriname, ar checkbox pazymetas, jeigu pazymetas -- nespaudziame, jei nepazymetas -- spaudziame
            {
                _checkSingleBox.Click();
            }
            return this;
        }

        public NamuDarbai003Page checkInfoText(string text)
        {
            Assert.AreEqual(text, _checkInfoText.Text, "Varnele neuzdeta.");
            return this;
        }
    }
}
