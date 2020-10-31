using KiwiSaverCalculatorTesting.Pages;
using KiwiSaverCalculatorTesting.Utils;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace KiwiSaverCalculatorTesting.Tests
{
    class CalculationKiwiSaverRetirementBalanceTest: BasePage
    {
        CalculatorHomePage calculatorHomePage = new CalculatorHomePage();
        EmployedCalculatorPage employedCalculatorPage = new EmployedCalculatorPage();
        SelfEmployedCalculatorPage selfEmployedCalculatorPage = new SelfEmployedCalculatorPage();
        NotEmployedCalculatorPage notEmployedCalculatorPage = new NotEmployedCalculatorPage();
        Utilities utils = new Utilities();

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl($"{baseUrl}/kiwisaver/calculators/kiwisaver-calculator/");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var eleIframe = calculatorHomePage.IFrame;

            Thread.Sleep(3000);
            Driver.SwitchTo().Frame(eleIframe);

            var wait1 = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait1.Until(driver => calculatorHomePage.LabelCurrentAge.Displayed);
        }

        [Test]
        public void EmployedCustomerCalculationTest()
        {
            utils.ClickInIframe(Driver, calculatorHomePage.EleDropDownArrowEmploymentStatus);

            Thread.Sleep(3000);
            utils.ClickInIframe(Driver, calculatorHomePage.EleEmploymentStatusEmployedOption);

            var wait2 = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait2.Until(driver => employedCalculatorPage.EleInputSalaryPerYear.Displayed);

            Assert.IsFalse(employedCalculatorPage.EleButtonViewKiwiSaverRetirementProjections.Enabled);

            employedCalculatorPage.EleInputCurrentAge.SendKeys("30");
            employedCalculatorPage.EleInputSalaryPerYear.SendKeys("82000");
            employedCalculatorPage.EleOptionKiwiSaverMemberContribution4Percent.Click();
            employedCalculatorPage.EleOptionRiskProfileDefensive.Click();

            Assert.IsTrue(employedCalculatorPage.EleButtonViewKiwiSaverRetirementProjections.Enabled);

            employedCalculatorPage.EleButtonViewKiwiSaverRetirementProjections.Click();

            Assert.IsFalse(employedCalculatorPage.EleButtonViewKiwiSaverRetirementProjections.Displayed);

            Assert.IsTrue(employedCalculatorPage.EleResultValue.Displayed);

            Assert.IsTrue(employedCalculatorPage.EleResultValue.Text.Contains("436,365"));
        }

        [Test]
        public void SelfEmployedCustomerCalculationTest()
        {
            utils.ClickInIframe(Driver, calculatorHomePage.EleDropDownArrowEmploymentStatus);

            Thread.Sleep(3000);
            utils.ClickInIframe(Driver, calculatorHomePage.EleEmploymentStatusSelfEmployedOption);

            Assert.IsFalse(selfEmployedCalculatorPage.EleButtonViewKiwiSaverRetirementProjections.Enabled);

            selfEmployedCalculatorPage.EleInputCurrentAge.SendKeys("45");
            selfEmployedCalculatorPage.EleInputCurrentKiwiSaverBalance.SendKeys("100000");
            selfEmployedCalculatorPage.EleInputVoluntaryContributions.SendKeys("90");

            utils.ClickInIframe(Driver, calculatorHomePage.EleDropDownArrowVoluntaryConditionsFrequency);

            Thread.Sleep(3000);
            utils.ClickInIframe(Driver, calculatorHomePage.EleVoluntaryContributionsFortnightlyOption);

            selfEmployedCalculatorPage.EleOptionRiskProfileConservative.Click();

            selfEmployedCalculatorPage.EleInputSavingsGoalAtRetirement.SendKeys("290000");

            Assert.IsTrue(selfEmployedCalculatorPage.EleButtonViewKiwiSaverRetirementProjections.Enabled);

            selfEmployedCalculatorPage.EleButtonViewKiwiSaverRetirementProjections.Click();

            Assert.IsFalse(selfEmployedCalculatorPage.EleButtonViewKiwiSaverRetirementProjections.Displayed);

            Assert.IsTrue(selfEmployedCalculatorPage.EleResultValue.Displayed);

            Assert.IsTrue(selfEmployedCalculatorPage.EleResultValue.Text.Contains("259,581"));
        }

        [Test]
        public void NotEmployedCustomerCalculationTest()
        {
            utils.ClickInIframe(Driver, calculatorHomePage.EleDropDownArrowEmploymentStatus);

            Thread.Sleep(3000);
            utils.ClickInIframe(Driver, calculatorHomePage.EleEmploymentStatusNotEmployedOption);

            Assert.IsFalse(notEmployedCalculatorPage.EleButtonViewKiwiSaverRetirementProjections.Enabled);

            notEmployedCalculatorPage.EleInputCurrentAge.SendKeys("55");
            notEmployedCalculatorPage.EleInputCurrentKiwiSaverBalance.SendKeys("140000");
            notEmployedCalculatorPage.EleInputVoluntaryContributions.SendKeys("10");

            utils.ClickInIframe(Driver, calculatorHomePage.EleDropDownArrowVoluntaryConditionsFrequency);

            Thread.Sleep(3000);
            utils.ClickInIframe(Driver, calculatorHomePage.EleVoluntaryContributionsAnnuallyOption);

            notEmployedCalculatorPage.EleOptionRiskProfileBalanced.Click();

            notEmployedCalculatorPage.EleInputSavingsGoalAtRetirement.SendKeys("200000");

            Assert.IsTrue(notEmployedCalculatorPage.EleButtonViewKiwiSaverRetirementProjections.Enabled);

            notEmployedCalculatorPage.EleButtonViewKiwiSaverRetirementProjections.Click();

            Assert.IsFalse(notEmployedCalculatorPage.EleButtonViewKiwiSaverRetirementProjections.Displayed);

            Assert.IsTrue(notEmployedCalculatorPage.EleResultValue.Displayed);

            Assert.IsTrue(notEmployedCalculatorPage.EleResultValue.Text.Contains("197,679"));
        }

        [TearDown]
        public void Close()
        {
            Driver.Quit();
        }
    }
}
