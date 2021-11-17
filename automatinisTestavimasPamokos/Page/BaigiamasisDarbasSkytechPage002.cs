using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace automatinisTestavimasPamokos.Page
{
    public class SkytechNotebooksPage : BasePage
    {
        // konstantos
        private const string PageAddress002 = "https://www.skytech.lt/nesiojami-kompiuteriai-nesiojami-kompiuteriai-c-86_165_81.html";      // nesiojamu kompiuteriu puslapis
        private const string CartItemsCount = "2";

        // web elementai
        private IWebElement NotebookDellCategoryButton => Driver.FindElement(By.CssSelector("#f-g-142 > div.line-wrap > span"));
        private IWebElement NotebookDellSecondPageButton => Driver.FindElement(By.CssSelector("#centerpanel > div.contentbox-center-wrap.nopad > table.pagebar > tbody > tr > td.pagenav > a:nth-child(2) > div > div.page"));
        private IWebElement NotebookDellThrirdPageButton => Driver.FindElement(By.CssSelector("#centerpanel > div.contentbox-center-wrap.nopad > table.pagebar > tbody > tr > td.pagenav > a:nth-child(3) > div > div.page"));
        private IWebElement NotebookDellFirstAddToCartButton => Driver.FindElement(By.CssSelector("#centerpanel > div.contentbox-center-wrap.nopad > table.productListing > tbody > tr:nth-child(53) > td:nth-child(6) > div > div.button-label > input"));
        private IWebElement NotebookDellSecondAddToCartButton => Driver.FindElement(By.CssSelector("#centerpanel > div.contentbox-center-wrap.nopad > table.productListing > tbody > tr:nth-child(47) > td:nth-child(6) > div > div.button-label > input"));
        private IWebElement CartButton => Driver.FindElement(By.CssSelector("#krepselis > div > a > span"));
        private IWebElement CartTotalItemsCountResult => Driver.FindElement(By.Id("kcenter"));
        //private IWebElement FirstItemPrice => Driver.FindElement(By.XPath("/html/body/div[6]/div[1]/div[4]/div[2]/div[5]/form/div[1]/table[1]/tbody/tr[3]/td[6]"));
        //private IWebElement SecondItemPrice => Driver.FindElement(By.XPath("/html/body/div[6]/div[1]/div[4]/div[2]/div[5]/form/div[1]/table[1]/tbody/tr[3]/td[6]"));
        private IWebElement SumPrice => Driver.FindElement(By.CssSelector("#ktotal-top"));

        //private readonly IReadOnlyCollection<IWebElement> CartItems = Driver.FindElements(By.CssSelector("div.shopping-cart-main-wrap"));

        private IReadOnlyCollection<IWebElement> CartItems => Driver.FindElements(By.XPath("/html/body/div[6]/div[1]/div[6]/div[2]/div[5]/form/div[1]/table[1]/tbody"));

        public SkytechNotebooksPage(IWebDriver webDriver) : base(webDriver)
        {
            Driver.Url = PageAddress002;
        }

        public SkytechNotebooksPage ThreadSleep500()
        {
            Thread.Sleep(500);
            return this;
        }

        public SkytechNotebooksPage ClickNotebookDellCategoryButton()
        {
            NotebookDellCategoryButton.Click();
            return this;
        }

        public SkytechNotebooksPage ClickNotebookDellSecondPageButton()
        {
            NotebookDellSecondPageButton.Click();
            return this;
        }

        public SkytechNotebooksPage ClickNotebookDellFirstAddToCartButton()
        {
            NotebookDellFirstAddToCartButton.Click();
            return this;
        }

        public SkytechNotebooksPage ClickNotebookDellThrirdPageButton()
        {
            NotebookDellThrirdPageButton.Click();
            return this;
        }

        public SkytechNotebooksPage ClickNotebookDellSecondAddToCartButton()
        {
            NotebookDellSecondAddToCartButton.Click();
            return this;
        }

        public SkytechNotebooksPage ClickCartButton()
        {
            CartButton.Click();
            return this;
        }

        public SkytechNotebooksPage CheckCartItemsCount()
        {
            Assert.AreEqual(CartItemsCount, CartTotalItemsCountResult.Text, "Prekiu skaicius nesutampa.");
            return this;
        }

        public SkytechNotebooksPage CheckCartItemSum()
        {
            List<int> CartItemsPriceFull = new List<int>();
            int CartItemsPriceSum = CartItemsPriceFull.Sum();

            foreach (IWebElement cartItem in CartItems)
            {
                CartItemsPriceFull.Add(Convert.ToInt32(cartItem.GetAttribute("line-price").Substring(0, cartItem.GetAttribute("line-price").Length - 2)));
            }

            Assert.AreEqual(SumPrice, CartItemsPriceSum, "Kainos nesutampa.");

            return this;
        }



        //{
        //    List<int> ItemPrices = new List<int>();

        //    foreach (IWebElement element in CartItems)
        //    {
        //        ItemPrices.Add(Convert.ToInt32(element.GetAttribute("line-price").Substring(0, element.GetAttribute("line-price").Length - 2)));
        //    }

        //    int ResultSumTotal = ItemPrices.Sum();

        //    Assert.AreEqual(SumPrice, ResultSumTotal, "Kainos nesutampa.");

        //    return this;
        //}

        /*
        public SkytechNotebooksPage ChekCartItemsSum()
        {
            // prekes kaina '1000.00 €' string tipo keiciame i int tipa, pries tai nukerpant du simbolius nuo turimo string'o

            int item1 = Convert.ToInt32(FirstItemPrice.Text.Substring(0, FirstItemPrice.Text.Length-2));
            int item2 = Convert.ToInt32(SecondItemPrice.Text.Substring(0, SecondItemPrice.Text.Length - 2));
            int sumaResult = Convert.ToInt32(SumPrice.Text.Substring(0, SecondItemPrice.Text.Length - 2));


            if (item1 + item2 == sumaResult)
            {
                Assert.IsTrue(true);
            }

            return this;
        }
        */
    }
}
