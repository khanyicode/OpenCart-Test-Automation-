using NUnit.Framework;
using OpenQA.Selenium;
using OpenCartAutomation.Helpers;
using OpenCartAutomation.Pages;

namespace OpenCartAutomation.Tests
{
    [TestFixture]
    public class HomePageTest
    {
        private IWebDriver _driver;
        private HomePage _homePage;

        [OneTimeSetUp]
        public void InitialSetup()
        {
            _driver = WebDriverManager.GetDriver();
            _homePage = new HomePage(_driver);
        }

        [SetUp]
        public void SetUp()
        {
            _driver.Navigate().GoToUrl("http://opencart.abstracta.us/");
        }

        [Test]
        public void SearchForProduct_ShouldDisplayResults()
        {
            _homePage.SearchProduct("Canon EOS 5D");
            Assert.That(_homePage.IsFeaturedProductDisplayed(), Is.True, 
                "Featured product displayed after search.");
        }

        [Test]
        public void AddToWishlist_ShouldRequireLogin()
        {
            _homePage.AddToWishlist("Canon EOS 5D");
            Assert.That(_homePage.IsLoginPromptDisplayed(), Is.True, 
                "Login prompt did not appear for wishlist.");
        }

        [Test]
        public void EmptySearch_ShouldNotCrashApplication()
        {
            _homePage.SearchProduct("");
            Assert.That(_homePage.IsSearchResultDisplayed(), Is.False, 
                "Search results displayed for an empty query.");
        }

        [Test]
        public void NavigateToLoginPage_ShouldRedirectSuccessfully()
        {
            _homePage.ClickMyAccount();
            _homePage.SelectLoginOption();
            Assert.That(_homePage.IsLoginPageDisplayed(), Is.True, 
                "Login page was not displayed.");
        }

        [OneTimeTearDown]
        public void FinalCleanup()
        {
            WebDriverManager.CloseDriver();
        }
    }
}