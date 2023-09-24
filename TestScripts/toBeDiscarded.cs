using SeleniumProject.BaseClass;
using NUnit.Framework;
using SeleniumProject.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium.Support.UI;
using OfficeOpenXml;

namespace SeleniumProject.TestScripts
{
    [TestFixture]
    public class SearchClient: BaseTest
    {
        [Test, Category("Smoke Test")]
        [Author("Kamal", "write2kamaljoshi@gmail.com")]
        [Description("Search a client using client number and verifying its name")]
        public void SearchClientByNumber()
        {
            try
            {
                var clientSearchPage = new ClientList(driver);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                // Load Excel file containing test data
                string excelFilePath = @"C:\Users\kamalj\source\repos\SeleniumDemo\SeleniumProject\TestData\ClientData.xlsx";
                FileInfo fileInfo = new FileInfo(excelFilePath);

                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        string clientNumber = worksheet.Cells[row, 1].Value?.ToString();
                        string expectedClientName = worksheet.Cells[row, 2].Value?.ToString();


                        // Navigate to client page
                        wait.Until(driver => clientSearchPage.ClientNavigation.Displayed);
                        clientSearchPage.NavigateTOClientPage();
                        test.Log(Status.Pass, "Client Test started");

                        try
                        {
                            wait.Until(driver => clientSearchPage.ClearFilters.Displayed);
                            //Thread.Sleep(7000);
                            clientSearchPage.ClickClearFilters();
                        }
                        catch (Exception e)
                        {
                            test.Log(Status.Fail, $"Exception while clicking Clear Filters: {e.Message}");
                        }

                        // Search for a client by number
                        clientSearchPage.SearchByClientNumber(clientNumber);

                        // Verify that search results displays the expected name
                        //string expectedText = "KamalClient";
                        //bool isTextPresent = wait.Until(driver => clientSearchPage.VerifyClientName(expectedText));
                        bool isTextPresent = wait.Until(driver => clientSearchPage.VerifyClientName(expectedClientName));
                        //Assert.IsTrue(isTextPresent, $"Expected text '{expectedText}' is not present on the page.");
                        Assert.IsTrue(isTextPresent, $"Expected text '{expectedClientName}' is not present on the page.");
                        test.Log(Status.Pass, "Test completed");
                    }
                }
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
        [Test, Category("Smoke Test")]
        [Author("Kamal", "write2kamaljoshi@gmail.com")]
        [Description("Search a client using client name and verifying the result")]
        public void SearchClientByName()
        {
            Assert.Ignore("not needed");
            try
            {
                var clientSearchPage = new ClientList(driver);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        
                // Navigate to client page
                wait.Until(driver => clientSearchPage.ClientNavigation.Displayed);
                clientSearchPage.NavigateTOClientPage();
                test.Log(Status.Pass, "Client Test2 started");

                try
                {
                    wait.Until(driver => clientSearchPage.ClearFilters.Displayed);
                    //Thread.Sleep(7000);
                    clientSearchPage.ClickClearFilters();
                }
                catch (Exception clearFiltersException)
                {
                    test.Log(Status.Fail, $"Exception while clicking Clear Filters: {clearFiltersException.Message}");
                }

                // Search for a client by name
                clientSearchPage.SearchByClientName();

                // Verify that search results displays the expected name
                string expectedText = "KamalClient";
                bool isTextPresent = wait.Until(driver => clientSearchPage.VerifyClientName(expectedText));
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
