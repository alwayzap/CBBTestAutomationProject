using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
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
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(30000);
            driver.Navigate().GoToUrl("https://cbb-dev.uhc.com");
            driver.FindElement(By.Id("MainContent_lnkRuleMgmt")).Click();
            SelectElement s = new SelectElement(driver.FindElement(By.Id("ddlState")));
            s.SelectByValue("56"); // Select WA state
            SelectElement s1 = new SelectElement(driver.FindElement(By.Id("ddlProduct")));
            s1.SelectByValue("5"); // Select Choice Plus product
            driver.FindElements(By.CssSelector("a[data-original-title=\"Edit\"]"))[0].Click();//In Rule Management page
            Assert.IsTrue(driver.Url.Contains("https://cbb-dev.uhc.com/LogicMgmt2.aspx?"));
            driver.FindElement(By.Id("lnkTiers")).Click();//When Tiers tab is clicked
            driver.FindElement(By.Id("MainContent_gvTiers_lnkEditTier_0")).Click();//When a specific rule is edited
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement SearchResult = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("MainContent_txtTNtierNumber")));
            Assert.IsTrue(SearchResult.Displayed);
        }
        
        [Then(@"I can be able to Change Logic for fields in the Tier modal")]
        public void ThenICanBeAbleToChangeLogicForFieldsInTheTierModal()
        {
            driver.FindElement(By.Id("MainContent_btnEditTNtierNumber")).Click();//When Tier Number field is edited
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement SearchResult = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("RuleEditModalLabel")));
            Assert.IsTrue(SearchResult.Displayed);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('MainContent_ctrl_RuleEditor_editor2').value = 'If @ACU_T2_COINS IS NULL Begin Set @Result = @ACU_T2_COINS End Else Begin Set @Result = @PCP_T2_COINS End	';");
        }
        
        [Then(@"Save the Data Pointer Rule in Plan Tier tab")]
        public void ThenSaveTheDataPointerRuleInPlanTierTab()
        {
            driver.FindElement(By.Id("MainContent_ctrl_RuleEditor_lnkSaveAndClose")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.PollingInterval.Add(TimeSpan.FromSeconds(5));
            IWebElement SearchResult = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("MainContent_lnkTierSave")));
            SearchResult.Click();
            Assert.AreEqual(driver.FindElement(By.Id("lblToastTitle")).Text, "Tier Network Assignment");
            Assert.AreEqual(driver.FindElement(By.Id("lblToastMsg")).Text, "Saved successfully.");
            driver.Close();
        }
    }
}
