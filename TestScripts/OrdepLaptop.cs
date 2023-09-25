using SeleniumProject.BaseClass;
using System;
using NUnit.Framework;
using SeleniumProject.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports;
using SeleniumProject2.Utilities;
using OfficeOpenXml;

namespace SeleniumProject.TestScripts
{
    [TestFixture]
    public class AddToCart: LoginTest
    {
        [Test, Category("Smoke Test")]
        [Author("Kamal", "write2kamaljoshi@gmail.com")]
        [Description("Order a Laptop")]
        public void AddLaptopToCart()
        {
            try
            {
                var homePage = new HomePage(driver);
                var laptops = new Laptops(driver);
                var description = new Description(driver);

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                string excelFilePath = @"C:\Users\kamalj\source\repos\SeleniumDemo\SeleniumProject2\TestData\LaptopList.xlsx";
                string sheetName = "Sheet1";
                int columnNumber = 1;
                List<string> laptopModels = ExcelUtility.ReadExcelFile(excelFilePath, sheetName, columnNumber);

                foreach (var model in laptopModels)
                {
                    string laptopModel = model;
                    test.Log(Status.Pass, "Test started");
                    Thread.Sleep(2000);
                    homePage.ClickProductStore(driver);
                    //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    //wait.Until(driver => homePage.Laptops.Displayed);
                    //wait.Until(driver => homePage.Laptops.Enabled);
                    //wait.Until(driver => driver.FindElement(By.XPath("//a[contains(text(), 'Laptops')]")).Displayed);
                    Thread.Sleep(2000);
                    homePage.ClickLaptops(driver);
                    test.Log(Status.Pass, "Clicked on Laptops");

                    if (laptopModel == "Sony vaio i5")
                    {
                        wait.Until(driver => laptops.Sonyi5.Displayed);
                        laptops.ClickSonyi5(driver);
                        test.Log(Status.Pass, "Clicked on Sonyi5");
                    }
                    else if (laptopModel == "Sony vaio i7")
                    {
                        wait.Until(driver => laptops.Sonyi7.Displayed);
                        laptops.ClickSonyi7(driver);
                        test.Log(Status.Pass, "Clicked on Sonyi7");
                    }
                    else if (laptopModel == "MacBook air")
                    {
                        wait.Until(driver => laptops.MacbookAir.Displayed);
                        laptops.ClickMacbookAir(driver);
                        test.Log(Status.Pass, "Clicked on MacbookAir");
                    }
                    else if (laptopModel == "Dell i7 8gb")
                    {
                        wait.Until(driver => laptops.Delli7.Displayed);
                        laptops.ClickDelli7(driver);
                        test.Log(Status.Pass, "Clicked on Delli7");
                    }


                    wait.Until(driver => description.AddToCart.Displayed);
                    description.ClickAddToCart(driver);
                    test.Log(Status.Pass, "Added to cart");
                    Thread.Sleep(2000);
                    IAlert alert = driver.SwitchTo().Alert();
                    alert.Accept();
                    driver.SwitchTo().DefaultContent();
                    test.Log(Status.Pass, "Test completed");
                }
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, $"Test failed: {e.Message}");

                string screenshotFilePath = ScreenshotUtility.CaptureScreenshot(driver, "TestFailure");
                // Adding screenshot in report
                test.AddScreenCaptureFromPath(screenshotFilePath);
                Console.Write(e.StackTrace); 
                throw;
            }
        }
    }
}
