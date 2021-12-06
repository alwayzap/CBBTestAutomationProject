using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace CBBTestAutomationProject.Steps
{
    [Binding]
    public class BenefitManagementTableSteps
    {
        
        IWebDriver driver = new ChromeDriver();
               
        [When(@"I am on the CBBBenefitMgmt page")]
        public void WhenIAmOnTheCBBBenefitMgmtPage()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://cbb-dev.uhc.com");
            driver.FindElement(By.Id("MainContent_lnkBenefitStateMgmt")).Click();
        }
        
        [Then(@"I should be able to see a table with all the groups of Benefit Categories by COC Series, Organization, State, and Segment pre-build in Plan Builder")]
        public void ThenIShouldBeAbleToSeeATableWithAllTheGroupsOfBenefitCategoriesByCOCSeriesOrganizationStateAndSegmentPre_BuildInPlanBuilder()
        {
            Assert.AreEqual("https://cbb-dev.uhc.com/BenefitMgmt", driver.Url);
            Assert.AreEqual("table",driver.FindElement(By.Id("gvBenefitMgmt")).TagName);
            
        }

        [Then(@"I should be able to filter the table by COC Series, Organization, State and Segment")]
        public void ThenIShouldBeAbleToFilterTheTableByCOCSeriesOrganizationStateAndSegment()
        {
            Assert.AreEqual("select", driver.FindElement(By.Id("ddlCOC")).TagName);
            Assert.AreEqual("select", driver.FindElement(By.Id("ddlOrg")).TagName);
            Assert.AreEqual("select", driver.FindElement(By.Id("ddlState")).TagName);
            Assert.AreEqual("select", driver.FindElement(By.Id("ddlSegment")).TagName);
            SelectElement oSelect1 = new SelectElement(driver.FindElement(By.Id("ddlCOC")));
            oSelect1.SelectByIndex(1);
            SelectElement oSelect2 = new SelectElement(driver.FindElement(By.Id("ddlOrg")));
            oSelect2.SelectByIndex(1);
            SelectElement oSelect3 = new SelectElement(driver.FindElement(By.Id("ddlState")));
            oSelect3.SelectByIndex(1);
            SelectElement oSelect4 = new SelectElement(driver.FindElement(By.Id("ddlSegment")));
            oSelect4.SelectByIndex(2);
            
        }

        [Then(@"I should be able to click the edit button to open the CBBManageBenefit page for the selected COC Series, Organization, State, and Segment")]
        public void ThenIShouldBeAbleToClickTheEditButtonToOpenTheCBBManageBenefitPageForTheSelectedCOCSeriesOrganizationStateAndSegment()
        {
            Assert.IsNotNull(driver.FindElement(By.LinkText("COC Series")));
            Assert.IsNotNull(driver.FindElement(By.LinkText("Organization")));
            Assert.IsNotNull(driver.FindElement(By.LinkText("State")));
            Assert.IsNotNull(driver.FindElement(By.LinkText("Segment")));
            driver.FindElement(By.CssSelector("a[class=\"btn btn-outline-primary\"]")).Click();
            Assert.IsTrue(driver.Url.Contains("https://cbb-dev.uhc.com/ManageBenefits?ID="));
            driver.Close();
        }

        [When(@"I should be able to click the deactivate button for one of the records")]
        public void WhenIShouldBeAbleToClickTheDeactivateButtonForOneOfTheRecords()
        {
            driver.FindElement(By.CssSelector("a[class=\"btn btn-outline-danger\"]")).Click();
        }

        [When(@"I should be able to select the Show Deactivated checkbox")]
        public void WhenIShouldBeAbleToSelectTheShowDeactivatedCheckbox()
        {
            driver.FindElement(By.Id("chkShowDeactivated")).Click();
        }

        [Then(@"I should see deactivated records")]
        public void ThenIShouldSeeDeactivatedRecords()
        {
            Assert.IsNotNull(driver.FindElement(By.LinkText("COC Series")));
            Assert.IsNotNull(driver.FindElement(By.LinkText("Organization")));
            Assert.IsNotNull(driver.FindElement(By.LinkText("State")));
            Assert.IsNotNull(driver.FindElement(By.LinkText("Segment")));
        }

        [Then(@"I should be able to reactivate a deleted record")]
        public void ThenIShouldBeAbleToReactivateADeletedRecord()
        {
            driver.FindElement(By.CssSelector("a[class=\"btn btn-outline-success\"]")).Click();
            driver.Close();
        }


    }
}
