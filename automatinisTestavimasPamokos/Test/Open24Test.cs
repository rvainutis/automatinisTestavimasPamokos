//using Docker.DotNet.Models;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testavimo_kursai_2021.Page;

namespace Testavimo_kursai_2021.Test
{
    class Open24Test
    {
        private static Open24LoginPage _page;
        //private static Open24Homepage _page2;
        //private static Open24ChildrenSection _page3;


        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _page = new Open24LoginPage(driver);
            //_page2 = new Open24Homepage(driver);
            //_page3 = new Open24ChildrenSection(driver);
        }
        [OneTimeTearDown]
        public static void TearDown()
        {
            //_driver.Quit();
        }
        [TestCase("gabriele.rutkauske@gmail.com", "KodasTestui", "Mano užsakymai", TestName = "Test Valid LogIn")]
        public void TestValidLogIn(string email, string password, string result)
        {
            _page.InsertEmailAndPassword(email, password)
            .ClickLogInButton()
            .CheckLogInResult(result);
        }
        [TestCase("gabbriele89@hotmail.com", "Testavimokodas", "Lojalumo taškų istorija", TestName = "Test Loyalty button")]
        public void TestLoyaltybutton(string firstInput, string secondInput, string result)
        {
            _page.InsertEmailAndPassword(firstInput, secondInput)
            .ClickLogInButton()
            .LoyaltyButtonClick()
            .CheckLoyaltyButtonResult(result);
        }
        /*
        [Test]
        public void TestReimaBannerButton()
        {
            _page2.ClickReimaBanner()
            .VerifyReimaBannerResult("REIMA(448)");
        }
        [Test]
        public void TestFirstItemToChartName()
        {
            _page3.ClickFirstChosenItem()
                .ClickChosenColor1().ClickChosenSixe1().ClickAddToChartButton().ClickOpenChartButton().VerifyFirstItemNameResult("REIMA Trondheim");
        }
        public void TestFirstItemToChartPrice()
        {
            _page3.ClickFirstChosenItem()
                .ClickChosenColor1().ClickChosenSixe1().ClickAddToChartButton().ClickOpenChartButton().VerifyFirstItemPriceResult("159,95 €");
        }
        public void TestTotalChartPrice()
        {
            _page3.ClickFirstChosenItem()
                .ClickChosenColor1().ClickChosenSixe1().ClickAddToChartButton().ClickOpenChartButton().VerifyTotalChartPriceResult("159,95 €");
        }
        */
    }
}