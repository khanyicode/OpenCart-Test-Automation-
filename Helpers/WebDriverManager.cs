using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OpenCartAutomation.Helpers
{
    public static class WebDriverManager
    {
        public static IWebDriver CreateDriver()
        {
            var options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            return new ChromeDriver(options);
        }
    }
}
