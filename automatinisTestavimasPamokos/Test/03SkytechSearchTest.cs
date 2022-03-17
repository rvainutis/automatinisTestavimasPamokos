/*
    2021-11-19, Rimvydas Vainutis
    Baigiamasis darbas, Skytech.lt svetaines funkcionalumo testavimas
    SearchTest
*/

using NUnit.Framework;

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
