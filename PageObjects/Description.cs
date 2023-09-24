using OpenQA.Selenium;
using System;

namespace SeleniumProject.PageObjects
{

    public class Description
    {
        IWebDriver driver; // defining driver

        public Description(IWebDriver driver)  // creating constructor
        {
            this.driver = driver;
        }


        // Locators
        public IWebElement AddToCart => driver.FindElement(By.XPath("//a[contains(text(), 'Add to cart')]"));


        // Methods
        public void ClickAddToCart(IWebDriver driver)
        {
            AddToCart.Click();
        }
    }
}
