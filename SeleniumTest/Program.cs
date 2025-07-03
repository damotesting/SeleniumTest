using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;
using System.Threading;

namespace SeleniumTest
{
    [TestFixture]
    public class DuckDuckGoSearchTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Initialize()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            // options.AddArgument("--headless"); // Optional to run headless

            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Navigate().GoToUrl("https://duckduckgo.com");
            TestContext.WriteLine("Opened DuckDuckGo homepage");
        }

        [Test]
        public void ExecuteSearchTest()
        {
            try
            {
                // Locate the search box
                var searchBox = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("searchbox_input")));
                searchBox.Clear();
                searchBox.Click();

                // Send full query at once
                searchBox.SendKeys("Selenium" + Keys.Enter);

                // Wait for title update or results to appear
                wait.Until(d => d.Title.ToLower().Contains("selenium"));

                TestContext.WriteLine("Page title after search: " + driver.Title);
                Assert.IsTrue(driver.Title.ToLower().Contains("selenium"), "Search result page title does not contain expected text.");
                
                // Take screenshot of the results page
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string screenshotPath = $"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                screenshot.SaveAsFile(screenshotPath);
                TestContext.WriteLine($"Screenshot saved: {screenshotPath}");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Error during test: " + ex.Message);
                throw;
            }
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
            TestContext.WriteLine("Closed the browser.");
        }
    }
}
