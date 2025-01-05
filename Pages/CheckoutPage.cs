using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace OpenCartAutomation.Pages
{
    public class CheckoutPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        // Constructor
        public CheckoutPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        // Element locators
        private By FirstNameInput => By.Id("input-payment-firstname");
        private By LastNameInput => By.Id("input-payment-lastname");
        private By EmailInput => By.Id("input-payment-email");
        private By TelephoneInput => By.Id("input-payment-telephone");
        private By AddressInput => By.Id("input-payment-address-1");
        private By CityInput => By.Id("input-payment-city");
        private By PostCodeInput => By.Id("input-payment-postcode");
        private By CountrySelect => By.Id("input-payment-country");
        private By RegionSelect => By.Id("input-payment-zone");
        private By CouponInput => By.Id("input-coupon");
        private By ApplyCouponButton => By.Id("button-coupon");
        private By ContinueButton => By.Id("button-payment-address");
        private By ShippingMethodRadio => By.CssSelector("input[type='radio'][name='shipping_method']");
        private By PaymentMethodRadio => By.CssSelector("input[type='radio'][name='payment_method']");
        private By TermsCheckbox => By.CssSelector("input[type='checkbox'][name='agree']");
        private By ConfirmOrderButton => By.Id("button-confirm");
        private By OrderTotalText => By.CssSelector(".total strong");
        private By DeliveryCommentsTextarea => By.Name("comment");
        private By SuccessMessage => By.CssSelector("#content h1");

        // Error message locators
        private By FirstNameError => By.CssSelector("#input-payment-firstname + .text-danger");
        private By LastNameError => By.CssSelector("#input-payment-lastname + .text-danger");
        private By EmailError => By.CssSelector("#input-payment-email + .text-danger");
        private By TelephoneError => By.CssSelector("#input-payment-telephone + .text-danger");

        // Methods
        public void EnterBillingDetails(string firstName, string lastName, string email, string telephone, 
            string address, string city, string postCode, string country, string region)
        {
            WaitAndSendKeys(FirstNameInput, firstName);
            WaitAndSendKeys(LastNameInput, lastName);
            WaitAndSendKeys(EmailInput, email);
            WaitAndSendKeys(TelephoneInput, telephone);
            WaitAndSendKeys(AddressInput, address);
            WaitAndSendKeys(CityInput, city);
            WaitAndSendKeys(PostCodeInput, postCode);

            var countryDropdown = _wait.Until(d => d.FindElement(CountrySelect));
            var countrySelect = new SelectElement(countryDropdown);
            countrySelect.SelectByText(country);

            // Wait for region options to load
            System.Threading.Thread.Sleep(1000);

            var regionDropdown = _wait.Until(d => d.FindElement(RegionSelect));
            var regionSelect = new SelectElement(regionDropdown);
            regionSelect.SelectByText(region);
        }

        public void ApplyCoupon(string couponCode)
        {
            WaitAndSendKeys(CouponInput, couponCode);
            _wait.Until(d => d.FindElement(ApplyCouponButton)).Click();
        }

        public void SelectShippingMethod(string methodName)
        {
            var shippingMethods = _wait.Until(d => d.FindElements(ShippingMethodRadio));
            var method = shippingMethods.FirstOrDefault(m => m.FindElement(By.XPath("./..")).Text.Contains(methodName));
            method?.Click();
        }

        public void SelectPaymentMethod(string methodName)
        {
            var paymentMethods = _wait.Until(d => d.FindElements(PaymentMethodRadio));
            var method = paymentMethods.FirstOrDefault(m => m.FindElement(By.XPath("./..")).Text.Contains(methodName));
            method?.Click();
        }

        public void AcceptTermsAndConditions()
        {
            _wait.Until(d => d.FindElement(TermsCheckbox)).Click();
        }

        public void ConfirmOrder()
        {
            _wait.Until(d => d.FindElement(ConfirmOrderButton)).Click();
        }

        public void ContinueToPayment()
        {
            _wait.Until(d => d.FindElement(ContinueButton)).Click();
        }

        public string GetOrderTotal()
        {
            return _wait.Until(d => d.FindElement(OrderTotalText)).Text;
        }

        public void AddDeliveryComments(string comments)
        {
            WaitAndSendKeys(DeliveryCommentsTextarea, comments);
        }

        public string GetDeliveryComments()
        {
            return _wait.Until(d => d.FindElement(DeliveryCommentsTextarea)).GetAttribute("value");
        }

        public bool IsOrderSuccessful()
        {
            try
            {
                var message = _wait.Until(d => d.FindElement(SuccessMessage)).Text;
                return message.Contains("Your order has been placed!");
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public string GetOrderConfirmationMessage()
        {
            return _wait.Until(d => d.FindElement(SuccessMessage)).Text;
        }

        // Error getters
        public string GetFirstNameError() => GetErrorMessage(FirstNameError);
        public string GetLastNameError() => GetErrorMessage(LastNameError);
        public string GetEmailError() => GetErrorMessage(EmailError);
        public string GetTelephoneError() => GetErrorMessage(TelephoneError);

        // Helper methods
        private void WaitAndSendKeys(By locator, string text)
        {
            _wait.Until(d => d.FindElement(locator)).Clear();
            _wait.Until(d => d.FindElement(locator)).SendKeys(text);
        }

        private string GetErrorMessage(By locator)
        {
            try
            {
                return _wait.Until(d => d.FindElement(locator)).Text;
            }
            catch (WebDriverTimeoutException)
            {
                return string.Empty;
            }
        }
    }
}