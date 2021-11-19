/*
    2021-11-19, Rimvydas Vainutis
    Baigiamasis darbas, Skytech.lt svetaines funkcionalumo testavimas
    DellNotebooksPage
*/

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
    public class SkytechDellNotebooksPage : BasePage
    {
        // konstantos        
        private const string PageAddress = "https://www.skytech.lt/nesiojami-kompiuteriai-nesiojami-kompiuteriai-c-86_165_81.html?f=s(),g(142),p(),k(317.89,5668.00)&frag=&fragd=0&pav=undefined&sort=5a&sand=1&grp=1&pagesize=100&page=1";

        // web elementai
        private IWebElement CartButton => Driver.FindElement(By.CssSelector("#krepselis > div > a > span"));
        private IWebElement NotebookDellFirstAddToCartButton => Driver.FindElement(By.CssSelector("#centerpanel > div.contentbox-center-wrap.nopad > table.productListing > tbody > tr:nth-child(5) > td:nth-child(6) > div > div.button-label > input"));
        private IWebElement NotebookDellSecondAddToCartButton => Driver.FindElement(By.CssSelector("#centerpanel > div.contentbox-center-wrap.nopad > table.productListing > tbody > tr:nth-child(6) > td:nth-child(6) > div > div.button-label > input"));
        private IWebElement CartTotalItemsCountResult => Driver.FindElement(By.Id("kcenter"));
        private IWebElement SumPrice => Driver.FindElement(By.CssSelector("#ktotal-top"));
        private IWebElement SearchField => Driver.FindElement(By.CssSelector("#body > div.pageouter > div.pagewrapper > div.pageheader > table > tbody > tr > td:nth-child(2) > div > form > div.search-wrap > input.search-field.inactive"));
        private IReadOnlyCollection<IWebElement> CartItemsPrice => Driver.FindElements(By.CssSelector("td.line-price"));
        private IReadOnlyCollection<IWebElement> CartItemsKiekisWidgetUp => Driver.FindElements(By.CssSelector(".up"));

        // veiksmai puslapyje, naudojant metodus
        public SkytechDellNotebooksPage(IWebDriver webDriver) : base(webDriver)
        {
            Driver.Url = PageAddress;
        }
        public SkytechDellNotebooksPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
        public SkytechDellNotebooksPage ThreadSleep500()
        {
            Thread.Sleep(500);
            return this;
        }        
        public SkytechDellNotebooksPage ClickNotebookDellFirstAddToCartButton()
        {
            NotebookDellFirstAddToCartButton.Click();
            return this;
        }        
        public SkytechDellNotebooksPage ClickNotebookDellSecondAddToCartButton()
        {
            NotebookDellSecondAddToCartButton.Click();
            return this;
        }
        public SkytechDellNotebooksPage CheckCartItemsCount(int cartItemsCount)
        {
            int CartTotalItemsCountResultInt = Convert.ToInt32(CartTotalItemsCountResult.Text);
            Assert.AreEqual(cartItemsCount, CartTotalItemsCountResultInt, "Prekiu skaicius nesutampa.");
            return this;
        }
        public SkytechDellNotebooksPage ClickCartButton()
        {
            CartButton.Click();
            return this;
        }
        public SkytechDellNotebooksPage ClickSearchField()
        {
            SearchField.Click();
            return this;
        }
        public SkytechDellNotebooksPage CheckCartItemSum(int ItemAmountIncrease)
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
        public SkytechDellNotebooksPage ClickCartItemsUpButton(int ItemAmountIncrease)
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
