using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium.Edge;
using SeleniumProject.Utilities;
using static System.Net.WebRequestMethods;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.PageObjects;

namespace SeleniumProject.BaseClass
{
    public class BaseTest
    {
        public IWebDriver driver = null;
        public static ExtentReports extent = null;
        public ExtentTest test;

        [OneTimeSetUp]
        public void Open()
        {
            //Extent reports path
            string path = @"C:\Users\kamalj\source\repos\SeleniumDemo\SeleniumProject2\ExtentReports";

            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string reportFileName = $"UnitTest_{timestamp}.html";

            // Initialize ExtentReports
            extent = new ExtentReports();
            //var htmlReporter = new ExtentSparkReporter(@"C:\\Users\\kamalj\\source\\repos\\SeleniumDemo\\SeleniumProject\\ExtentReports\\UnitTest3.html");
            var htmlReporter = new ExtentSparkReporter(Path.Combine(path, reportFileName));
            extent.AttachReporter(htmlReporter);

            // Setting up Chrome driver
            //driver = new ChromeDriver();
            driver = BrowserUtility.InitializeBrowser(1);
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.demoblaze.com/index.html";

            test = extent.CreateTest("Demoblaze Test").Info("Chrome launched");
        }

        [OneTimeTearDown]
        public void Close()
        {
            driver.Quit();
            extent.Flush();
        }
    }
}
