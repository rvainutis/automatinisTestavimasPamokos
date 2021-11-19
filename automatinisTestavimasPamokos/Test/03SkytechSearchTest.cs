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
    class SkytechSearchTest : BaseTest
    {
        // 270 - Kategorija: periferija, biuro iranga
        [TestCase("AW27255981D", "270", "Dell", TestName = "05 Test search fields, get empty list.")]
        public void TestItemCount(string searchQuery, string categoryValue, string manufacturer)
        {
            _skytechSearchPage
                .NavigateToDefaultPage()
                .ThreadSleep500()
                .ClickSearchByAllWordsField()
                .ThreadSleep500()
                .SendSearchTextToSearchByAllWordsField(searchQuery)
                .ThreadSleep500()
                .ClickTitlesAndDescriptionsRadioButton()
                .ThreadSleep500()
                .SelectFromCategoryList(categoryValue)
                .ThreadSleep500()
                .ClickManufacturerField()
                .ThreadSleep500()
                .SendSearchTextManufacturerField(manufacturer)
                .ThreadSleep500()
                .ClickSearchButton()
                .ThreadSleep500()
                .CheckSiteSearchResultEmpty()
                .ThreadSleep500();            
        }
    }
}
