# Web Browser Automation Project

## Overview

This project focuses on **web browser automation** using the **OpenCart** website as the testing ground. Web automation is an essential skill in test automation, allowing for efficient testing of web applications by simulating user interactions. This README outlines the project's objectives, tools used, and guidelines for creating effective automated tests.

## Objectives

The primary goals of this project are to:

- Demonstrate the ability to automate complex user scenarios that involve multiple web pages.
- Interact with various web elements such as dropdown menus, checkboxes, text fields, buttons, links, alerts, file uploads, and frames.
- Implement clean and maintainable test code utilizing design patterns like the **Page Object Model** or the **Screenplay Pattern**.

## Tools and Technologies

-  **Selenium WebDriver**: The primary tool for automating web browsers.
-  **NUnit **: The testing framework used for structuring tests.
-  **C#**: The programming language used for writing test scripts.
-  **Visual Studio or visual studio code **: Recommended IDE for developing C# applications.
- **NuGet**: Package manager for .NET to install dependencies.

## Installation

To set up the project on your local machine, follow these steps:

1. **fork the respository**:
2. **Open the Project in Visual Studio or visual studio code **:
- Open Visual Studio and load the solution file (`.sln`) from the cloned repository.

3. **Install Selenium WebDriver and NUnit**:
- Open the NuGet Package Manager Console in Visual Studio (Tools > NuGet Package Manager > Package Manager Console).
- Run the following commands:
  ```
  Install-Package Selenium.WebDriver
  Install-Package Selenium.WebDriver.ChromeDriver
  Install-Package NUnit  # or Install-Package xunit if using xUnit
  ```

4. **Set Up WebDriver**:
- Ensure that ChromeDriver (or another driver if using a different browser) is included in  project references.

## Running Tests

To execute the automated tests, follow these steps:

1. **Build the Solution**:
- In Visual Studio, build your solution (Build > Build Solution).

2. **Run Tests**:
- If using NUnit:
  - Open the Test Explorer (Test > Windows > Test Explorer) and run all tests from there.
- If using xUnit:
  - You can run tests directly from the Test Explorer or use a command line tool like `dotnet test`.

## Summary of the Tests

### Test Case Structure

Each test case  includes:

- **Description**: A brief overview of what the test does.
- **Setup**: Any necessary preconditions or initializations.
- **Execution Steps**: Detailed steps outlining user interactions with the web application.
- **Assertions**: Expected outcomes to verify functionality.

### Example Test Case

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("http://opencart.com");
    }

    [Test]
    public void TestLogin()
    {
        // Execution Steps
        var loginButton = driver.FindElement(By.LinkText("Login"));
        loginButton.Click();

        var usernameField = driver.FindElement(By.Id("input-username"));
        usernameField.SendKeys("john");

        var passwordField = driver.FindElement(By.Id("input-password"));
        passwordField.SendKeys("demo");

        var submitButton = driver.FindElement(By.XPath("//input[@value='Login']"));
        submitButton.Click();

        // Assertion
        Assert.IsTrue(driver.Title.Contains("Dashboard"));
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    } }



