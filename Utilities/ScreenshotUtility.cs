using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject2.Utilities
{
    public class ScreenshotUtility
    {
        public static string CaptureScreenshot(IWebDriver driver, string description)
        {
            try
            {
                ITakesScreenshot ts = driver as ITakesScreenshot;
                Screenshot screenshot = ts.GetScreenshot();

                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string fileName = $"Screenshot_{timestamp}.png";

                string folder = "C:\\Users\\kamalj\\source\\repos\\SeleniumDemo\\SeleniumProject2\\Screenshots";
                string filePath = System.IO.Path.Combine(folder, fileName);
                screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
                return filePath;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Screenshot capture failed: {e}");
                return null;
            }
        }

    }
}



