using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace SeleniumSpecFlow
{
    [Binding]
    public class BBCLoginSteps
    {
        private IWebDriver driver;

        [Given]
        public void Given_I_am_on_the_login_page()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://bbc.co.uk");
            IWebElement loginButton = driver.FindElement(By.Id("idcta-link"));
            loginButton.Click();
        }
        
        [Given]
        public void Given_I_have_entered_a_valid_username()
        {
            IWebElement usernameField = driver.FindElement(By.Id("user-identifier-input"));
            usernameField.SendKeys("Testing@JakeLRL.com");
        }
        
        [Given]
        public void Given_I_have_entered_an_invalid_password()
        {
            IWebElement passwordField = driver.FindElement(By.Id("password-input"));
            passwordField.SendKeys("12345678");
        }
        
        [When]
        public void When_I_press_login()
        {
            IWebElement submitButton = driver.FindElement(By.Id("submit-button"));
            submitButton.Click();
        }
        
        [Then]
        public void Then_I_should_see_the_appropriate_error()
        {
            IWebElement passwordError = driver.FindElement(By.Id("form-message-password"));
            Assert.AreEqual("Sorry, that password isn't valid. Please include a letter.", passwordError.Text);
        }
    }
}
