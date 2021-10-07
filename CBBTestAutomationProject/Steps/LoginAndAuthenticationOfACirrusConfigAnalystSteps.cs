using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using CBBTestAutomationProject.HelperClasses;
using NUnit.Framework;
using System.Linq;

namespace CBBTestAutomationProject.Steps
{
    [Binding]
    public class LoginAndAuthenticationOfACirrusConfigAnalystSteps
    {
        public IWebDriver driver= new ChromeDriver();
        [Given(@"that I am Cirrus Configuration Analyst")]
        public int GivenThatIAmCirrusConfigurationAnalyst()
        {
            CirrusConfigAnalyst analyst = new CirrusConfigAnalyst();
            return (int)analyst.GetQueryResult("Persist Security Info=False;Integrated Security=true;Initial Catalog=cirrusPlanBuilder;Server=DBVED40846", "SELECT U.UserID FROM Users U where U.Username like SUBSTRING(USER,4,20);").Rows[0].ItemArray.GetValue(0);
        }
        
        [Given(@"I have successfully authenticated into CBB web app")]
        public void GivenIHaveSuccessfullyAuthenticatedIntoCBBWebApp()
        {
            string user = GivenThatIAmCirrusConfigurationAnalyst().ToString();
            string[] array = new string[] { "1", "4", "6" };
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl("https://cbb-dev.uhc.com");
            Assert.AreEqual(user, driver.FindElement(By.Id("hfCurrentUserID")).GetAttribute("value"));
            Assert.IsTrue(array.Contains(driver.FindElement(By.Id("hfCurrentRoleID")).GetAttribute("value")));
            driver.Close();
        }
    }
}
