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
        private static SkytechDellNotebooksPage _page;        

        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _page = new SkytechDellNotebooksPage(driver);            
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _page.CloseBrowser();
        }
        
        [TestCase(2, TestName = "03 Add two items, check items count.")]
        public void TestItemCount(int cartItemsCount)
        {
            _page.ClickNotebookDellFirstAddToCartButton()
                .ThreadSleep500()
                .ClickNotebookDellSecondAddToCartButton()
                .ThreadSleep500()
                .CheckCartItemsCount(cartItemsCount)
                .ThreadSleep500();
        }

        [TestCase(2, 2, 6, TestName = "04 Add two items, go to cart, increase cart items amount by 2 and check price sum.")]
        public void TestDellNotebooksDifferentItemsCountChekoutSum(int cartItemsCount, int ItemAmountIncrease, int cartItemsCountAfterIncrease)
        {
            _page.ClickNotebookDellFirstAddToCartButton()
                .ThreadSleep500()
                .ClickNotebookDellSecondAddToCartButton()
                .ThreadSleep500()                
                .ClickCartButton()
                .ThreadSleep500()
                .ClickCartItemsUpButton(ItemAmountIncrease)
                .ThreadSleep500()
                .ClickSearchField()
                .ThreadSleep500()
                .CheckCartItemsCount(cartItemsCountAfterIncrease)
                .ThreadSleep500()
                .CheckCartItemSum(ItemAmountIncrease)
                .ThreadSleep500();
        }
    }
}