using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OpenCartAutomation.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        // Locators
        private By searchBox = By.Name("search");
        private By searchButton = By.XPath("//button[@class='btn btn-default btn-lg']");
        private By featuredProduct = By.XPath("//div[@class='product-thumb']");

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void EnterSearchText(string searchText)
        {
            var searchElement = _wait.Until(d => d.FindElement(searchBox));
            searchElement.Clear();
            searchElement.SendKeys(searchText);
        }

        public void ClickSearchButton()
        {
            var button = _wait.Until(d => d.FindElement(searchButton));
            button.Click();
        }

        public bool IsFeaturedProductDisplayed()
        {
            try
            {
                var product = _wait.Until(d => d.FindElement(featuredProduct));
                return product.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public void SearchProduct(string productName)
        {
            EnterSearchText(productName);
            ClickSearchButton();
        }
    }
}

