using automatinisTestavimasPamokos.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatinisTestavimasPamokos.Test
{
    public class DropDownTest
    {
        private static DropDownPage _page;

        [OneTimeSetup]
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


        // GERAI PERZIURETI, NES NEPERDUODA I PAGE/TEST
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
    }
}
