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
    public class EditLogicinRuleManagementPlanSettingsSteps
    {
        IWebDriver driver = new ChromeDriver();
        [When(@"I Edit an Existing Rule for Data Pointer in the Plan Settings tab")]
        public void WhenIEditAnExistingRuleForDataPointerInThePlanSettingsTab()
        {
            driver.Navigate().GoToUrl("https://cbb-dev.uhc.com");
            driver.FindElement(By.Id("MainContent_lnkRuleMgmt")).Click();
            SelectElement s = new SelectElement(driver.FindElement(By.Id("ddlPlanType")));
            s.SelectByValue("1");
            Thread.Sleep(1000);
            driver.FindElements(By.CssSelector("a[data-original-title=\"Edit\"]"))[0].Click();//In Rule Management page
            Assert.IsTrue(driver.Url.Contains("https://cbb-dev.uhc.com/LogicMgmt2.aspx?"));
            Thread.Sleep(1000);
            driver.FindElement(By.Id("lnkPlanSettings")).Click();//When Plan Settings tab is clicked
            driver.FindElement(By.Id("MainContent_gvHeader_lnkEditRules_0")).Click();//When a specific rule is edited
            Thread.Sleep(5000);
            Assert.IsTrue(driver.FindElement(By.Id("RuleEditModalLabel")).Displayed);
        }
        
        [Then(@"I can be able to Change Logic in the settings modal")]
        public void ThenICanBeAbleToChangeLogicInTheSettingsModal()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('MainContent_ctrl_RuleEditor_editor2').value = 'If @ACU_T2_COINS IS NULL Begin Set @Result = @ACU_T2_COINS End Else Begin Set @Result = @PCP_T2_COINS End	';");
        }
        
        [Then(@"Save the Data Pointer Rule in Plan Settings tab")]
        public void ThenSaveTheDataPointerRuleInPlanSettingsTab()
        {
            driver.FindElement(By.Id("MainContent_ctrl_RuleEditor_lnkSaveAndClose")).Click();
            Thread.Sleep(5000);
            Assert.AreEqual(driver.FindElement(By.Id("lblToastTitle")).Text, "Plan Settings");
            Assert.AreEqual(driver.FindElement(By.Id("lblToastMsg")).Text, "Saved successfully.");
            driver.Close();
        }
    }
}
