using System;
using TechTalk.SpecFlow;
using CBBTestAutomationProject.HelperClasses;
using CBBTestAutomationProject.Steps;
using OpenQA.Selenium;
using System.Linq;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace CBBTestAutomationProject.Steps
{
    [Binding]
    public class BCTLVGenerationSteps
    {
        PortfolioFieldsSteps p = new PortfolioFieldsSteps();
        public static string s;
                
        [When(@"I performed Plan Search")]
        public void WhenIPerformedPlanSearch()
        {
            p.WhenIVePerformedAPlanSearch();
        }

        [When(@"results are returned from search")]
        public void WhenResultsAreReturnedFromSearch()
        {
            p.WhenResultsReturnedFromTheSearch();
        }

        [When(@"I’ve checked the checkbox next to a Medical Plan")]
        public void WhenIVeCheckedTheCheckboxNextToAMedicalPlan()
        {
            p.plan.driver.FindElement(By.Id("cbSelect")).Click();
        }
        
        [When(@"I’ve clicked the Generate BCTLV button")]
        public void WhenIVeClickedTheGenerateBCTLVButton()
        {
 //Changed the code to match the dropdown after adding Plan generation by algorithm. select value 1 for Rule based. Select 2 for Algorithm based.
            SelectElement se = new SelectElement(p.plan.driver.FindElement(By.Id("ddlStdGenerate")));
            se.SelectByValue("1");
            p.plan.driver.FindElement(By.Id("btnLGConfirm")).Click();
        }

        [Then(@"the BCTLV Generation Service should transform the plans Standard Plan Data from DBS into the BCTLV Data Structure")]
        public void ThenTheBCTLVGenerationServiceShouldTransformThePlansStandardPlanDataFromDBSIntoTheBCTLVDataStructure()
        {
            Assert.AreEqual(p.plan.driver.FindElement(By.Id("lblToastTitle")).Text, "Plan Generation");
            Console.WriteLine(p.plan.driver.FindElement(By.Id("lblToastMsg")).Text.Trim());
            s = p.plan.driver.FindElement(By.Id("lblToastMsg")).Text.Split(" ").ElementAt(1);
            Console.WriteLine(s);
            p.plan.driver.Close();
        }
    }
}
