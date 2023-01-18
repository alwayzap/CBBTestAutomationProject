using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace CBBTestAutomationProject.Features
{
    [Binding]
    public class MassUpdateinRuleManagementSteps
    {
        IWebDriver driver = new ChromeDriver();
        [When(@"I Edit an Existing Rule for Data Pointer and Change Logic")]
        public void WhenIEditAnExistingRuleForDataPointerAndChangeLogic()
        {
            // code to edit a rule and change logic
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://cbb-dev.uhc.com");
            driver.FindElement(By.Id("MainContent_lnkRuleMgmt")).Click();
            SelectElement s = new SelectElement(driver.FindElement(By.Id("ddlState")));
            s.SelectByValue("10");
            Thread.Sleep(1000);
            driver.FindElements(By.CssSelector("a[data-original-title=\"Edit\"]"))[0].Click();//In Rule Management page
            Thread.Sleep(1000);
            Assert.IsTrue(driver.Url.Contains("https://cbb-dev.uhc.com/LogicMgmt2.aspx?"));
            driver.FindElement(By.Id("tabDetails")).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            if (driver.FindElement(By.Id("chkSE")).Selected)
            {
                js.ExecuteScript("document.getElementById('chkSE').click();");
                Assert.IsFalse(driver.FindElement(By.Id("chkSE")).Selected);
            }
            else
            {
                js.ExecuteScript("document.getElementById('chkSE').click();");
                Assert.IsTrue(driver.FindElement(By.Id("chkSE")).Selected);
            }
            js.ExecuteScript("document.getElementById('ddlLevel').value = \"3\"");
            js.ExecuteScript("document.getElementById('btnSaveDetails').click();");
        }
        
        [When(@"Mass Update by Selecting Multiple Rules")]
        public void WhenMassUpdateBySelectingMultipleRules()
        {
            driver.FindElement(By.Id("tabMassUpdate")).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('btnMU_SelectAll').click();");
            js.ExecuteScript("document.getElementById('btnMassUpdate').click();");
            driver.SwitchTo().Alert().Accept();
        }

        [Then(@"Logic is Updated in Selected Rules")]
        public void ThenLogicIsUpdatedInSelectedRules()
        {
            //ScenarioContext.Current.Pending();
            driver.Quit();
        }
    }
}
