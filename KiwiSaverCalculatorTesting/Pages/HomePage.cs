using KiwiSaverCalculatorTesting.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace KiwiSaverCalculatorTesting.Pages
{
    class HomePage: BasePage
    {
        public IWebElement EleKiwiSaver => Driver.FindElement(By.CssSelector("#ubermenu-section-link-kiwisaver-ps"));
        public IWebElement EleMenuTitle => Driver.FindElement(By.CssSelector("#side-menu-ps>.sw-sidenav-ancestor"));

        public IWebElement EleRiskProfileRetirementCalculatorIcon => Driver.GetElementAndScrollTo(By.XPath("//*[@id='side-menu-ps']/ul/li[4]/a[2]/span"));

        public IWebElement EleKiwiSaverRetirementCalculator => Driver.FindElement(By.CssSelector("#responsive-children-title-3956-ps"), 10);

    }
}
