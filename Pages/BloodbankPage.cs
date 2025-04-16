using CWS2POC.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CWS2POC.Pages
{
    /// <summary>
    /// Bloodbank page class.
    /// </summary>
    public class BloodbankPage
    {
        private IWebDriver Driver;

        /// <summary>
        /// Initialises instance of Bloodbank page class.
        /// </summary>
        /// <param name="Driver">Driver.</param>
        public BloodbankPage(IWebDriver Driver)
        {
            this.Driver = Driver;
        }
    }
}

