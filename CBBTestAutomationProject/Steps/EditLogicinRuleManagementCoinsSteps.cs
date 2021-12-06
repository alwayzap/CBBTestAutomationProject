using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;

namespace CBBTestAutomationProject.Steps
{
    [Binding]
    public class EditLogicinRuleManagementCoinsSteps
    {
        IWebDriver driver = new ChromeDriver();
        [When(@"I Edit an Existing Rule for Data Pointer in the Coins tab")]
        public void WhenIEditAnExistingRuleForDataPointerInTheCoinsTab()
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
            driver.FindElement(By.Id("lnkCoins")).Click();//When Coins tab is clicked
            driver.FindElement(By.Id("MainContent_gvCoins_lnkEditCoins_0")).Click();//When a specific rule is edited
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement SearchResult = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("addCoinsmodalLabel")));
            Assert.IsTrue(SearchResult.Displayed);
        }
        
        [Then(@"I can be able to Change Logic for fields in the Coins modal")]
        public void ThenICanBeAbleToChangeLogicForFieldsInTheCoinsModal()
        {
            driver.FindElement(By.Id("MainContent_lnkEditCoinsuranceID")).Click();//When Coins ID field is edited
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement SearchResult = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("RuleEditModalLabel")));
            Assert.IsTrue(SearchResult.Displayed);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('MainContent_ctrl_RuleEditor_editor2').value = 'If @ACU_T2_COINS IS NULL Begin Set @Result = @ACU_T2_COINS End Else Begin Set @Result = @PCP_T2_COINS End	';");
        }
        
        [Then(@"Save the Data Pointer Rule in Coins tab")]
        public void ThenSaveTheDataPointerRuleInCoinsTab()
        {
            driver.FindElement(By.Id("MainContent_ctrl_RuleEditor_lnkSaveAndClose")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.PollingInterval.Add(TimeSpan.FromSeconds(5));
            IWebElement SearchResult = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("MainContent_lnkSaveCoins")));
            SearchResult.Click();
            Assert.AreEqual(driver.FindElement(By.Id("lblToastTitle")).Text, "Plan Coins");
            Assert.AreEqual(driver.FindElement(By.Id("lblToastMsg")).Text, "Saved successfully.");
            driver.Close();
        }
    }
}
