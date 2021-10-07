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
    public class EditLogicinRuleManagementPlanTierSteps
    {
        IWebDriver driver = new ChromeDriver();
        [When(@"I Edit an Existing Rule for Data Pointer in the Plan Tier tab")]
        public void WhenIEditAnExistingRuleForDataPointerInThePlanTierTab()
        {
            driver.Navigate().GoToUrl("https://cbb-dev.uhc.com");
            driver.FindElement(By.Id("MainContent_lnkRuleMgmt")).Click();
            SelectElement s = new SelectElement(driver.FindElement(By.Id("ddlState")));
            s.SelectByValue("56"); // Select WA state
            Thread.Sleep(1000);
            SelectElement s1 = new SelectElement(driver.FindElement(By.Id("ddlProduct")));
            s1.SelectByValue("5"); // Select Choice Plus product
            Thread.Sleep(1000);
            driver.FindElements(By.CssSelector("a[data-original-title=\"Edit\"]"))[0].Click();//In Rule Management page
            Assert.IsTrue(driver.Url.Contains("https://cbb-dev.uhc.com/LogicMgmt2.aspx?"));
            Thread.Sleep(1000);
            driver.FindElement(By.Id("lnkTiers")).Click();//When Tiers tab is clicked
            driver.FindElement(By.Id("MainContent_gvTiers_lnkEditTier_0")).Click();//When a specific rule is edited
            Thread.Sleep(3000);
            Assert.IsTrue(driver.FindElement(By.Id("tierNetworkLabel")).Displayed);
        }
        
        [Then(@"I can be able to Change Logic for fields in the Tier modal")]
        public void ThenICanBeAbleToChangeLogicForFieldsInTheTierModal()
        {
            driver.FindElement(By.Id("MainContent_btnEditTNtierNumber")).Click();//When Tier Number field is edited
            Thread.Sleep(4000);
            Assert.IsTrue(driver.FindElement(By.Id("RuleEditModalLabel")).Displayed);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('MainContent_ctrl_RuleEditor_editor2').value = 'If @ACU_T2_COINS IS NULL Begin Set @Result = @ACU_T2_COINS End Else Begin Set @Result = @PCP_T2_COINS End	';");
        }
        
        [Then(@"Save the Data Pointer Rule in Plan Tier tab")]
        public void ThenSaveTheDataPointerRuleInPlanTierTab()
        {
            driver.FindElement(By.Id("MainContent_ctrl_RuleEditor_lnkSaveAndClose")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("MainContent_lnkTierSave")).Click();
            Assert.AreEqual(driver.FindElement(By.Id("lblToastTitle")).Text, "Tier Network Assignment");
            Assert.AreEqual(driver.FindElement(By.Id("lblToastMsg")).Text, "Saved successfully.");
            driver.Close();
        }
    }
}
