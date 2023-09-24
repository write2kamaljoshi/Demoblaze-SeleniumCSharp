using SeleniumProject.BaseClass;
using System;
using NUnit.Framework;
using SeleniumProject.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports;
using SeleniumProject2.Utilities;

namespace SeleniumProject.TestScripts
{
    [TestFixture]
    public class LoginTest: BaseTest
    {
        [OneTimeSetUp]
        [Test, Category("Smoke Test")]
        [Author("Kamal", "write2kamaljoshi@gmail.com")]
        [Description("Order a Laptop")]
        public void LoginToApp()
        {
            try
            {
                var loginPage = new LoginPage(driver);

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                wait.Until(driver => loginPage.Login.Displayed);
                loginPage.ClickLogin(driver);
                test.Log(Status.Pass, "Clicked on Login button");

                wait.Until(driver => loginPage.Username.Displayed);
                loginPage.EnterUsername(driver);
                test.Log(Status.Pass, "Username entered");

                wait.Until(driver => loginPage.Password.Displayed);
                loginPage.EnterPassword(driver);
                test.Log(Status.Pass, "Password entered");

                wait.Until(driver => loginPage.LoginButton.Displayed);
                loginPage.ClickLoginButton(driver);
                test.Log(Status.Pass, "Login successful");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, $"Test failed: {e.Message}");
                string screenshotFilePath = ScreenshotUtility.CaptureScreenshot(driver, "TestFailure");
                if (!string.IsNullOrEmpty(screenshotFilePath))
                {
                    // Adding screenshot in report
                    test.AddScreenCaptureFromPath(screenshotFilePath);
                }
                Console.Write(e.StackTrace);
                throw;
            }
        }
    }
}
