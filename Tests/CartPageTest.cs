using NUnit.Framework;
using OpenCartAutomation.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace OpenCartAutomation.Tests
{
    public class CartTests
    {
        private IWebDriver _driver = null!;
        private WebDriverWait _wait = null!;
        private CartPage _cartPage = null!;

        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.Normal;

            _driver = new ChromeDriver(options);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://opencart.abstracta.us/index.php?route=checkout/cart");
            _cartPage = new CartPage(_driver, _wait);
        }

        [Test]
        public void VerifyProductCanBeRemovedFromCart()
        {
            // Ensure the cart has at least one product
            Assert.That(_cartPage.HasProductsInCart(), Is.True, "Cart is empty. Cannot test removal.");

            // Capture product name for verification
            string productName = _cartPage.GetProductName();
            Assert.That(productName, Is.Not.Null, "No product name found in cart.");

            // Remove the product
            _cartPage.RemoveProduct();
            Assert.That(_cartPage.IsCartEmpty(), Is.True, "Product was not removed from the cart.");
        }

        [Test]
        public void VerifyProductQuantityUpdate()
        {
            // Ensure the cart has at least one product
            Assert.That(_cartPage.HasProductsInCart(), Is.True, "Cart is empty. Cannot test quantity update.");

            // Update quantity and verify total
            int newQuantity = 3;
            _cartPage.UpdateProductQuantity(newQuantity);
            string totalAmount = _cartPage.GetTotalAmount();

            Assert.That(totalAmount, Does.Contain("expected_total"), "The total amount is incorrect after updating the quantity.");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}

