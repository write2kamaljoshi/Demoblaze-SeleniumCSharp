using OpenQA.Selenium;
using System;

namespace SeleniumProject.PageObjects
{

    public class Laptops
    {
        IWebDriver driver; // defining driver

        public Laptops(IWebDriver driver)  // creating constructor
        {
            this.driver = driver;
        }


        // Locators
        public IWebElement Sonyi5 => driver.FindElement(By.XPath("//a[contains(text(), 'Sony vaio i5')]"));
        public IWebElement Sonyi7 => driver.FindElement(By.XPath("//a[contains(text(), 'Sony vaio i7')]"));
        public IWebElement MacbookAir => driver.FindElement(By.XPath("//a[contains(text(), 'MacBook air')]"));
        public IWebElement Delli7 => driver.FindElement(By.XPath("//a[contains(text(), 'Dell i7 8gb')]"));

        // Methods
        public void ClickSonyi5(IWebDriver driver)
        {
            Sonyi5.Click();
        }
        public void ClickSonyi7(IWebDriver driver)
        {
            Sonyi7.Click();
        }
        public void ClickMacbookAir(IWebDriver driver)
        {
            MacbookAir.Click();
        }
        public void ClickDelli7(IWebDriver driver)
        {
            Delli7.Click();
        }
    }
}
