using CBBTestAutomationProject.HelperClasses;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace CBBTestAutomationProject.Steps
{
    [Binding]
    public class ManageBenefitsPageSteps
    {

        IWebDriver driver = new ChromeDriver();
        
        [When(@"I’m on the CBBManageBenefits page")]
        public void WhenIMOnTheCBBManageBenefitsPage()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://cbb-dev.uhc.com");
            driver.FindElement(By.Id("MainContent_lnkBenefitStateMgmt")).Click();
            SelectElement oSelect1 = new SelectElement(driver.FindElement(By.Id("ddlCOC")));
            oSelect1.SelectByIndex(1);
            SelectElement oSelect2 = new SelectElement(driver.FindElement(By.Id("ddlOrg")));
            oSelect2.SelectByIndex(1);
            SelectElement oSelect3 = new SelectElement(driver.FindElement(By.Id("ddlState")));
            oSelect3.SelectByIndex(1);
            SelectElement oSelect4 = new SelectElement(driver.FindElement(By.Id("ddlSegment")));
            oSelect4.SelectByIndex(2);
            driver.FindElement(By.CssSelector("a[class=\"btn btn-outline-primary\"]")).Click();
        }
        
        [Then(@"I should be able to see a table with all the Benefit Categories for the COC Series, Organization, State and Segment selected")]
        public void ThenIShouldBeAbleToSeeATableWithAllTheBenefitCategoriesForTheCOCSeriesOrganizationStateAndSegmentSelected()
        {
            Assert.AreEqual("table", driver.FindElement(By.Id("gvBenefits")).TagName);
        }
        
        [Then(@"I should be able select one or more Benefit Codes to map back to the Benefit Categories displayed")]
        public string[] ThenIShouldBeAbleSelectOneOrMoreBenefitCodesToMapBackToTheBenefitCategoriesDisplayed()
        {
            Assert.IsNotNull(driver.FindElement(By.LinkText("Benefit Category")));
            driver.FindElement(By.CssSelector("a[class=\"btn btn-outline-primary\"]")).Click();
            Assert.AreEqual("table", driver.FindElement(By.Id("cblBenefitCodes")).TagName);
            //Console.WriteLine(driver.FindElement(By.Id("hfBenefitDetailID")).GetAttribute("value"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            if (driver.FindElement(By.Id("cblBenefitCodes_1")).Selected.Equals(false))
            {
                js.ExecuteScript("document.getElementById('cblBenefitCodes_1').click();");
            }
            if (driver.FindElement(By.Id("cblBenefitCodes_2")).Selected.Equals(false))
            {
                js.ExecuteScript("document.getElementById('cblBenefitCodes_2').click();");
            }
            if (driver.FindElement(By.Id("cblBenefitCodes_3")).Selected.Equals(false))
            {
                js.ExecuteScript("document.getElementById('cblBenefitCodes_3').click();");
            }
            string[] array1 = new string[20];
            array1[0] = driver.FindElement(By.Id("cblBenefitCodes_1")).GetAttribute("value");
            array1[1] = driver.FindElement(By.Id("cblBenefitCodes_2")).GetAttribute("value");
            array1[2] = driver.FindElement(By.Id("cblBenefitCodes_3")).GetAttribute("value");
            return array1;
        }
        
        [Then(@"once I click the save button the mapping should be saved to the database for future reference")]
        public void ThenOnceIClickTheSaveButtonTheMappingShouldBeSavedToTheDatabaseForFutureReference()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('LinkSaveSelectedCodes').click();");
            CirrusConfigAnalyst analyst = new CirrusConfigAnalyst();
            string[] array2 = new string[20];
            for (int i = 0; i< 3; i++)
            {
                //Console.WriteLine(analyst.GetQueryResult("Persist Security Info=False;Integrated Security=true;Initial Catalog=cirrusPlanBuilder;Server=DBVED40846", "SELECT [BenefitCodeID] FROM [cirrusPlanBuilder].[dbo].[BenefitDetailsCode] where BenefitDetailsID = 11326 and IsCurrent = 1;").Rows[i].ItemArray.GetValue(0).ToString());
                /*New Change: BenefitDetailsId record changed from 11326 to 11316 for some reason, Realized it @ 3/22/2021 */ 
                array2[i] = analyst.GetQueryResult("Persist Security Info=False;Integrated Security=true;Initial Catalog=cirrusPlanBuilder;Server=DBVED40846", "SELECT [BenefitCodeID] FROM [cirrusPlanBuilder].[dbo].[BenefitDetailsCode] where BenefitDetailsID = 11316  and IsCurrent = 1 order by BenefitCodeID Asc;").Rows[i].ItemArray.GetValue(0).ToString();
            }
            Assert.AreEqual(ThenIShouldBeAbleSelectOneOrMoreBenefitCodesToMapBackToTheBenefitCategoriesDisplayed(), array2);
            driver.Close();
        }
    }
}
