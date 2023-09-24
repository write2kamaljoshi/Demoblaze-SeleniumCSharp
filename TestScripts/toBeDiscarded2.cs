using SeleniumProject.BaseClass;
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumProject.PageObjects;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports;


namespace SeleniumProject.TestScripts
{
    [TestFixture]
    public class VerifyDashboard: BaseTest
    {
        [Test, Category("Smoke Test")]
        [Author("Kamal", "write2kamaljoshi@gmail.com")]
        [Description("Verify dashboard data")]
        public void VerifyDashboardText()
        {
            try
            {
                var Dashboard = new HomePage(driver);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                test.Log(Status.Pass, "Dashboard Test started");
                string expectedText = "Dashboard";
                //wait.Until(driver => Dashboard.IsTextPresent(expectedText));
                //bool isTextPresent = Dashboard.IsTextPresent(expectedText);
                bool isTextPresent = wait.Until(driver => Dashboard.IsTextPresent(expectedText));
                Assert.IsTrue(isTextPresent, $"Expected text '{expectedText}' is not present on the page.");
                test.Log(Status.Pass, "Test completed");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, $"Test failed: {e.Message}");
                // Save a screenshot with a unique timestamp-based file name
                string screenshotFileName = $"Screenshot_{DateTime.Now:yyyyMMddHHmmss}.jpeg";
                string screenshotFilePath = Path.Combine("C:\\Users\\kamalj\\source\\repos\\SeleniumDemo\\SeleniumProject\\Screenshots", screenshotFileName);

                ITakesScreenshot ts = driver as ITakesScreenshot; 
                Screenshot screenshot = ts.GetScreenshot(); 
                //screenshot.SaveAsFile("C:\\Users\\kamalj\\source\\repos\\SeleniumDemo\\SeleniumProject\\Screenshots\\Screenshot1.jpeg", ScreenshotImageFormat.Jpeg);
                screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Jpeg);
                Console.Write(e.StackTrace); // prints the error info
                throw;
            }
            
        }
    }
}
