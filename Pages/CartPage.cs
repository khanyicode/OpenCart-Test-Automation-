using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace OpenCartAutomation.Pages
{
    public class CartPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public CartPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public bool HasProductsInCart()
        {
            return _wait.Until(driver =>
                driver.FindElements(By.CssSelector(".table-responsive tbody tr")).Count > 0);
        }

        public string GetProductName()
        {
            return _wait.Until(driver =>
                driver.FindElement(By.CssSelector(".table-responsive tbody tr:first-child td:first-child")).Text);
        }

        public void RemoveProduct()
        {
            var removeButton = _wait.Until(driver =>
                driver.FindElement(By.CssSelector(".table-responsive tbody tr:first-child td:last-child button")));
            removeButton.Click();

            // Wait for cart to update
            _wait.Until(driver =>
                driver.FindElements(By.CssSelector(".table-responsive tbody tr")).Count == 0);
        }

        public bool IsCartEmpty()
        {
            return _wait.Until(driver =>
                driver.FindElements(By.CssSelector(".table-responsive tbody tr")).Count == 0);
        }

        public void UpdateProductQuantity(int quantity)
        {
            var quantityInput = _wait.Until(driver =>
                driver.FindElement(By.CssSelector(".table-responsive tbody tr:first-child input[name='quantity']")));
            quantityInput.Clear();
            quantityInput.SendKeys(quantity.ToString());

            var updateButton = _wait.Until(driver =>
                driver.FindElement(By.CssSelector(".table-responsive tbody tr:first-child button.update")));
            updateButton.Click();

            // Wait for the total to update
            _wait.Until(driver =>
                GetTotalAmount() != null);
        }

        public string GetTotalAmount()
        {
            return _wait.Until(driver =>
                driver.FindElement(By.CssSelector(".table-responsive tfoot tr:last-child td:last-child")).Text);
        }
    }
}
