using CWS2POC.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CWS2POC.Pages
{
    /// <summary>
    /// ATD Page class.
    /// </summary>
    public class ATDPage
    {
        private IWebDriver Driver;

        /// <summary>
        /// Initialises instance of ATDPage class.
        /// </summary>
        /// <param name="Driver">Driver.</param>
        public ATDPage(IWebDriver Driver)
        {
            this.Driver = Driver;
        }
    }
}
