using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatinisTestavimasPamokos.Page
{
    public class nd03Page
    {
        private static IWebDriver _driver;

        private IWebElement _checkSingleBox => _driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement _checkInfoText => _driver.FindElement(By.CssSelector("#txtAge"));
        private IReadOnlyCollection<IWebElement> _multipleCheckboxList => _driver.FindElements(By.CssSelector(".cb1-element"));
        private IWebElement _checkButtonName => _driver.FindElement(By.Id("check1"));

        public nd03Page(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        public void checkSingleBox (bool singleCheck)
        {
            if (singleCheck != _checkSingleBox.Selected)     // tikriname, ar checkbox pazymetas, jeigu pazymetas -- nespaudziame, jei nepazymetas -- spaudziame
            {
                _checkSingleBox.Click();
            }
        }

        public void checkInfoText()
        {
            string answer = "Success - Check box is checked";
            Assert.AreEqual(answer, _checkInfoText.Text, "Varnele neuzdeta.");
        }

        public void checkAllCheckboxes()
        {
            foreach (IWebElement element in _multipleCheckboxList)
            {
                element.Click();
            }
        }

        public void checkButtonName()
        {
            string text = "Uncheck All";
            Assert.AreEqual(text, _checkButtonName.GetAttribute("value"), "Mygtukas nerodo Uncheck All");
        }

        public void pressButton()
        {
            _checkButtonName.Click();
        }

        public void checkIfCheckboxesUnselected()
        {
            foreach (IWebElement element in _multipleCheckboxList)
            {
                Assert.IsTrue(!element.Selected);
            }
        }

    }
}
