using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;


namespace SeleniumProject.Utilities
{
    public class BrowserUtility
    {
        public static IWebDriver InitializeBrowser(int browserType)
        {
            if (browserType == 1)
            {
                return new ChromeDriver();
            }
            else
            {
                return new EdgeDriver();
            }
        }

    }
}
