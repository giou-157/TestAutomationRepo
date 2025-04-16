using AventStack.ExtentReports.Gherkin.Model;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using OpenQA.Selenium.Interactions;

namespace CWS2POC.Utility
{
    /// <summary>
    /// Browser actions class.
    /// </summary>
    public static class BrowserActions
    {
        /// <summary>
        /// Sends text input to a web element identified by its XPath.
        /// </summary>
        /// <param name="driver">The WebDriver instance.</param>
        /// <param name="locator">XPath of the web element.</param>
        /// <param name="text">Text to be entered.</param>
        public static void SendKeys(IWebDriver driver, string locator, string text)
        {
            driver.FindElement(By.XPath(locator)).SendKeys(text);
        }

        /// <summary>
        /// Clicks on a web element identified by its XPath.
        /// </summary>
        /// <param name="driver">The WebDriver instance.</param>
        /// <param name="locator">XPath of the web element.</param>
        public static void Click(IWebDriver driver, string locator)
        {
            driver.FindElement(By.XPath(locator)).Click();
        }

        /// <summary>
        /// Retrieves the text of a web element identified by its XPath.
        /// </summary>
        /// <param name="driver">The WebDriver instance.</param>
        /// <param name="locator">XPath of the web element.</param>
        /// <returns>Text of the web element.</returns>
        public static String GetText(IWebDriver driver, string locator)
        {
            return driver.FindElement(By.XPath(locator)).Text;
        }

        /// <summary>
        /// Checks if a string is present in the page source.
        /// </summary>
        /// <param name="driver">The WebDriver instance.</param>
        /// <param name="searchString">The string to search for.</param>
        /// <returns>True if the string is present; otherwise, false.</returns>
        public static bool IsStringPresentInPageSource(IWebDriver driver, string searchString)
        {
            return driver.PageSource.Contains(searchString);
        }

        /// <summary>
        /// Types a date character by character into a web element, replacing slashes.
        /// </summary>
        /// <param name="driver">The WebDriver instance.</param>
        /// <param name="locator">XPath of the web element.</param>
        /// <param name="date">The date string to type.</param>
        public static void TypeDateOneByOne(IWebDriver driver, String locator, string date)
        {
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.Tab).SendKeys(Keys.Tab).SendKeys(Keys.Enter).Perform();

            foreach (char c in date.Replace("/", ""))
            {
                actions.SendKeys(c.ToString()).Perform();
            }
        }

        /// <summary>
        /// Checks if the expected text is present in a web element and asserts it.
        /// </summary>
        /// <param name="driver">The WebDriver instance.</param>
        /// <param name="locator">XPath of the web element.</param>
        /// <param name="expectedText">The expected text to validate.</param>
        /// <returns>True if the expected text matches the actual text; otherwise, false.</returns>
        public static bool IsTextPresentAndAssert(IWebDriver driver, string locator, string expectedText)
        {
            string actualText = driver.FindElement(By.XPath(locator)).Text;
            Console.WriteLine($"Actual Text from UI: {actualText}");
            return actualText.Equals(expectedText, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Validates that the expected text matches the actual text in a web element, throwing an exception if mismatched.
        /// </summary>
        /// <param name="driver">The WebDriver instance.</param>
        /// <param name="locator">XPath of the web element.</param>
        /// <param name="expectedText">The expected text to validate.</param>
        public static void ValidateTextPresentAndAssert(IWebDriver driver, string locator, string expectedText)
        {
            string actualText = driver.FindElement(By.XPath(locator)).Text;
            Console.WriteLine($"Actual Text from UI: {actualText}");
            if (!actualText.Equals(expectedText, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception($"Text mismatch: Expected '{expectedText}', but found '{actualText}'.");
            }
        }

        /// <summary>
        /// Checks if a name is present and displayed in a web element.
        /// </summary>
        /// <param name="driver">The WebDriver instance.</param>
        /// <param name="locator">XPath of the web element.</param>
        /// <returns>True if the name is present; otherwise, false.</returns>
        public static bool IsNamePresent(IWebDriver driver, string locator)
        {
            string Name = driver.FindElement(By.XPath(locator)).Text;
            if (Name != null)
            {
                Console.WriteLine($"Actual Text from UI: {Name}");
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
