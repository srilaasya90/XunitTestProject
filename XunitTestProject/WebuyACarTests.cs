using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
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
        IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;

      


        string milage = (string)jsExecutor.ExecuteScript("return document.getElementById('MileageCheck').value;");

        string Manufacturer = (string)jsExecutor.ExecuteScript("return document.evaluate(\"(//div[contains(text(),'Manufacturer')]/following-sibling::div)[2]\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.textContent;");
        ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, 500);");
        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", button);
        // Create an instance of the Actions class
        Actions actions = new Actions(driver);

        // Perform drag and drop source element,target element
        actions.DragAndDrop(button, button).Perform();
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
