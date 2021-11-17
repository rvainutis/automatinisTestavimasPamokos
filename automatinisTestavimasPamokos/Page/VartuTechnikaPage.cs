using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatinisTestavimasPamokos.Page
{
    public class VartuTechnikaPage : BasePage
    {
        private const string PageAddress = "http://vartutechnika.lt/";
        private IWebElement _widthInput => Driver.FindElement(By.Id("doors_width"));
        private IWebElement _heightInput => Driver.FindElement(By.Id("doors_height"));
        private IWebElement _automatikaCheck => Driver.FindElement(By.Id("automatika"));
        private IWebElement _montavimoDarbaiCheck => Driver.FindElement(By.Id("darbai"));
        private IWebElement _calculateButton => Driver.FindElement(By.Id("calc_submit"));
        private IWebElement _resultBox => Driver.FindElement(By.CssSelector("#calc_result > div"));

        public VartuTechnikaPage(IWebDriver webDriver) : base(webDriver)
        {
            Driver.Url = PageAddress;
        }

        public VartuTechnikaPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public VartuTechnikaPage InsertWidth(string width)
        {
            _widthInput.Clear();
            _widthInput.SendKeys(width);
            return this;
        }

        public VartuTechnikaPage InsertHeight(string height)
        {
            _heightInput.Clear();
            _heightInput.SendKeys(height);
            return this;
        }

        public VartuTechnikaPage InsertWidthAndHeight(string width, string height)
        {
            InsertWidth(width);
            InsertHeight(height);
            return this;
        }

        public VartuTechnikaPage CheckAutomatikCheckbox(bool shouldBeChecked)
        {
            if (shouldBeChecked != _automatikaCheck.Selected)
                _automatikaCheck.Click();
            return this;
        }

        public VartuTechnikaPage CheckMontavimoDarbaiCheckbox(bool shouldBeChecked)
        {
            if (shouldBeChecked != _montavimoDarbaiCheck.Selected)
                _montavimoDarbaiCheck.Click();
            return this;
        }

        public VartuTechnikaPage ClickCalculateButton()
        {
            _calculateButton.Click();
            return this;
        }

        private void WaitForResult()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(d => _resultBox.Displayed);
        }

        public VartuTechnikaPage CheckResult (string expectedResult)
        {
            WaitForResult();
            Assert.IsTrue(_resultBox.Text.Contains(expectedResult), $"Result is not the same, expected {expectedResult}, but was {_resultBox.Text}");
            return this;
        }
    }
}