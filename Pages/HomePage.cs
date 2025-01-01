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
        private By wishlistButton = By.XPath("//button[contains(@data-original-title, 'Add to Wish List')]");
        private By loginPrompt = By.XPath("//div[@id='account-login']");
        private By myAccountDropdown = By.XPath("//a[@title='My Account']");
        private By loginOption = By.XPath("//a[text()='Login']");
        private By loginPage = By.XPath("//h2[text()='Returning Customer']");
        private By searchResults = By.XPath("//div[@class='product-thumb']");

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

        public void AddToWishlist(string productName)
        {
            var productElement = _wait.Until(d => d.FindElement(By.XPath($"//a[text()='{productName}']/ancestor::div[contains(@class, 'product-thumb')]")));
            var wishlistElement = productElement.FindElement(wishlistButton);
            wishlistElement.Click();
        }

        public bool IsLoginPromptDisplayed()
        {
            try
            {
                return _wait.Until(d => d.FindElement(loginPrompt)).Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public bool IsSearchResultDisplayed()
        {
            try
            {
                return _wait.Until(d => d.FindElements(searchResults).Count > 0);
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public void ClickMyAccount()
        {
            var accountDropdown = _wait.Until(d => d.FindElement(myAccountDropdown));
            accountDropdown.Click();
        }

        public void SelectLoginOption()
        {
            var loginLink = _wait.Until(d => d.FindElement(loginOption));
            loginLink.Click();
        }

        public bool IsLoginPageDisplayed()
        {
            try
            {
                return _wait.Until(d => d.FindElement(loginPage)).Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}

