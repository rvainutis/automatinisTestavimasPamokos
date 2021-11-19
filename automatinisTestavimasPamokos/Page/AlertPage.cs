using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatinisTestavimasPamokos.Page
{
    public class AlertPage : BasePage
    {
        private const string PageAddress = "https://demo.seleniumeasy.com/javascript-alert-box-demo.html";

        public AlertPage(IWebDriver webDriver) : base(webDriver)
        { }
        public AlertPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
    }
}
