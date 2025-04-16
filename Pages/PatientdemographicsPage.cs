using CWS2POC.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CWS2POC.Pages
{
    /// <summary>
    /// Patient demographic page class.
    /// </summary>
    public class PatientdemographicsPage
    {
        private IWebDriver Driver;

        /// <summary>
        /// Initialises instance of patient demographics page.
        /// </summary>
        /// <param name="Driver">Driver.</param>
        public PatientdemographicsPage(IWebDriver Driver)
        {
            this.Driver = Driver;
        }
    }
}