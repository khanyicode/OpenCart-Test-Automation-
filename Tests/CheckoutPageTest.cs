using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI; // Import for WebDriverWait
using OpenCartAutomation.Pages;

namespace OpenCartAutomation.Tests
{
    public class CheckoutPageTests
    {
        private IWebDriver _driver;
        private CheckoutPage _checkoutPage;

        [SetUp]
        public void SetUp()
        {
            // Initialize WebDriver (Chrome in this case)
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://opencart.abstracta.us/index.php?route=checkout/checkout");

            // Initialize the CheckoutPage object
            _checkoutPage = new CheckoutPage(_driver);
        }

        [Test]
        public void TestBillingDetailsSectionVisibility()
        {
            Assert.That(_checkoutPage.IsBillingDetailsSectionVisible(), Is.EqualTo(true), "The billing details section should be visible.");
        }

        [Test]
        public void TestContinueBillingDetailsButtonFunctionality()
        {
            _checkoutPage.ContinueBillingDetails();

            Assert.That(_driver.FindElement(By.Id("collapse-shipping-address")).Displayed, Is.EqualTo(true), "The delivery details section should be visible after continuing billing details.");
        }

        [Test]
        public void TestContinueDeliveryDetailsButtonFunctionality()
        {
            _checkoutPage.ContinueDeliveryDetails();

            Assert.That(_driver.FindElement(By.Id("collapse-shipping-method")).Displayed, Is.EqualTo(true), "The delivery method section should be visible after continuing delivery details.");
        }

        [Test]
        public void TestContinueDeliveryMethodButtonFunctionality()
        {
            _checkoutPage.ContinueDeliveryMethod();

            Assert.That(_driver.FindElement(By.Id("collapse-payment-method")).Displayed, Is.EqualTo(true), "The payment method section should be visible after continuing delivery method.");
        }

        [Test]
        public void TestAgreeToTermsCheckboxFunctionality()
        {
            _checkoutPage.AgreeToTerms();

            Assert.That(_driver.FindElement(By.Name("agree")).Selected, Is.EqualTo(true), "The agree to terms checkbox should be selected.");
        }


        [TearDown]
        public void TearDown()
        {
            // Close the browser after each test
            _driver.Quit();
        }
    }
}


