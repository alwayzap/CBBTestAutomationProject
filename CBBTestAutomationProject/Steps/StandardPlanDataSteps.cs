using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using CBBTestAutomationProject.HelperClasses;
using CBBTestAutomationProject.Steps;
using System.Linq;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Chrome;

namespace CBBTestAutomationProject.Steps
{
    [Binding]
    public class StandardPlanDataSteps
    {
        PortfolioFieldsSteps p = new PortfolioFieldsSteps();

        [When(@"I have performed a Plan Search")]
        public void WhenIHavePerformedAPlanSearch()
        {
            p.WhenIVePerformedAPlanSearch();
        }

        [When(@"results have returned from the search")]
        public void WhenResultsHaveReturnedFromTheSearch()
        {
            p.WhenResultsReturnedFromTheSearch();
        }

        [When(@"I have clicked on the View menu")]
        public void WhenIHaveClickedOnTheViewMenu()
        {
            p.WhenIVeClickedOnTheViewMenu();
        }

        [When(@"I selected the Standard Plan Data - Digital drop down")]
        public void WhenISelectedTheStandardPlanData_DigitalDropDown()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)p.plan.driver;
            js.ExecuteScript("document.getElementById('cblPlanBatchTypes_9').click();");
            js.ExecuteScript("document.getElementsByClassName('from-group col-6')[0].getElementsByClassName('btn btn-outline-primary btn-block btn-text-primary')[0].click();");
        }
        
        [When(@"I selected the Standard Plan Data - Excel drop down")]
        public void WhenISelectedTheStandardPlanData_ExcelDropDown()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)p.plan.driver;
            js.ExecuteScript("document.getElementById('cblPlanBatchTypes_9').click();");
            js.ExecuteScript("document.getElementsByClassName('btn btn-outline-success btn-block btn-text-success')[0].click();");
        }
        
        [Then(@"a new window should open with the Standard Plan Data for the given digitalBenefitId should be displayed in an Handsontable table")]
        public void ThenANewWindowShouldOpenWithTheStandardPlanDataForTheGivenDigitalBenefitIdShouldBeDisplayedInAnHandsontableTable()
        {
            string s = p.plan.driver.FindElement(By.Id("hfPlanAssignmentID")).GetAttribute("value");
            Assert.AreEqual(p.plan.driver.SwitchTo().Window(p.plan.driver.WindowHandles.ElementAt(1)).Url, ("https://cbb-dev.uhc.com/ViewPlanData.aspx?ID=" + s + "&PlanDataRequested=SP"));
            p.plan.driver.Quit();
        }

        [Then(@"a new window should open with the Standard Plan Data for the given planAssignmentID should be displayed in an Excel document")]
        public void ThenANewWindowShouldOpenWithTheStandardPlanDataForTheGivenPlanAssignmentIDShouldBeDisplayedInAnExcelDocument()
        {
            Thread.Sleep(6000);
            Assert.IsTrue(CheckFileDownloaded.CheckFileDownload("PlanDetails.xlsx"));
            p.plan.driver.Close();
        }
    }
}
