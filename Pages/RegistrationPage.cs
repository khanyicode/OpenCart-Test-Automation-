using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace OpenCartAutomation.Pages
{
    public class RegistrationPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public RegistrationPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        // Locators
        private readonly By FirstNameField = By.Id("input-firstname");
        private readonly By LastNameField = By.Id("input-lastname");
        private readonly By EmailField = By.Id("input-email");
        private readonly By TelephoneField = By.Id("input-telephone");
        private readonly By PasswordField = By.Id("input-password");
        private readonly By ConfirmPasswordField = By.Id("input-confirm");
        private readonly By AgreeCheckbox = By.Name("agree");
        private readonly By ContinueButton = By.CssSelector("input[type='submit']");

        // Methods
        public void EnterFirstName(string firstName)
        {
            _driver.FindElement(FirstNameField).SendKeys(firstName);
        }

        public void EnterLastName(string lastName)
        {
            _driver.FindElement(LastNameField).SendKeys(lastName);
        }

        public void EnterEmail(string email)
        {
            _driver.FindElement(EmailField).SendKeys(email);
        }

        public void EnterTelephone(string telephone)
        {
            _driver.FindElement(TelephoneField).SendKeys(telephone);
        }

        public void EnterPassword(string password)
        {
            _driver.FindElement(PasswordField).SendKeys(password);
        }

        public void EnterConfirmPassword(string confirmPassword)
        {
            _driver.FindElement(ConfirmPasswordField).SendKeys(confirmPassword);
        }

        public void AgreeToTerms()
        {
            _driver.FindElement(AgreeCheckbox).Click();
        }

        public void SubmitForm()
        {
            _driver.FindElement(ContinueButton).Click();
        }
    }
}
