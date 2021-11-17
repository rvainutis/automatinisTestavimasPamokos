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

        // Pasirenkame dvi prekes, krepselyje tikriname ju kainu suma su prekiu krepselio suma pateikta parduotuveje.

        [TestCase(0, 2, TestName = "001 Add two items, check item count and price sum.")]
        public void TestDellNotebooksCheckoutSum(int ItemAmountIncrease, int cartItemsCount)
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
                .CheckCartItemsCount(cartItemsCount)
                .ThreadSleep500()
                .CheckCartItemSum(ItemAmountIncrease);
        }

        [TestCase(2, 6, TestName = "002 Increase cart items amount by 2 and check price sum.")]
        public void TestDellNotebooksDifferentItemsCountChekoutSum(int ItemAmountIncrease, int cartItemsCount)
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
                .ClickCartItemsUpButton(ItemAmountIncrease)
                .ThreadSleep500()
                .ClickSearchField()
                .ThreadSleep500()
                .CheckCartItemsCount(cartItemsCount)
                .ThreadSleep500()
                .CheckCartItemSum(ItemAmountIncrease)
                .ThreadSleep500();
        }
    }
}
