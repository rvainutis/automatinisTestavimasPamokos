using NUnit.Framework;
using System.Collections.Generic;

namespace automatinisTestavimasPamokos.Test
{
    public class DropDownTest : BaseTest
    {
        //[Order(1)]
        [Test]
        public void TestDropwDown()
        {
            _dropDownPage.NavigateToDefaultPage()
                .SelectFromDropdownByText("Friday")
                .VerifyResult("Friday");
        }

        //[Order(2)]
        [Test]
        public void TestMultiDropDown()
        {
            _dropDownPage.NavigateToDefaultPage()
                .SelectFromMultiDropDownByValue("Ohio", "Florida")
                .ClickFirstSelectedButton();
        }

        [Test]
        public void TestTwoStatesFirstSelected()
        {
            List<string> selectedStates = new List<string>
            {
                "Florida",
                "Ohio"
            };
            _dropDownPage.NavigateToDefaultPage()
                .SelectedFromMultipleDropDownByValue(selectedStates)
                .ClickFirstSelectedButton()
                .GetFirstSelectedState();
        }

        [Test]
        public void TestTwoStatesGetAllSelected()
        {
            List<string> selectedStates = new List<string>
            {
                "Florida",
                "Ohio"
            };
            _dropDownPage.NavigateToDefaultPage()
                .SelectedFromMultipleDropDownByValue(selectedStates)
                .ClickAllSelectedButton()
                .GetAllSelectedStates();
        }

        [Test]
        public void TestThreeStatesFirstSelected()
        {
            List<string> selectedStates = new List<string>
            {
                "Florida",
                "Ohio",
                "Washington"
            };
            _dropDownPage.NavigateToDefaultPage()
                .SelectedFromMultipleDropDownByValue(selectedStates)
                .ClickFirstSelectedButton()
                .GetFirstSelectedState2();
        }

        [Test]
        public void TestFourStatesGetAllSelected()
        {
            List<string> selectedStates = new List<string>
            {
                "Florida",
                "Ohio",
                "Washington",
                "Texas"
            };
            _dropDownPage.NavigateToDefaultPage()
                .SelectedFromMultipleDropDownByValue(selectedStates)
                .ClickAllSelectedButton()
                .GetAllSelectedStates();
        }
    }
}
