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
    public class EditLogicinRuleManagementPlanPeriodSteps
    {
        IWebDriver driver = new ChromeDriver();
        [When(@"I Edit an Existing Rule for Data Pointer in the Plan Period tab")]
        public void WhenIEditAnExistingRuleForDataPointer()
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(30000);
            driver.Navigate().GoToUrl("https://cbb-dev.uhc.com");
            driver.FindElement(By.Id("MainContent_lnkRuleMgmt")).Click();
            SelectElement s = new SelectElement(driver.FindElement(By.Id("ddlPlanType")));
            s.SelectByValue("1");
            driver.FindElements(By.CssSelector("a[data-original-title=\"Edit\"]"))[0].Click();//In Rule Management page
            Assert.IsTrue(driver.Url.Contains("https://cbb-dev.uhc.com/LogicMgmt2.aspx?"));
            Thread.Sleep(1000);
            driver.FindElement(By.Id("lnkPlanPeriod")).Click();//When Plan Period tab is clicked
            driver.FindElement(By.Id("MainContent_gvHeader_lnkEditRules_0")).Click();//When a specific rule is edited
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement SearchResult = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("RuleEditModalLabel")));
            Assert.IsTrue(SearchResult.Displayed);
        }
        
        [Then(@"I can be able to Change Logic in the modal")]
        public void ThenICanBeAbleToChangeLogic()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('MainContent_ctrl_RuleEditor_editor2').value = 'a';");
            driver.FindElement(By.Id("MainContent_ctrl_RuleEditor_LinkSaveEditedRule")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.PollingInterval.Add(TimeSpan.FromSeconds(5));
            IWebElement SearchResult = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("MainContent_ctrl_RuleEditor_lnkSaveAndClose")));
            Assert.IsTrue(SearchResult.Displayed);
            js.ExecuteScript("document.getElementById('MainContent_ctrl_RuleEditor_editor2').value = 'If @ACU_T2_COINS IS NULL Begin Set @Result = @ACU_T2_COINS End Else Begin Set @Result = @PCP_T2_COINS End	';");
        }

        [Then(@"Save the Data Pointer Rule in Plan Period tab")]
        public void ThenSaveTheDataPointerRule()
        {
            driver.FindElement(By.Id("MainContent_ctrl_RuleEditor_lnkSaveAndClose")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.PollingInterval.Add(TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("lblToastTitle")));
            Assert.AreEqual(driver.FindElement(By.Id("lblToastTitle")).Text, "Plan Period");
            //Assert.AreEqual(driver.FindElement(By.Id("lblToastMsg")).Text, "Saved successfully.");
            driver.Close();
        }
    }
}
