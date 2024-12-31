using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCartAutomation.Helpers
{
    public static class WebDriverManager
    {
        // This method is responsible for setting up and returning the WebDriver instance.
        public static IWebDriver CreateDriver()
        {
            var options = new ChromeOptions(); // Create Chrome options

         
            options.AddArgument("--start-maximized"); // Maximizes the browser window

            // Initialize the ChromeDriver with the specified options
            return new ChromeDriver(options);
        }
    }
}
