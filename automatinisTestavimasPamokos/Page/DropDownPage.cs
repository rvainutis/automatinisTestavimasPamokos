using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace automatinisTestavimasPamokos.Page
{
    public class DropDownPage : BasePage
    {
        private const string PageAddress = "https://demo.seleniumeasy.com/basic-select-dropdown-demo.html";
        private const string ResultText = "Day selected :- ";
        private const string ResultText2 = "First selected option is : ";
        private readonly List<string> selectedStates = new List<string>
            {
                "Florida",
                "Ohio"
            };
        private readonly List<string> selectedStates2 = new List<string>
            {
                "Florida",
                "Ohio",
                "Washington"
            };
        private readonly List<string> selectedStates3 = new List<string>
            {
                "Florida",
                "Ohio",
                "Washington",
                "Texas"
            };

        private SelectElement DropDown => new SelectElement(Driver.FindElement(By.Id("select-demo")));
        private IWebElement ResultTextElement => Driver.FindElement(By.CssSelector(".selected-value"));
        private IWebElement ResultFirstSelectedState => Driver.FindElement(By.CssSelector(".getall-selected"));
        private IWebElement FirstSelectedButton => Driver.FindElement(By.Id("printMe"));
        private IWebElement GetAllSelectedButton => Driver.FindElement(By.Id("printAll"));
        private SelectElement MultiDropDown => new SelectElement(Driver.FindElement(By.Id("multi-select")));
        public DropDownPage(IWebDriver webDriver) : base(webDriver)
        {
            Driver.Url = PageAddress;
        }
        public DropDownPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public DropDownPage SelectFromDropdownByText(string text)
        {
            DropDown.SelectByText(text);
            return this;
        }

        public DropDownPage SelectFromDropdownByValue(string text)
        {
            DropDown.SelectByValue(text);
            return this;
        }

        public DropDownPage SelectFromMultiDropDownByValue(string firstValue, string secondValue)
        {
            Actions action = new Actions(Driver);
            MultiDropDown.SelectByValue(firstValue);
            action.KeyDown(Keys.Control);
            MultiDropDown.SelectByValue(secondValue);
            action.KeyUp(Keys.Control);
            action.Build().Perform();
            return this;
        }

        public DropDownPage ClickFirstSelectedButton()
        {
            FirstSelectedButton.Click();
            return this;
        }

        public DropDownPage ClickAllSelectedButton()
        {
            GetAllSelectedButton.Click();
            return this;
        }

        public DropDownPage SelectedFromMultipleDropDownByValue(List<string> listOfStates)
        {
            MultiDropDown.DeselectAll();
            Actions action = new Actions(Driver);
            action.KeyDown(Keys.LeftControl);
            foreach (string state in listOfStates)
            {
                foreach (IWebElement option in MultiDropDown.Options)
                {
                    if (state.Equals(option.GetAttribute("value")))
                    {
                        action.Click(option);
                        break;
                    }
                }
            }
            action.KeyUp(Keys.LeftControl);
            //action.Build().Perform();
            //action.Click(FirstSelectedButton);
            action.Build().Perform();
            return this;
        }

        public DropDownPage SelectFromMultiDropDownByValue(string value)
        {
            MultiDropDown.SelectByValue(value);
            return this;
        }

        public DropDownPage VerifyResult(string selectedDay)
        {
            Assert.IsTrue(ResultTextElement.Text.Equals(ResultText + selectedDay), $"Result is wrong, not {selectedDay}");
            return this;
        }

        public DropDownPage GetFirstSelectedState()
        {
            string firstStateTrim = ResultFirstSelectedState.Text;
            firstStateTrim = firstStateTrim.Replace(ResultText2, "");
            Assert.AreEqual(firstStateTrim, selectedStates[0], "States not the same.");
            return this;
        }
        public DropDownPage GetFirstSelectedState2()
        {
            string firstStateTrim = ResultFirstSelectedState.Text;
            firstStateTrim = firstStateTrim.Replace(ResultText2, "");
            Assert.AreEqual(firstStateTrim, selectedStates2[0], "States not the same.");
            return this;
        }

        public DropDownPage GetAllSelectedStates()
        {
            string usedStateList = $"Options selected are : {selectedStates3[0]},{selectedStates[1]},{selectedStates3[2]},{selectedStates3[3]}";
            Assert.AreEqual(usedStateList, ResultFirstSelectedState.Text, "States not the same.");
            return this;
        }
    }
}
