using automatinisTestavimasPamokos.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatinisTestavimasPamokos.Test
{
    public class VartuTechnikaTest : BaseTest
    {
        [TestCase("2000", "2000", true, false, "665.98€", TestName = "2000x2000 + vartu automatika = 665.98")]

        public void TestVartuTechnika(string width, string height, bool automatika, bool montavimoDarbai, string result)
        {
            _vartuTechnikaPage.NavigateToDefaultPage()
            .InsertWidthAndHeight(width, height)
            .CheckAutomatikCheckbox(automatika)
            .CheckMontavimoDarbaiCheckbox(montavimoDarbai)
            .ClickCalculateButton()
            .CheckResult(result);
        }
    }
}