using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

public class WebBuyACarTests : IDisposable
{
    private readonly IWebDriver driver;

    public WebBuyACarTests()
    {
        // Initialize Chrome driver
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [Fact]
    public void ClickButtonOnWebBuyACar()
    {
        // Navigate to the website
        driver.Navigate().GoToUrl("https://www.webuyanycar.com/");

        // Find the button (update selector based on the actual button)
        IWebElement button = driver.FindElement(By.Id("btn-go")); // Replace "button-id" with actual ID

        // Click the button
        button.Click();

        // Add assertions to validate post-click behavior
        Assert.Contains("https://www.webuyanycar.com/", driver.Url); // Example validation
    }

    public void Dispose()
    {
        // Close the browser
        driver.Quit();
    }
}
