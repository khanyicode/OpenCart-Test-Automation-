using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCartAutomation.Helpers
{
    public static class WebDriverManager
    {
        private static IWebDriver _driver;

        public static IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                var options = new ChromeOptions();
                options.AddArguments("--start-maximized");
                _driver = new ChromeDriver(options);
            }
            return _driver;
        }

        public static void CloseDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;
            }
        }
    }
}

