using CWS2POC.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CWS2POC.Pages
{
    /// <summary>
    /// Settings page class.
    /// </summary>
    public class SettingsPage
    {
        private IWebDriver Driver;

        /// <summary>
        /// Initialises instance of settings page.
        /// </summary>
        /// <param name="Driver">Driver.</param>
        public SettingsPage(IWebDriver Driver)
        {
            this.Driver = Driver;
        }

    }
}
