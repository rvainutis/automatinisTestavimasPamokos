using automatinisTestavimasPamokos.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace automatinisTestavimasPamokos.Test
{
    public class DropDownTest
    {
        private static DropDownPage _page;

        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _page = new DropDownPage(driver);
        }
        
        [OneTimeTearDown]
        public static void TearDown()
        {
            _page.CloseBrowser();
        }
        //[Order(1)]
        [Test]
        public void TestDropwDown()
        {
            _page.SelectFromDropdownByText("Friday")
                .VerifyResult("Friday");
        }

        //[Order(2)]
        [Test]
        public void TestMultiDropDown()
        {
            _page.SelectFromMultiDropDownByValue("Ohio", "Florida")
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
            _page.SelectedFromMultipleDropDownByValue(selectedStates)
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
            _page.SelectedFromMultipleDropDownByValue(selectedStates)
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
            _page.SelectedFromMultipleDropDownByValue(selectedStates)
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
            _page.SelectedFromMultipleDropDownByValue(selectedStates)
                .ClickAllSelectedButton()
                .GetAllSelectedStates();
        }
    }
}
