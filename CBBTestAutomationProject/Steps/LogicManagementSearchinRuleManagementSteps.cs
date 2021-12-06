using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace CBBTestAutomationProject.Steps
{
    [Binding]
    public class LogicManagementSearchinRuleManagementSteps
    {
        IWebDriver driver = new ChromeDriver();
        
        [When(@"I click on the Rule Management button in the Home page")]
        public void WhenIClickOnTheRuleManagementButtonInTheHomePage()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://cbb-dev.uhc.com");
            driver.FindElement(By.Id("MainContent_lnkRuleMgmt")).Click();
        }
        
        [When(@"I select one of the options from the displayed dropdowns")]
        public void WhenISelectOneOfTheOptionsFromTheDisplayedDropdowns()
        {
            SelectElement s = new SelectElement(driver.FindElement(By.Id("ddlPlanType")));
            s.SelectByValue("1");
        }
        
        [Then(@"Standard Logic Management page is displayed")]
        public void ThenStandardLogicManagementPageIsDisplayed()
        {
            Assert.AreEqual(driver.Url, "https://cbb-dev.uhc.com/LogicMgmtSearch.aspx");
        }
        
        [Then(@"Logic Management records are displayed based on the Selection")]
        public void ThenLogicManagementRecordsAreDisplayedBasedOnTheSelection()
        {
            Assert.AreEqual("table", driver.FindElement(By.Id("gvLogicMgmt")).TagName);
            Assert.IsNotNull(driver.FindElement(By.LinkText("Plan Type")));
            
        }

        [Then(@"Option to Edit, Clone, View, and Deactivate are displayed for each record")]
        public void ThenOptionToEditCloneViewAndDeactivateAreDisplayedForEachRecord()
        {
            Assert.IsNotNull(driver.FindElements(By.CssSelector("a[data-original-title=\"Edit\"]"))[0]);
            Assert.IsNotNull(driver.FindElements(By.Id("btnClone"))[0]);
            Assert.IsNotNull(driver.FindElements(By.Id("btnShowCloneHistory"))[0]);
            Assert.IsNotNull(driver.FindElements(By.Id("btnActivate"))[0]);
            driver.Close();
        }
    }
}
