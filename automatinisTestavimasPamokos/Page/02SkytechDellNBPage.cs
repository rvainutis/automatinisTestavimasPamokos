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
        // nuoroda i Dell nesiojamu kompiuteriu kategorija
        private const string SkytechDellNotebooksAddress = "https://www.skytech.lt/nesiojami-kompiuteriai-nesiojami-kompiuteriai-c-86_165_81.html?f=s(),g(142),p(),k(317.89,5668.00)&frag=&fragd=0&pav=undefined&sort=5a&sand=1&grp=1&pagesize=100&page=1";

        // web elementai
        //private IWebElement NotebookDellCategoryButton => Driver.FindElement(By.CssSelector("#f-g-142 > div.line-wrap > span"));
        //private IWebElement NotebookDellSecondPageButton => Driver.FindElement(By.CssSelector("#centerpanel > div.contentbox-center-wrap.nopad > table.pagebar > tbody > tr > td.pagenav > a:nth-child(2) > div > div.page"));
        //private IWebElement NotebookDellThrirdPageButton => Driver.FindElement(By.CssSelector("#centerpanel > div.contentbox-center-wrap.nopad > table.pagebar > tbody > tr > td.pagenav > a:nth-child(3) > div > div.page"));
        private IWebElement NotebookDellFirstAddToCartButton => Driver.FindElement(By.CssSelector("#centerpanel > div.contentbox-center-wrap.nopad > table.productListing > tbody > tr:nth-child(5) > td:nth-child(6) > div > div.button-label > input"));
        private IWebElement NotebookDellSecondAddToCartButton => Driver.FindElement(By.CssSelector("#centerpanel > div.contentbox-center-wrap.nopad > table.productListing > tbody > tr:nth-child(6) > td:nth-child(6) > div > div.button-label > input"));
        private IWebElement CartButton => Driver.FindElement(By.CssSelector("#krepselis > div > a > span"));
        
        //        

        public SkytechDellNotebooksPage(IWebDriver webDriver) : base(webDriver)
        {
            Driver.Url = SkytechDellNotebooksAddress;
        }

        public SkytechDellNotebooksPage ThreadSleep500()
        {
            Thread.Sleep(500);
            return this;
        }

        //public SkytechDellNotebooksPage ClickNotebookDellCategoryButton()
        //{
        //    NotebookDellCategoryButton.Click();
        //    return this;
        //}

        //public SkytechDellNotebooksPage ClickNotebookDellSecondPageButton()
        //{
        //    NotebookDellSecondPageButton.Click();
        //    return this;
        //}

        public SkytechDellNotebooksPage ClickNotebookDellFirstAddToCartButton()
        {
            NotebookDellFirstAddToCartButton.Click();
            return this;
        }

        //public SkytechDellNotebooksPage ClickNotebookDellThrirdPageButton()
        //{
        //    NotebookDellThrirdPageButton.Click();
        //    return this;
        //}

        public SkytechDellNotebooksPage ClickNotebookDellSecondAddToCartButton()
        {
            NotebookDellSecondAddToCartButton.Click();
            return this;
        }

        public SkytechDellNotebooksPage ClickCartButton()
        {
            CartButton.Click();
            return this;
        }






        
    }
}
