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
        private IWebElement SumPrice => Driver.FindElement(By.CssSelector("#ktotal-top"));
        private IWebElement SearchField => Driver.FindElement(By.CssSelector("#body > div.pageouter > div.pagewrapper > div.pageheader > table > tbody > tr > td:nth-child(2) > div > form > div.search-wrap > input.search-field.inactive"));
        private IReadOnlyCollection<IWebElement> CartItemsPrice => Driver.FindElements(By.CssSelector("td.line-price"));
        private IReadOnlyCollection<IWebElement> CartItemsKiekisWidgetUp => Driver.FindElements(By.CssSelector(".up"));
        //private IReadOnlyCollection<IWebElement> CartItemsKiekisWidgetUp => Driver.FindElements(By.CssSelector("td:nth-child(5)"));

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
        public SkytechNotebooksPage ClickSearchField()
        {
            SearchField.Click();
            return this;
        }

        public SkytechNotebooksPage CheckCartItemsCount(int cartItemsCount)
        {
            int CartTotalItemsCountResultInt = Convert.ToInt32(CartTotalItemsCountResult.Text);
            Assert.AreEqual(cartItemsCount, CartTotalItemsCountResultInt, "Prekiu skaicius nesutampa.");
            return this;
        }

        public SkytechNotebooksPage CheckCartItemSum(int ItemAmountIncrease)
        {
            // Sarasas kainu formatu: "123.12 €"

            List<string> cartItemsPricesFull = new List<string>();            

            foreach (IWebElement cartItem in CartItemsPrice)
            {
                cartItemsPricesFull.Add(cartItem.Text);
            }

            // Sarasas kainu formatu "1 234.12"

            List<string> cartItemsPricesFullTrimmed = new List<string>();

            foreach (string item in cartItemsPricesFull)
            {
                cartItemsPricesFullTrimmed.Add(item.Substring(0, item.Length - 2).Replace(".", ",").Replace(" ", ""));
            }

            // Sarasas kainu formatu "1234,12"

            List<double> cartItemsPrices = new List<double>();

            foreach (string item in cartItemsPricesFullTrimmed)
            {
                cartItemsPrices.Add(Convert.ToDouble(item));
            }

            double CartItemsTotalSum = cartItemsPrices.Sum();

            // Parduotuves pateikta suma formatu "1 234.12 €" pakeiciame i double skaitmeni formatu "1234,12"
            
            double TotalSumFromSite = Convert.ToDouble(SumPrice.Text.Substring(0, SumPrice.Text.Length - 2).Replace(".", ",").Replace(" ", ""));

            if (ItemAmountIncrease != 0)
            {
                double TotalSumAfterAmountIncrease = CartItemsTotalSum * (ItemAmountIncrease + 1);
                Assert.AreEqual(TotalSumAfterAmountIncrease, TotalSumFromSite, "Nesutampa.");
            }
            else
            {
                Assert.AreEqual(TotalSumFromSite, TotalSumFromSite, "Nesutampa.");
            }
            return this;
        }

        public SkytechNotebooksPage ClickCartItemsUpButton(int ItemAmountIncrease)
        {
            foreach (IWebElement cartItem in CartItemsKiekisWidgetUp)
            {
                for (int i = 1; i <= ItemAmountIncrease; i++)
                {
                    cartItem.Click();
                }
            }
            return this;
        }
    }
}
