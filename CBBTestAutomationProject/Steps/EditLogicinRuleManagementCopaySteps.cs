using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using SeleniumExtras.WaitHelpers;

namespace CBBTestAutomationProject.Steps
{
    [Binding]
    public class EditLogicinRuleManagementCopaySteps
    {
        IWebDriver driver = new ChromeDriver();
        [When(@"I Edit an Existing Rule for Data Pointer in the Copay tab")]
        public void WhenIEditAnExistingRuleForDataPointerInTheCopayTab()
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
            driver.FindElement(By.Id("lnkCopay")).Click();//When Copay tab is clicked
            driver.FindElement(By.Id("MainContent_gvCopay_lnkEditCopay_0")).Click();//When a specific rule is edited
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement SearchResult = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("addCopaymodalLabel")));
            Assert.IsTrue(SearchResult.Displayed);
        }

        [Then(@"I can be able to Change Logic for fields in the Copay modal")]
        public void ThenICanBeAbleToChangeLogicForFieldsInTheCopayModal()
        {

            driver.FindElement(By.Id("MainContent_lnkEditCopaymentID")).Click();//When Copay ID field is edited
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement SearchResult = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("RuleEditModalLabel")));
            Assert.IsTrue(SearchResult.Displayed);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('MainContent_ctrl_RuleEditor_editor2').value = 'If @ACU_T2_COINS IS NULL Begin Set @Result = @ACU_T2_COINS End Else Begin Set @Result = @PCP_T2_COINS End	';");
        }


        [Then(@"Save the Data Pointer Rule in Copay tab")]
        public void ThenSaveTheDataPointerRuleInCopayTab()
        {
            driver.FindElement(By.Id("MainContent_ctrl_RuleEditor_lnkSaveAndClose")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.PollingInterval.Add(TimeSpan.FromSeconds(5));
            IWebElement SearchResult = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("MainContent_lnkSaveCopay")));
            SearchResult.Click();
            Assert.AreEqual(driver.FindElement(By.Id("lblToastTitle")).Text, "Plan Copay");
            Assert.AreEqual(driver.FindElement(By.Id("lblToastMsg")).Text, "Saved successfully.");
            driver.Close();
        }
    }
}
