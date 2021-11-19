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
    public class SkytechSearchPage : BasePage
    {
        // konstantos
        private const string PageAddress = "https://www.skytech.lt/search_form.html";
        private const string EmptySearchResult = "Nėra prekių, atitinkančių užduotus paieškos kriterijus.";

        // web elementai
        private IWebElement SearchByAllWordsField => Driver.FindElement(By.CssSelector("#searchform > table > tbody > tr:nth-child(1) > td:nth-child(3) > input[type=text]"));        
        private IWebElement TitlesAndDescriptionsRadioButton => Driver.FindElement(By.CssSelector("#searchform > table > tbody > tr:nth-child(4) > td:nth-child(3) > input:nth-child(3)"));
        private SelectElement CategoryList => new SelectElement(Driver.FindElement(By.CssSelector("#searchform > table > tbody > tr:nth-child(5) > td:nth-child(3) > select")));
        private IWebElement ManufacturerField => Driver.FindElement(By.Id("gamintojas"));
        private IWebElement SiteSearchResultEmpty => Driver.FindElement(By.CssSelector("#centerpanel > div.contentbox-center-wrap.nopad > table > tbody > tr > td"));
        private IWebElement SearchButton => Driver.FindElement(By.CssSelector("#searchform > table > tbody > tr:nth-child(8) > td:nth-child(1) > input"));

        public SkytechSearchPage(IWebDriver webDriver) : base(webDriver)
        {
            Driver.Url = PageAddress;
        }
        public SkytechSearchPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public SkytechSearchPage ThreadSleep500()
        {
            Thread.Sleep(500);
            return this;
        }

        public SkytechSearchPage ClickSearchByAllWordsField()
        {
            SearchByAllWordsField.Click();
            return this;
        }

        public SkytechSearchPage SendSearchTextToSearchByAllWordsField(string searchQuery)
        {
            SearchByAllWordsField.Clear();
            SearchByAllWordsField.SendKeys(searchQuery);
            return this;
        }

        public SkytechSearchPage ClickTitlesAndDescriptionsRadioButton()
        {
            TitlesAndDescriptionsRadioButton.Click();
            return this;
        }

        public SkytechSearchPage ClickManufacturerField()
        {
            ManufacturerField.Click();
            return this;
        }
        public SkytechSearchPage SendSearchTextManufacturerField(string manufacturer)
        {
            ManufacturerField.Clear();
            ManufacturerField.SendKeys(manufacturer);
            return this;
        }

        public SkytechSearchPage CheckSiteSearchResultEmpty()
        {
            Assert.AreEqual(EmptySearchResult, SiteSearchResultEmpty.Text, "Prekiu buvo rasta.");
            return this;
        }

        public SkytechSearchPage SelectFromCategoryList(string value)
        {
            CategoryList.SelectByValue(value);
            return this;
        }

        public SkytechSearchPage ClickSearchButton()
        {
            SearchButton.Click();
            return this;
        }




    }
}
