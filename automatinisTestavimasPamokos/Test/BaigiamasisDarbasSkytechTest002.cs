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
    public class SkytechNotebooksTest
    {
        private static SkytechNotebooksPage _page;

        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _page = new SkytechNotebooksPage(driver);
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _page.CloseBrowser();
        }

        [Test]
        public void TestDellNotebooksCheckoutSum()
        {
            _page.ClickNotebookDellCategoryButton()
                .ThreadSleep500()
                .ClickNotebookDellSecondPageButton()
                .ThreadSleep500()
                .ClickNotebookDellFirstAddToCartButton()
                .ThreadSleep500()
                .ClickNotebookDellThrirdPageButton()
                .ThreadSleep500()
                .ClickNotebookDellSecondAddToCartButton()
                .ThreadSleep500()
                .ClickCartButton()
                .ThreadSleep500()
                .CheckCartItemsCount()
                .ThreadSleep500()
                .ChekCartItemsSum();
        }
    }
}
