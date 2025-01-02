using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace OpenCartAutomation.Pages
{
    public class CartPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public CartPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        // Locators
        private readonly By CartTable = By.CssSelector(".table-responsive table");
        private readonly By ProductNameLocator = By.CssSelector(".table-responsive tbody tr td:nth-child(2)");
        private readonly By RemoveButtonLocator = By.CssSelector(".btn-danger");
        private readonly By UpdateQuantityField = By.CssSelector(".input-group input");
        private readonly By UpdateButton = By.CssSelector(".input-group .btn-primary");
        private readonly By CheckoutButton = By.LinkText("Checkout");
        private readonly By TotalAmountLocator = By.CssSelector("tr:last-child td:last-child");

        // Methods
        public string GetProductName()
        {
            return _driver.FindElement(ProductNameLocator).Text;
        }

        public void RemoveProduct()
        {
            _driver.FindElement(RemoveButtonLocator).Click();
        }

        public void UpdateProductQuantity(int quantity)
        {
            var quantityField = _driver.FindElement(UpdateQuantityField);
            quantityField.Clear();
            quantityField.SendKeys(quantity.ToString());
            _driver.FindElement(UpdateButton).Click();
        }

        public string GetTotalAmount()
        {
            return _driver.FindElement(TotalAmountLocator).Text;
        }

        public void ProceedToCheckout()
        {
            _driver.FindElement(CheckoutButton).Click();
        }

        public bool IsCartEmpty()
        {
            return !_driver.FindElements(CartTable).Count.Equals(0);
        }
    }
}
