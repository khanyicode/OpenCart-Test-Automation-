using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OpenCartAutomation.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        // Locators
        private readonly By emailField = By.Id("input-email");
        private readonly By passwordField = By.Id("input-password");
        private readonly By loginButton = By.CssSelector("input[type='submit']");

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        // Methods to interact with elements
        public void EnterEmail(string email)
        {
            var emailElement = WaitForElement(emailField);
            emailElement.Clear();
            emailElement.SendKeys(email);
        }

        public void EnterPassword(string password)
        {
            var passwordElement = WaitForElement(passwordField);
            passwordElement.Clear();
            passwordElement.SendKeys(password);
        }

        public void ClickLogin()
        {
            var loginBtn = WaitForElement(loginButton);
            loginBtn.Click();
        }

        // Method to perform login action
        public void Login(string email, string password)
        {
            EnterEmail(email);
            EnterPassword(password);
            ClickLogin();
        }

        // Helper method to wait for an element
        private IWebElement WaitForElement(By locator)
        {
            return _wait.Until(driver =>
            {
                var element = driver.FindElement(locator);
                return element.Displayed && element.Enabled ? element : null;
            });
        }
    }
}

