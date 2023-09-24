using OpenQA.Selenium;
using System;

namespace SeleniumProject.PageObjects
{

    public class HomePage
    {
        IWebDriver driver; // defining driver

        public HomePage(IWebDriver driver)  // creating constructor
        {
            this.driver = driver;
        }


        // Locators
        public IWebElement ProductStore => driver.FindElement(By.Id("nava"));
        IWebElement Profile => driver.FindElement(By.Id("nameofuser"));
        IWebElement Phones => driver.FindElement(By.XPath("//a[contains(text(),'Phones')]"));
        public IWebElement Laptops => driver.FindElement(By.XPath("//a[contains(text(),'Laptops')]"));
        IWebElement Monitors => driver.FindElement(By.XPath("//a[contains(text(),'Monitors')]"));


        // Methods
        public bool IsTextPresent(string expectedText)
        {
            string actualText = Profile.Text;
            return actualText.Equals(expectedText);
        }
        public void ClickProductStore(IWebDriver driver)
        {
            ProductStore.Click();
        }

        public void ClickPhones(IWebDriver driver)
        {
            Phones.Click();
        }

        public void ClickLaptops(IWebDriver driver)
        {
            Laptops.Click();
        }

        public void ClickMonitors(IWebDriver driver)
        {
            Monitors.Click();
        }
    }
}
