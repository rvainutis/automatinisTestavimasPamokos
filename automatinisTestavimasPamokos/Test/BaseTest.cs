using automatinisTestavimasPamokos.Drivers;
using automatinisTestavimasPamokos.Page;
using automatinisTestavimasPamokos.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatinisTestavimasPamokos.Test
{
    public class BaseTest
    {
        public static IWebDriver driver;
        public static DropDownPage _dropDownPage;
        public static VartuTechnikaPage _vartuTechnikaPage;
        public static SkytechLoginPage _skytechLoginPage;
        public static SkytechDellNotebooksPage _skytechDellNotebooksPage;
        public static SkytechSearchPage _skytechSearchPage;
        public static AlertPage _AlertPage;
        

        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = CustomDriver.GetChromeDriver();
            _dropDownPage = new DropDownPage(driver);
            _vartuTechnikaPage = new VartuTechnikaPage(driver);
            _skytechLoginPage = new SkytechLoginPage(driver);
            _skytechDellNotebooksPage = new SkytechDellNotebooksPage(driver);
            _skytechSearchPage = new SkytechSearchPage(driver);
            _AlertPage = new AlertPage(driver);


        }

        [TearDown]
        public static void TakeScreenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                MyScreenshot.MakeScreenshot(driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            driver.Quit();
        }
    }
}
