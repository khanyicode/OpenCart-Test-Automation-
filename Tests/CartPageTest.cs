using NUnit.Framework;
using OpenCartAutomation.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCartAutomation.Tests
{
    public class CartTests
    {
        private IWebDriver _driver = null!;
        private CartPage _cartPage = null!;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://opencart.abstracta.us/index.php?route=checkout/cart");
            _cartPage = new CartPage(_driver);
        }

        [Test]
        public void VerifyProductCanBeRemovedFromCart()
        {
            // Assume the cart already has a product added
            string productName = _cartPage.GetProductName();
            Assert.That(productName, Is.Not.Null, "Cart is empty, no product to remove.");

            _cartPage.RemoveProduct();
            Assert.That(_cartPage.IsCartEmpty(), Is.True, "Product was not removed from the cart.");
        }

        [Test]
        public void VerifyProductQuantityUpdate()
        {
            // Assume the cart already has a product added
            _cartPage.UpdateProductQuantity(3);
            string total = _cartPage.GetTotalAmount();
            Assert.That(total.Contains("expected_total"), Is.True, "The total amount is incorrect after updating the quantity.");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}

