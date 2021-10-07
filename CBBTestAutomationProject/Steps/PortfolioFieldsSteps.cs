using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using CBBTestAutomationProject.Steps;
using System.Linq;
using NUnit.Framework;
using CBBTestAutomationProject.HelperClasses;
using System.Threading;

namespace CBBTestAutomationProject.Steps
{
    [Binding]
    public class PortfolioFieldsSteps
    {
        public BasicAndAdvancedSearchInBCTLVGenerationPageSteps plan = new BasicAndAdvancedSearchInBCTLVGenerationPageSteps();

        [When(@"I’ve performed a Plan Search")]
        public void WhenIVePerformedAPlanSearch()
        {
            plan.WhenIEnterAValidPlanCodeOnTheStandardSearchTab();
            plan.WhenIClickSearch();
        }
        
        [When(@"results returned from the search")]
        public void WhenResultsReturnedFromTheSearch()
        {
            plan.WhenAResultIsFoundInTheDBSDatabase();
        }
        
        [When(@"I’ve clicked on the View menu")]
        public void WhenIVeClickedOnTheViewMenu()
        {
            plan.driver.Manage().Window.Maximize();
            plan.driver.FindElement(By.Id("btnPlanActions")).Click();
        }
        
        [When(@"I selected the Portfolio Fields - Digital drop down")]
        public void WhenISelectedThePortfolioFields_DigitalDropDown()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)plan.driver;
            js.ExecuteScript("document.getElementById('cblPlanBatchTypes_7').click();");
            js.ExecuteScript("document.getElementsByClassName('from-group col-6')[0].getElementsByClassName('btn btn-outline-primary btn-block btn-text-primary')[0].click();");
        }
        
        [When(@"I selected the Portfolio Fields - Excel drop down")]
        public void WhenISelectedThePortfolioFields_ExcelDropDown()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)plan.driver;
            js.ExecuteScript("document.getElementById('cblPlanBatchTypes_7').click();");
            js.ExecuteScript("document.getElementsByClassName('btn btn-outline-success btn-block btn-text-success')[0].click();");
        }
        
        [Then(@"a new window should open with the Portfolio Fields for the given planAssignmentID should be displayed in a Handsontable table")]
        public void ThenANewWindowShouldOpenWithThePortfolioFieldsForTheGivenPlanAssignmentIDShouldBeDisplayedInAHandsontableTable()
        {
            string s = plan.driver.FindElement(By.Id("hfPlanAssignmentID")).GetAttribute("value");
            Assert.AreEqual(plan.driver.SwitchTo().Window(plan.driver.WindowHandles.ElementAt(1)).Url,("https://cbb-dev.uhc.com/ViewPlanData.aspx?ID=" + s + "&PlanDataRequested=PF"));
            plan.driver.Quit();
        }
        
        [Then(@"a new window should open with the Portfolio Fields for the given planAssignmentID should be displayed in an Excel document")]
        public void ThenANewWindowShouldOpenWithThePortfolioFieldsForTheGivenPlanAssignmentIDShouldBeDisplayedInAnExcelDocument()
        {
            Thread.Sleep(6000);
            Assert.IsTrue(CheckFileDownloaded.CheckFileDownload("PlanDetails.xlsx"));
            plan.driver.Close();
        }
    }
}
