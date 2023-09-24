using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumProject.PageObjects
{

    public class LoginPage
    {
        IWebDriver driver; // defining driver

        public LoginPage(IWebDriver driver)  // creating constructor
        {
            this.driver = driver;
        }


        // Locators
        public IWebElement Login => driver.FindElement(By.Id("login2"));
        public IWebElement Username => driver.FindElement(By.Id("loginusername"));
        public IWebElement Password => driver.FindElement(By.Id("loginpassword"));
        public IWebElement LoginButton => driver.FindElement(By.XPath("//button[contains(text(),'Log in')]"));


        // Methods
        public void ClickLogin(IWebDriver driver)
        {
            Login.Click();
        }

        public void EnterUsername(IWebDriver driver)
        {
            Username.SendKeys("test");
        }

        public void EnterPassword(IWebDriver driver)
        {
            Password.SendKeys("test");
        }

        public void ClickLoginButton(IWebDriver driver)
        {
            LoginButton.Click();
        }
    }
}
