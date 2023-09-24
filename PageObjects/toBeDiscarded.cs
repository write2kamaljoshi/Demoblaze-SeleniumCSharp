using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using OfficeOpenXml;
using System.IO;

namespace SeleniumProject.PageObjects
{
    
    public class ClientList
    {
        IWebDriver driver; // defining driver

        public ClientList(IWebDriver driver)  // creating constructor
        {
            this.driver = driver;
        }


        // Locators
        public IWebElement ClientNavigation => driver.FindElement(By.XPath(".//*[@class='icon-clients']"));
        public IWebElement ClearFilters => driver.FindElement(By.XPath("//span[contains(text(),'Clear filters')]"));

        IWebElement ClientNumber => driver.FindElement(By.XPath("//th[2]//div[1]//div[1]//input[1]"));
        IWebElement ClientName => driver.FindElement(By.XPath("//th[3]//div[1]//div[1]//input[1]"));

        IWebElement ClientNameResult => driver.FindElement(By.XPath("//span[@class='text-underline cursor-pointer']"));


        // Methods
        public ClientList NavigateTOClientPage()
            {
                ClientNavigation.Click();
                return this;
            }

        public ClientList ClickClearFilters()
        {
            ClearFilters.Click();
            return this;
        }

        public ClientList SearchByClientNumber(string clientNumber)
        {
            //ClientNumber.SendKeys("4947");
            ClientNumber.SendKeys(clientNumber);
            return this;
        }

        public ClientList SearchByClientName()
        {
            ClientName.SendKeys("KamalClient");
            return this;
        }

        public bool VerifyClientName(string expectedText)
        {
            string actualText = ClientNameResult.Text;
            //return actualText.Contains(expectedText);
            return actualText.Equals(expectedText);
        }
    }
}
