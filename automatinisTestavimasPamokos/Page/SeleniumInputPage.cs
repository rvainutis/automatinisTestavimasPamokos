using NUnit.Framework;
using OpenQA.Selenium;

namespace automatinisTestavimasPamokos.Page
{
    // Padaryti public, kad bendradarbiautu su Test folderiu
    public class SeleniumInputPage
    {
        private static IWebDriver _driver;

        //pakeisti i private ir prie pavadinimo dedame "_"
        // su => perduodame i Test, nes kitaip nematys
        private IWebElement _inputA => _driver.FindElement(By.Id("sum1"));
        private IWebElement _inputB => _driver.FindElement(By.Id("sum2"));
        private IWebElement _buttonGetTotal => _driver.FindElement(By.CssSelector("#gettotal > button"));
        private IWebElement _atsakymas => _driver.FindElement(By.Id("displayvalue"));

        // konstruktorius tam, kad Test galetume susieti
        public SeleniumInputPage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        public void InsertTextA(string text)
        {
            _inputA.Clear();
            _inputA.SendKeys(text);
        }

        public void InsertTextB(string text)
        {
            _inputB.Clear();
            _inputB.SendKeys(text);
        }

        public void ClickShowMessageButton()
        {
            _buttonGetTotal.Click();
        }

        public void CheckResult(string expectedResult)
        {
            Assert.AreEqual(expectedResult, _atsakymas.Text, "Tekstas neatsidaro");
        }
    }
}
