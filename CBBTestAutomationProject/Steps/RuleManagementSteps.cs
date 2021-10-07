using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace CBBTestAutomationProject.Steps
{
    [Binding]
    public class RuleManagementSteps
    {
        IWebDriver driver = new ChromeDriver();
        [When(@"I Edit a Logic Management Record")]
        public void WhenIEditALogicManagementRecord()
        {
            driver.Navigate().GoToUrl("https://cbb-dev.uhc.com");
            driver.FindElement(By.Id("MainContent_lnkRuleMgmt")).Click();
            SelectElement s = new SelectElement(driver.FindElement(By.Id("ddlDocType")));
            s.SelectByValue("10");
            driver.FindElements(By.CssSelector("a[data-original-title=\"Edit\"]"))[0].Click();
            Assert.IsTrue(driver.Url.Contains("https://cbb-dev.uhc.com/LogicMgmt?"));
        }
        
        [Then(@"I can Add a Rule for an Existing Data Pointer")]
        public void ThenICanAddARuleForAnExistingDataPointer()
        {
            driver.FindElements(By.CssSelector("a[data-original-title=\"Add\"]"))[0].Click();
            driver.SwitchTo().Alert().Accept();
        }
        
        [Then(@"I can Edit an Existing Rule for Data Pointer")]
        public void ThenICanEditAnExistingRuleForDataPointer()
        {
            driver.FindElements(By.CssSelector("a[data-original-title=\"Edit\"]"))[0].Click();
            Thread.Sleep(1000);
            Assert.IsTrue(driver.Url.Contains("https://cbb-dev.uhc.com/LogicMgmtEdit?"));
            driver.Close();
        }
    }
}
