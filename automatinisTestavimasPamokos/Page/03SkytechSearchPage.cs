using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace automatinisTestavimasPamokos.Page
{
    public class SkytechCartPage : BasePage
    {
        // konstantos
        private const string SkytechCartAddress = "https://www.skytech.lt/shopping_cart.php";

        // web elementai
        private IWebElement CartTotalItemsCountResult => Driver.FindElement(By.Id("kcenter"));
        private IWebElement SumPrice => Driver.FindElement(By.CssSelector("#ktotal-top"));
        private IWebElement SearchField => Driver.FindElement(By.CssSelector("#body > div.pageouter > div.pagewrapper > div.pageheader > table > tbody > tr > td:nth-child(2) > div > form > div.search-wrap > input.search-field.inactive"));
        private IReadOnlyCollection<IWebElement> CartItemsPrice => Driver.FindElements(By.CssSelector("td.line-price"));
        private IReadOnlyCollection<IWebElement> CartItemsKiekisWidgetUp => Driver.FindElements(By.CssSelector(".up"));

        public SkytechCartPage(IWebDriver webDriver) : base(webDriver)
        {
            Driver.Url = SkytechCartAddress;
        }

        public SkytechCartPage ThreadSleep500()
        {
            Thread.Sleep(500);
            return this;
        }

        public SkytechCartPage CheckCartItemsCount(int cartItemsCount)
        {
            int CartTotalItemsCountResultInt = Convert.ToInt32(CartTotalItemsCountResult.Text);
            Assert.AreEqual(cartItemsCount, CartTotalItemsCountResultInt, "Prekiu skaicius nesutampa.");
            return this;
        }

        public SkytechCartPage ClickSearchField()
        {
            SearchField.Click();
            return this;
        }

        public SkytechCartPage CheckCartItemSum(int ItemAmountIncrease)
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

        public SkytechCartPage ClickCartItemsUpButton(int ItemAmountIncrease)
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
