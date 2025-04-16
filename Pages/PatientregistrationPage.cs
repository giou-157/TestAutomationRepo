using CWS2POC.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CWS2POC.Pages
{
    /// <summary>
    /// Patient registration page class.
    /// </summary>
    public class PatientregistrationPage
    {
        private IWebDriver Driver;

        /// <summary>
        /// Initialises instance of patient registration page.
        /// </summary>
        /// <param name="Driver">Driver.</param>
        public PatientregistrationPage(IWebDriver Driver)
        {
            this.Driver = Driver;
        }
    }
}
