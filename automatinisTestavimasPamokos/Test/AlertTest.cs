using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
