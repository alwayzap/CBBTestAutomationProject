using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace CBBTestAutomationProject.Steps
{
    [Binding]
    public class UserGuideSteps
    {
        IWebDriver driver = new ChromeDriver();
        
        [Given(@"I'm on the Home page")]
        public void GivenIMOnTheHomePage()
        {
            driver.Navigate().GoToUrl("https://cbb-dev.uhc.com");
        }
        
        [When(@"I click on the User Guide button within the Resources card")]
        public void WhenIClickOnTheUserGuideButtonWithinTheResourcesCard()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //the script below searches for the fifth button in the page. If a new button is added before this, the index needs to be changed from 4 to the new number
            js.ExecuteScript("document.getElementsByClassName(\"btn btn-outline-primary btn-block\")[3].click();");
        }
        
        [Then(@"a new Window should open with the User Guide page displayed")]
        public void ThenANewWindowShouldOpenWithTheUserGuidePageDisplayed()
        {
            Assert.AreEqual(driver.SwitchTo().Window(driver.WindowHandles.ElementAt(1)).Url, ("https://cbb-dev.uhc.com/UserGuide.html"));
            Thread.Sleep(2000);
            driver.Quit();
        }
    }
}
