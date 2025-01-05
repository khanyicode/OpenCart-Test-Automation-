using NUnit.Framework;
using OpenCartAutomation.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCartAutomation.Tests
{
    public class LoginTests
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://opencart.abstracta.us/index.php?route=account/login");
            _loginPage = new LoginPage(_driver);
        }

        [Test]
        public void Login_WithValidCredentials_ShouldSucceed()
        {
            _loginPage.Login("khanyisilemesha@gmail.com", "D7avFH~W4sMw@mN");
            Assert.That(_driver.Url, Is.EqualTo("https://opencart.abstracta.us/index.php?route=account/account"));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
