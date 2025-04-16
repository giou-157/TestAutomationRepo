using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports;
using BoDi;
using CWS2POC.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace CWS2POC.Hooks
{
    /// <summary>
    /// Hooks class.
    /// Defines the methods to run before/after tests.
    /// </summary>
    [Binding]
    public sealed class Hooks : ExtentReport
    {
        private readonly IObjectContainer _container;

        public static IWebDriver Driver { get; private set; } = null!;

        /// <summary>
        /// Initialises instance of the Hooks class.
        /// </summary>
        /// <param name="container">Container.</param>
        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// Runs before test run.
        /// </summary>
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Running before test run...");
            ExtentReportInit();
        }

        /// <summary>
        /// Runs sfter test run.
        /// </summary>
        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("Running after test run...");
            ExtentReportTearDown();
        }

        /// <summary>
        /// Runs before feature.
        /// </summary>
        /// <param name="featureContext">Feature context.</param>
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("Running before feature...");
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        /// <summary>
        /// Runs aftre feature.
        /// </summary>
        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("Running after feature...");
        }

        /// <summary>
        /// Runs inside tagged hooks in specflow.
        /// </summary>
        [BeforeScenario("@Testers")]
        public void BeforeScenarioWithTag()
        {
            Console.WriteLine("Running inside tagged hooks in specflow");
        }

        /// <summary>
        /// Runs before scenario.
        /// </summary>
        /// <param name="scenarioContext">Scenario context.</param>
        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario(ScenarioContext scenarioContext)
        {
            Console.WriteLine("Running before scenario..");
            Driver = new EdgeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(TestInputs.DevUrl);
            _container.RegisterInstanceAs<IWebDriver>(Driver);
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        /// <summary>
        /// Runs after scenario.
        /// </summary>
        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("Running after scenario...");
            var driver = _container.Resolve<IWebDriver>();

            if (driver != null)
            {
                driver.Quit();
            }
        }

        /// <summary>
        /// Runs after test step.
        /// </summary>
        /// <param name="scenarioContext">Scenario context.</param>
        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            Console.WriteLine("Running after step....");
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

            var driver = _container.Resolve<IWebDriver>();

            //When scenario passed
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName);
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName);
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName);
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName);
                }
            }

            //When scenario fails
            if (scenarioContext.TestError != null)
            {

                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
            }
        }

    }
}
