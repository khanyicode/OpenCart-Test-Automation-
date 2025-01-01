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

        [SetUp]
        public void SetUp()
        {
            _driver = WebDriverManager.CreateDriver();
            _homePage = new HomePage(_driver);
            _driver.Navigate().GoToUrl("http://opencart.abstracta.us/");
        }

        [Test]
        public void SearchForProduct_ShouldDisplayResults()
        {
            // Act
            _homePage.SearchProduct("Canon EOS 5D");

            // Assert
            Assert.That(_homePage.IsFeaturedProductDisplayed(), Is.True, 
                "Featured product  displayed after search.");
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
        }
    }
}