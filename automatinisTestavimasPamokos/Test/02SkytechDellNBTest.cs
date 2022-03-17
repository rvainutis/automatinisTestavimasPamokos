/*
    2021-11-19, Rimvydas Vainutis
    Baigiamasis darbas, Skytech.lt svetaines funkcionalumo testavimas
    DellNotebooksTest
*/

using NUnit.Framework;

namespace automatinisTestavimasPamokos.Test
{
    public class SkytechNotebooksTest : BaseTest
    {
        // nurodome, kokio prekiu kiekio tikimes (siuo atveju, idedame dvi prekes = 2)
        [TestCase(2, TestName = "03 Add two items, check items count.")]
        public void TestItemCount(int cartItemsCount)
        {
            _skytechDellNotebooksPage
                .NavigateToDefaultPage()
                .ThreadSleep500()
                .ClickNotebookDellFirstAddToCartButton()
                .ThreadSleep500()
                .ClickNotebookDellSecondAddToCartButton()
                .ThreadSleep500()
                .CheckCartItemsCount(cartItemsCount)
                .ThreadSleep500();
        }

        // nurodome, kokip prekiu kiekio tikimes (siuo atveju, idedame dvi prekes = 2)
        // nurodome, kiek kartu padidinti prekiu kieki (siuo atveju, didiname du kartus = po 3 prekes)
        // nurodome, kiek is viso prekiu bus po ju kiekio padidinimo (siuo atveju, didiname du kartus = is viso prekiu krepselyje 6)
        [TestCase(2, 2, 6, TestName = "04 Add two items, go to cart, increase cart items amount by 2 and check price sum.")]
        public void TestDellNotebooksDifferentItemsCountChekoutSum(int cartItemsCount, int ItemAmountIncrease, int cartItemsCountAfterIncrease)
        {
            _skytechDellNotebooksPage
                .NavigateToDefaultPage()
                .ThreadSleep500()
                .ClickNotebookDellFirstAddToCartButton()
                .ThreadSleep500()
                .ClickNotebookDellSecondAddToCartButton()
                .ThreadSleep500()
                .ClickCartButton()
                .ThreadSleep500()
                .CheckCartItemsCount(cartItemsCount)
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