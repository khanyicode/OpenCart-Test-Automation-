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
        [Test]
        public void RegisterWithValidDetails()
        {
            _registrationPage.EnterFirstName("Mpho");
            _registrationPage.EnterLastName("Mofokeng");
            _registrationPage.AgreeToTerms();
            _registrationPage.SubmitForm();

            Assert.That(_driver.PageSource.Contains("Your Account Has Been Created!"), Is.True, "Registration was not successful.");
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
        }
    }
}
