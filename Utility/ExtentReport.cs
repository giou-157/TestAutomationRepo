using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWS2POC.Utility
{
    /// <summary>
    /// A helper class for managing ExtentReports for automation testing.
    /// </summary>
    public class ExtentReport
    {
        // Static variables for ExtentReports instance and test objects.
        public static ExtentReports _extentReports = null!;
        public static ExtentTest _feature = null!;
        public static ExtentTest _scenario = null!;

        // Directory paths for storing test result files.
        public static String dir = AppDomain.CurrentDomain.BaseDirectory;
        public static String testResultPath = dir.Replace("bin\\Debug\\net6.0", "TestResults");

        /// <summary>
        /// Initializes the ExtentReports with configuration settings.
        /// </summary>
        public static void ExtentReportInit()
        {
            var htmlReporter = new ExtentHtmlReporter(testResultPath);
            htmlReporter.Config.ReportName = "Automation Status Report";
            htmlReporter.Config.DocumentTitle = "Automation Status Report";
            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Start();

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
            _extentReports.AddSystemInfo("Application", "CWS2");
            _extentReports.AddSystemInfo("Browser", "Edge");
            _extentReports.AddSystemInfo("OS", "Windows");
        }

        /// <summary>
        /// Initializes a simple ExtentReports instance with a default report file.
        /// </summary>
        public static void InitReports()
        {
            var htmlReporter = new ExtentHtmlReporter("report.html");
            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
        }

        /// <summary>
        /// Flushes the ExtentReports instance to write results to the file.
        /// </summary>
        public static void ExtentReportTearDown()
        {
            _extentReports.Flush();
        }

        /// <summary>
        /// Captures a screenshot and saves it to the test results directory.
        /// </summary>
        /// <param name="driver">The WebDriver instance for capturing the screenshot.</param>
        /// <param name="scenarioContext">The ScenarioContext for identifying the scenario.</param>
        /// <returns>The file path of the saved screenshot.</returns>
        public string addScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string screenshotLocation = Path.Combine(testResultPath, scenarioContext.ScenarioInfo.Title + ".png");
            screenshot.SaveAsFile(screenshotLocation);
            return screenshotLocation;
        }
    }

}
