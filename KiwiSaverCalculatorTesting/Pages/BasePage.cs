using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace KiwiSaverCalculatorTesting
{
    public class BasePage
    {
        public static string baseUrl = "https://www.westpac.co.nz";
        public static IWebDriver Driver { get; set; }

    }
}
