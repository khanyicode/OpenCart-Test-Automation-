using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace OpenCartAutomation.Pages
{
    public class CheckoutPage
    {
        private readonly IWebDriver _driver;
        private WebDriverWait _wait;

        // Define locators
        private By billingDetailsSection = By.Id("collapse-payment-address");
        private By continueBillingDetailsButton = By.Id("button-payment-address");
        private By deliveryDetailsSection = By.Id("collapse-shipping-address");
        private By continueDeliveryDetailsButton = By.Id("button-shipping-address");
        private By deliveryMethodSection = By.Id("collapse-shipping-method");
        private By continueDeliveryMethodButton = By.Id("button-shipping-method");
        private By paymentMethodSection = By.Id("collapse-payment-method");
        private By agreeToTermsCheckbox = By.Name("agree");
        private By continuePaymentMethodButton = By.Id("button-payment-method");
        private By confirmOrderButton = By.Id("button-confirm");

        public CheckoutPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); // Adjust the timeout as needed
        }

        // Helper method to wait for an element to be visible
        private IWebElement WaitForElementToBeVisible(By locator)
        {
            return _wait.Until(driver => driver.FindElement(locator).Displayed ? driver.FindElement(locator) : null);
        }

        // Methods to interact with the page
        public void ContinueBillingDetails() => WaitForElementToBeVisible(continueBillingDetailsButton).Click();
        public void ContinueDeliveryDetails() => WaitForElementToBeVisible(continueDeliveryDetailsButton).Click();
        public void ContinueDeliveryMethod() => WaitForElementToBeVisible(continueDeliveryMethodButton).Click();
        public void AgreeToTerms() => WaitForElementToBeVisible(agreeToTermsCheckbox).Click();
        public void ContinuePaymentMethod() => WaitForElementToBeVisible(continuePaymentMethodButton).Click();
        public void ConfirmOrder() => WaitForElementToBeVisible(confirmOrderButton).Click();

        // Validation methods
        public bool IsBillingDetailsSectionVisible() => _driver.FindElement(billingDetailsSection).Displayed;
    }
}

