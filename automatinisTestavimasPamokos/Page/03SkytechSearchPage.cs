using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace automatinisTestavimasPamokos.Page
{
    public class SkytechSearchPage : BasePage
    {
        // konstantos
        private const string SkytechCartAddress = "https://www.skytech.lt/search_form.html";

        // web elementai
        

        public SkytechSearchPage(IWebDriver webDriver) : base(webDriver)
        {
            Driver.Url = SkytechCartAddress;
        }

        public SkytechSearchPage ThreadSleep500()
        {
            Thread.Sleep(500);
            return this;
        }
    }
}
