using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenCartAutomation.Pages;

namespace OpenCartAutomation.Tests
{
    public class RegistrationTests
    {
        private IWebDriver _driver;
        private RegistrationPage _registrationPage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://opencart.abstracta.us/index.php?route=account/register");
            _registrationPage = new RegistrationPage(_driver);
        }
    }

}