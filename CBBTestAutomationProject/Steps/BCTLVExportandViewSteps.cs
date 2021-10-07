using TechTalk.SpecFlow;
using CBBTestAutomationProject.HelperClasses;
using OpenQA.Selenium;
using System.Linq;
using NUnit.Framework;
using System.Threading;
using System.IO;

namespace CBBTestAutomationProject.Steps
{
    [Binding]
    public class BCTLVExportandViewSteps
    {
        PortfolioFieldsSteps p = new PortfolioFieldsSteps();

        [When(@"I performed a Plan Search")]
        public void WhenIPerformedAPlanSearch()
        {
            p.WhenIVePerformedAPlanSearch();
        }
        
        [When(@"results are returned from the search")]
        public void WhenResultsAreReturnedFromTheSearch()
        {
            p.WhenResultsReturnedFromTheSearch();
            // Generate BCLTV for selected rows first and wait few seconds
            /*
            p.plan.driver.FindElement(By.Id("cbSelect")).Click();
            Console.WriteLine(p.plan.driver.FindElement(By.Id("cbSelect")).Enabled);
            p.plan.driver.FindElement(By.Id("btnGenerateBCTLV")).Click();
            p.plan.driver.FindElement(By.Id("btnLGConfirm")).Click();
            Thread.Sleep(5000);
            */
        }
        
        [When(@"I have clicked on View menu")]
        public void WhenIHaveClickedOnViewMenu()
        {
            p.WhenIVeClickedOnTheViewMenu();
        }
        
        [When(@"I selected the BCTLV - Digital drop down")]
        public void WhenISelectedTheBCTLV_DigitalDropDown()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)p.plan.driver;
            js.ExecuteScript("document.getElementById('cblPlanBatchTypes_0').click();");
            js.ExecuteScript("document.getElementsByClassName('from-group col-6')[0].getElementsByClassName('btn btn-outline-primary btn-block btn-text-primary')[0].click();");
        }
        
        [When(@"I selected the BCTLV Data - Excel drop down")]
        public void WhenISelectedTheBCTLVData_ExcelDropDown()
        {
            //Code to Remove existing files starting with PlanDetails from downloads folder
            string Path = System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";
            string[] filePaths = Directory.GetFiles(Path);
            foreach (string p in filePaths)
            {
                if (p.Contains("PlanDetails"))
                {
                    File.Delete(p);
                }
            }
            //end code
            IJavaScriptExecutor js = (IJavaScriptExecutor)p.plan.driver;
            js.ExecuteScript("document.getElementById('cblPlanBatchTypes_0').click();");
            js.ExecuteScript("document.getElementsByClassName('btn btn-outline-success btn-block btn-text-success')[0].click();");
        }
        
        [Then(@"a new window should open with the BCTLV Data for the given cirrusPlanID should be displayed in an Handsontable table")]
        public void ThenANewWindowShouldOpenWithTheBCTLVDataForTheGivenCirrusPlanIDShouldBeDisplayedInAnHandsontableTable()
        {
            string s = p.plan.driver.FindElement(By.Id("hfPlanAssignmentID")).GetAttribute("value");
            Thread.Sleep(6000);
            Assert.AreEqual(p.plan.driver.SwitchTo().Window(p.plan.driver.WindowHandles.ElementAt(1)).Url, ("https://cbb-dev.uhc.com/ViewPlanData.aspx?ID=" + s + "&PlanDataRequested=BV"));
            p.plan.driver.Quit();
        }
        
        [Then(@"a new window should open with the BCTLV Data for the given cirrusPlanID should be displayed in an Excel document")]
        public void ThenANewWindowShouldOpenWithTheBCTLVDataForTheGivenCirrusPlanIDShouldBeDisplayedInAnExcelDocument()
        {
            Thread.Sleep(5000);
            Assert.IsTrue(CheckFileDownloaded.CheckFileDownload("PlanDetails.xlsx"));
            p.plan.driver.Close();
        }
    }
}
