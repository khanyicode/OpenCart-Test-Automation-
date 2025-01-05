# Web Browser Automation Project

## Overview

This project focuses on **web browser automation** using the **OpenCart** website as the testing ground. Web automation is an essential skill in test automation, enabling efficient testing of web applications by simulating user interactions. This README outlines the project's objectives, tools, technologies, and guidelines for creating effective automated tests.

## Objectives

The primary goals of this project are to:

- Demonstrate the ability to automate complex user scenarios that involve multiple web pages.
- Interact with various web elements such as dropdown menus, checkboxes, text fields, buttons, links, alerts, file uploads, and frames.
- Implement clean and maintainable test code utilizing design patterns like the **Page Object Model** or **Screenplay Pattern**.

## Tools and Technologies

- **Selenium WebDriver**: The primary tool for automating web browsers.
- **NUnit**: The testing framework used for structuring tests.
- **C#**: The programming language used for writing test scripts.
- **Visual Studio or Visual Studio Code**: Recommended IDE for developing C# applications.
- **NuGet**: Package manager for .NET to install dependencies.

### Prerequisites

- .NET 6.0 or higher
- Visual Studio 2022 or VS Code
- ChromeDriver (or another browser driver of your choice)

## Design Patterns Implemented

### Page Object Model (POM)

- Encapsulates page behavior and elements.
- Provides clean separation of test and page logic.
- Makes tests more maintainable and readable.

## Installation

To set up the project on your local machine, follow these steps:

1. **Fork the repository**: Start by forking this repository to your own GitHub account.
2. **Clone the repository**: Clone the forked repository to your local machine using `git clone`.
3. **Open the Project in Visual Studio or Visual Studio Code**:
   - Open Visual Studio and load the solution file (`.sln`) from the cloned repository.
4. **Install Selenium WebDriver and NUnit**:
   - Open the NuGet Package Manager Console in Visual Studio (Tools > NuGet Package Manager > Package Manager Console).
   - Run the following commands:
     ```bash
     Install-Package Selenium.WebDriver
     Install-Package Selenium.WebDriver.ChromeDriver
     Install-Package NUnit
     ```

5. **Set Up WebDriver**:
   - Ensure that ChromeDriver (or another driver if using a different browser) is included in the project references.

## Running Tests

To execute the automated tests, follow these steps:

1. **Build the Solution**:
   - In Visual Studio, build your solution (Build > Build Solution).
2. **Run Tests**:
   - If using NUnit:
     - Open the Test Explorer (Test > Windows > Test Explorer) and run all tests from there.
   - If using xUnit:
     - You can run tests directly from the Test Explorer or use a command line tool like `dotnet test`.

## Test Case Structure

Each test case includes:

- **Description**: A brief overview of what the test does.
- **Setup**: Any necessary preconditions or initializations.
- **Execution Steps**: Detailed steps outlining user interactions with the web application.
- **Assertions**: Expected outcomes to verify functionality.

- ## Contributing

1. **Fork the repository**: Fork this repository to your own GitHub account.
2. **Create a feature branch**: Create a new branch for your feature or bugfix.
   ```bash
   git checkout -b feature-branch
   git commit -am 'Add new feature'
   git push origin feature-branch



### Example Test Case

```csharp
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
}




