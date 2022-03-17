using NUnit.Framework;

namespace automatinisTestavimasPamokos.Test
{
    public class AlertTest : BaseTest
    {
        [Test]
        public void TestAlert()
        {
            _AlertPage.NavigateToDefaultPage()
                .ClickAlertButton()
                .AcceptAlert();
        }
        [Test]
        public void TestConfirmationAlert()
        {
            _AlertPage.NavigateToDefaultPage()
                .ClickConfirmationAlertButton();
        }
        [Test]
        public void TestClickMe()
        {
            _AlertPage.NavigateToDefaultPage()
                .ClickClickMeButton();
        }
    }
}
