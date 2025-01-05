using NUnit.Framework;
using OpenCartAutomation.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace OpenCartAutomation.Tests
{
    public class CheckoutTests
    {
        private IWebDriver _driver;
        private CheckoutPage _checkoutPage;
        private WebDriverWait _wait;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://opencart.abstracta.us/index.php?route=checkout/checkout");
            _checkoutPage = new CheckoutPage(_driver);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void CompleteCheckout_WithValidDetails_ShouldSucceed()
        {
            // Arrange
            var billingDetails = new
            {
                FirstName = "Mpho",
                LastName = "Mofokeng",
                Email = "mpho.doe@example.com",
                Telephone = "1234567890",
                Address = "123 Main St",
                City = "Cityville",
                PostCode = "12345",
                Country = "United States",
                Region = "California"
            };

            // Act
            _checkoutPage.EnterBillingDetails(
                billingDetails.FirstName,
                billingDetails.LastName,
                billingDetails.Email,
                billingDetails.Telephone,
                billingDetails.Address,
                billingDetails.City,
                billingDetails.PostCode,
                billingDetails.Country,
                billingDetails.Region
            );
            
            _checkoutPage.SelectShippingMethod("Flat Rate");
            _checkoutPage.SelectPaymentMethod("Cash On Delivery");
            _checkoutPage.AcceptTermsAndConditions();
            _checkoutPage.ConfirmOrder();

            // Assert
            Assert.That(_checkoutPage.IsOrderSuccessful(), Is.True);
            Assert.That(_checkoutPage.GetOrderConfirmationMessage(), Does.Contain("Your order has been placed!"));
        }

        [Test]
        public void ApplyInvalidCoupon_ShouldShowError()
        {
            // Act
            _checkoutPage.ApplyCoupon("INVALIDCODE");

            // Assert
            var error = _wait.Until(d => d.FindElement(By.CssSelector(".alert-danger"))).Text;
            Assert.That(error, Does.Contain("Warning: Coupon is either invalid, expired or reached its usage limit!"));
        }

        [Test]
        public void SubmitEmptyBillingDetails_ShouldShowValidationErrors()
        {
            // Act
            _checkoutPage.ContinueToPayment();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(_checkoutPage.GetFirstNameError(), Does.Contain("First Name required"));
                Assert.That(_checkoutPage.GetLastNameError(), Does.Contain("Last Name required"));
                Assert.That(_checkoutPage.GetEmailError(), Does.Contain("E-Mail required"));
                Assert.That(_checkoutPage.GetTelephoneError(), Does.Contain("Telephone required"));
            });
        }

        [Test]
        public void ModifyShippingMethod_ShouldUpdateOrderTotal()
        {
            // Arrange
            string initialTotal = _checkoutPage.GetOrderTotal();

            // Act
            _checkoutPage.SelectShippingMethod("Express Shipping");
            string updatedTotal = _checkoutPage.GetOrderTotal();

            // Assert
            Assert.That(updatedTotal, Is.Not.EqualTo(initialTotal));
        }

        [Test]
        public void AddDeliveryComments_ShouldPersistThroughCheckout()
        {
            // Arrange
            string comments = "Please deliver after 6 PM";

            // Act
            _checkoutPage.AddDeliveryComments(comments);
            _checkoutPage.ContinueToPayment();

            // Assert
            Assert.That(_checkoutPage.GetDeliveryComments(), Is.EqualTo(comments));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}