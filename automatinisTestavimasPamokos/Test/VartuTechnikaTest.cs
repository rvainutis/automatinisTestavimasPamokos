using NUnit.Framework;

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