using CWS2POC.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CWS2POC.Pages
{
    /// <summary>
    /// Ward list page class.
    /// </summary>
    public class WardlistPage
    {
        private IWebDriver Driver;

        /// <summary>
        /// Initialises instance of ward list page.
        /// </summary>
        /// <param name="Driver">Driver.</param>
        public WardlistPage(IWebDriver Driver)
        {
            this.Driver = Driver;
        }
    }
}
