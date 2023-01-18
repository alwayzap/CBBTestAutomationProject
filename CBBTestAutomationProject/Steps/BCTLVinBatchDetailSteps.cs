using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using CBBTestAutomationProject.Steps;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Linq;
using System.Collections.Generic;

namespace CBBTestAutomationProject.Steps
{
    [Binding]
    public class BCTLVinBatchDetailSteps
    {

        IWebDriver driver = new ChromeDriver();
        string s = BCTLVGenerationSteps.s;
        
        [Then(@"the plan\(s\) should be added to the batch processing queue")]
        public void ThenThePlanSShouldBeAddedToTheBatchProcessingQueue()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://cbb-dev.uhc.com");
            driver.FindElement(By.Id("MainContent_lnkBatchInspector")).Click();
            Thread.Sleep(3000);
            Assert.AreEqual(driver.Url, "https://cbb-dev.uhc.com/BatchOverview.aspx");
            driver.FindElement(By.Id("BatchID")).SendKeys(s);
            driver.FindElement(By.Id("btnRefresh")).Click();
            if (driver.FindElement(By.Id("gvQueue")).FindElement(By.TagName("td")).Text != "Sorry, no Queue Batch are available.")
                Assert.AreEqual(s, driver.FindElement(By.Id("gvQueue")).FindElement(By.TagName("td")).Text);
            else
            {
                driver.FindElement(By.Id("tabCompleted")).Click();
                Thread.Sleep(3000);
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                Assert.AreEqual(s, driver.FindElement(By.XPath("//div[@id='qCompleted']//table[1]")).FindElements(By.TagName("td"))[0].Text) ;
            }
                Thread.Sleep(3000);
        }

        [Then(@"I should see the corresponding batch on the Batch Detail page")]
        public void ThenIShouldSeeTheCorrespondingBatchOnTheBatchDetailPage()
        {
            driver.FindElement(By.XPath("//a[@class=\"btn btn-sm btn-outline-primary\"]")).Click();
            Assert.AreEqual(driver.Url,"https://cbb-dev.uhc.com/BatchDetails.aspx?ID="+s);
            Assert.AreEqual("BHNQ", driver.FindElement(By.Id("gvBatchDetails")).FindElement(By.TagName("td")).Text);
            Thread.Sleep(3000);
        }

        [Then(@"I when I click on the View button I should see the digital version of the BCTLV")]
        public void ThenIWhenIClickOnTheViewButtonIShouldSeeTheDigitalVersionOfTheBCTLV()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            if (driver.FindElement(By.Id("btnViewError")).Displayed)
            {
                js.ExecuteScript("document.getElementsByClassName(\"btn btn-sm btn-outline-primary\")[0].click();");
            }
            else
            {
                js.ExecuteScript("document.getElementsByClassName(\"btn btn-sm btn-outline-primary\")[0].click();");
                js.ExecuteScript("document.getElementById('cblPlanBatchTypes_0').click();");
                js.ExecuteScript("document.getElementsByClassName('from-group col-6')[0].getElementsByClassName('btn btn-outline-primary btn-block btn-text-primary')[0].click();"); Thread.Sleep(6000);
                Assert.IsTrue(driver.SwitchTo().Window(driver.WindowHandles.ElementAt(1)).Url.Contains("https://cbb-dev.uhc.com/ViewPlanData.aspx?ID="));
                Assert.IsTrue(driver.SwitchTo().Window(driver.WindowHandles.ElementAt(1)).Url.Contains(s));
                Assert.IsTrue(driver.SwitchTo().Window(driver.WindowHandles.ElementAt(1)).Url.Contains("&PlanDataRequested=BV"));
            }
            driver.Quit();
        }

    }
}
