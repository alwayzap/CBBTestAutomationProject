using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using CBBTestAutomationProject.HelperClasses;
using System.Linq;
using System.Threading;
using CBBTestAutomationProject.Steps;

namespace CBBTestAutomationProject.Steps
{
    [Binding]
    public class BasicAndAdvancedSearchInBCTLVGenerationPageSteps
    {
        public IWebDriver driver = new ChromeDriver();
        string validplancode = "BHNQ";
        string invalidplancode = "000000";
        string validdbsid = "52291";
        string invaliddbsid = "000000";
        string validcreatedby = "mmiley10";
        string invalidcreatedby = "invalid1";
        string validgroupnumber = "908202";
        string invalidgroupnumber = "000000";

        [When(@"I enter a Valid Plan Code on the Standard Search tab")]
        public void WhenIEnterAValidPlanCodeOnTheStandardSearchTab()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://cbb-dev.uhc.com");
            driver.FindElement(By.Id("MainContent_lnkBctlvGnrtn")).Click();
            Assert.AreEqual(driver.Url, "https://cbb-dev.uhc.com/BCTLVGeneration.aspx");
            Thread.Sleep(300);
            driver.FindElement(By.Id("txtPlanCode2")).SendKeys(validplancode);
        }

        [When(@"I enter an Invalid Plan Code on the Standard Search tab")]
        public void WhenIEnterAnInValidPlanCodeOnTheStandardSearchTab()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://cbb-dev.uhc.com");
            driver.FindElement(By.Id("MainContent_lnkBctlvGnrtn")).Click();
            Assert.AreEqual(driver.Url, "https://cbb-dev.uhc.com/BCTLVGeneration.aspx");
            Thread.Sleep(300);
            driver.FindElement(By.Id("txtPlanCode2")).SendKeys(invalidplancode);
        }

        [When(@"I click Search")]
        public void WhenIClickSearch()
        {
            if ((driver.FindElement(By.CssSelector("a[id=\"lnkStdSearch\"]")).Displayed))
            {
                driver.FindElement(By.CssSelector("a[id=\"lnkStdSearch\"]")).Click();
            }
            else if ((driver.FindElement(By.CssSelector("a[id=\"lnkAdvcSearch\"]")).Displayed))
            {
                driver.FindElement(By.CssSelector("a[id=\"lnkAdvcSearch\"]")).Click();
            }
            
        }
        
        [When(@"a result is found in the DBS database")]
        public void WhenAResultIsFoundInTheDBSDatabase()
        {
            CirrusConfigAnalyst analyst = new CirrusConfigAnalyst();
            if ((driver.FindElement(By.CssSelector("a[id=\"lnkStdSearch\"]")).Displayed))
            {
                Assert.IsTrue(analyst.GetQueryResult("Persist Security Info=False;Integrated Security=true;Initial Catalog=PlanBuilder;Server=DBSED4516", "select * from dbo.PlanAssignment pa join dbo.PlanCode pc on pa.PlanCodeID = pc.PlanCodeID where pc.PlanCode ='" + validplancode + "';").Rows.Count >= 1);
            }
            else if ((driver.FindElement(By.CssSelector("a[id=\"lnkAdvcSearch\"]")).Displayed))
            {
                Assert.IsTrue(analyst.GetQueryResult("Persist Security Info=False;Integrated Security=true;Initial Catalog=DBS;Server=DBVED39544", "SELECT * FROM dbo.digitalbenefit join Users ON Users.userID = dbo.digitalbenefit.userid where digital_benefitid =" + validdbsid + "and Users.userName ='" + validcreatedby + "' and customer_policy_number =" + validgroupnumber + ";").Rows.Count >= 1);
            }
        }
        
        [When(@"I enter a Valid DBS ID, Group Number, or Created By on the Advanced Search tab")]
        public void WhenIEnterAValidDBSIDGroupNumberOrCreatedByOnTheAdvancedSearchTab()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://cbb-dev.uhc.com");
            driver.FindElement(By.Id("MainContent_lnkBctlvGnrtn")).Click();
            Assert.AreEqual(driver.Url, "https://cbb-dev.uhc.com/BCTLVGeneration.aspx");
            Thread.Sleep(300);
            driver.FindElement(By.XPath("//a[@href=\"#plnAdvancedSearch\"]")).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            Thread.Sleep(300);
            js.ExecuteScript("document.getElementById('digitalBenefitID2').value='"+validdbsid+"';");
            js.ExecuteScript("document.getElementById('groupNumber').value='" + validgroupnumber + "';");
            js.ExecuteScript("document.getElementById('createdBy').value='" + validcreatedby + "';");
        }

        [When(@"I enter an Invalid DBS ID, Group Number, or Created By on the Advanced Search tab")]
        public void WhenIEnterAnInvalidDBSIDGroupNumberOrCreatedByOnTheAdvancedSearchTab()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://cbb-dev.uhc.com");
            driver.FindElement(By.Id("MainContent_lnkBctlvGnrtn")).Click();
            Assert.AreEqual(driver.Url, "https://cbb-dev.uhc.com/BCTLVGeneration.aspx");
            Thread.Sleep(300);
            driver.FindElement(By.XPath("//a[@href=\"#plnAdvancedSearch\"]")).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            Thread.Sleep(300);
            js.ExecuteScript("document.getElementById('digitalBenefitID2').value='" + invaliddbsid + "';");
            js.ExecuteScript("document.getElementById('groupNumber').value='" + invalidgroupnumber + "';");
            js.ExecuteScript("document.getElementById('createdBy').value='" + invalidcreatedby + "';");
        }

        [When(@"a result is NOT found in the DBS database")]
        public void WhenAResultIsNOTFoundInTheDBSDatabase()
        {
            CirrusConfigAnalyst analyst = new CirrusConfigAnalyst();
            if ((driver.FindElement(By.CssSelector("a[id=\"lnkStdSearch\"]")).Displayed))
            {
                Assert.AreEqual(analyst.GetQueryResult("Persist Security Info=False;Integrated Security=true;Initial Catalog=PlanBuilder;Server=DBSED4516", "select * from dbo.PlanAssignment pa join dbo.PlanCode pc on pa.PlanCodeID = pc.PlanCodeID where pc.PlanCode ='" + invalidplancode + "';").Rows.Count, 0);
            }
            else if ((driver.FindElement(By.CssSelector("a[id=\"lnkAdvcSearch\"]")).Displayed))
            {
                Assert.AreEqual(analyst.GetQueryResult("Persist Security Info=False;Integrated Security=true;Initial Catalog=DBS;Server=DBVED39544", "SELECT * FROM dbo.digitalbenefit join Users ON Users.userID = dbo.digitalbenefit.userid where digital_benefitid =" + invaliddbsid + "and Users.userName ='" + invalidcreatedby + "' and customer_policy_number =" + invalidgroupnumber + ";").Rows.Count, 0);
            }
            
        }

        [Then(@"a table should display with the plans that match the DBS ID entered")]
        public void ThenATableShouldDisplayWithThePlansThatMatchTheDBSIDEntered()
        {
            CirrusConfigAnalyst analyst = new CirrusConfigAnalyst();
            if ((driver.FindElement(By.CssSelector("a[id=\"lnkStdSearch\"]")).Displayed))
            {
                Assert.AreEqual(analyst.GetQueryResult("Persist Security Info=False;Integrated Security=true;Initial Catalog=PlanBuilder;Server=DBSED4516", "select pc.PlanCode from dbo.PlanAssignment pa join dbo.PlanCode pc on pa.PlanCodeID = pc.PlanCodeID where pc.PlanCode ='" + validplancode + "';").Rows[0].ItemArray.GetValue(0).ToString() , driver.FindElement(By.Id("gvstdBCTLVGen")).FindElements(By.TagName("td")).ElementAt(1).Text);
            }
            else if ((driver.FindElement(By.CssSelector("a[id=\"lnkAdvcSearch\"]")).Displayed))
            {
                Assert.AreEqual(analyst.GetQueryResult("Persist Security Info=False;Integrated Security=true;Initial Catalog=DBS;Server=DBVED39544", "SELECT digital_benefitid ,plan_code FROM dbo.digitalbenefit join Users ON Users.userID = dbo.digitalbenefit.userid where digital_benefitid =" + validdbsid + "and Users.userName ='" + validcreatedby + "' and customer_policy_number ='" + validgroupnumber + "';").Rows[0].ItemArray.GetValue(1).ToString(), driver.FindElement(By.Id("gvBCTLVGen")).FindElements(By.TagName("td")).ElementAt(2).Text);
            }
            driver.Close();
        }
        
        [Then(@"a table should display with a message stating “No Results Returned\.”")]
        public void ThenATableShouldDisplayWithAMessageStatingNoResultsReturned_()
        {
            CirrusConfigAnalyst analyst = new CirrusConfigAnalyst();
            if ((driver.FindElement(By.CssSelector("a[id=\"lnkStdSearch\"]")).Displayed))
            {
                Assert.AreEqual("No Results Returned.", driver.FindElement(By.Id("gvstdBCTLVGen")).FindElements(By.CssSelector("span")).ElementAt(0).Text);

            }
            else if ((driver.FindElement(By.CssSelector("a[id=\"lnkAdvcSearch\"]")).Displayed))
            {
                Assert.AreEqual("No Results Returned.", driver.FindElement(By.Id("gvBCTLVGen")).FindElements(By.CssSelector("span")).ElementAt(0).Text);

            }
            driver.Close();
        }
    }
}
