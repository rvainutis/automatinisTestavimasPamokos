using automatinisTestavimasPamokos.Drivers;
using automatinisTestavimasPamokos.Page;
using NUnit.Framework;
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

        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = CustomDriver.GetChromeDriver();
            _dropDownPage = new DropDownPage(driver);
            _vartuTechnikaPage = new VartuTechnikaPage(driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            driver.Quit();
        }
    }
}
