using CWS2POC.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CWS2POC.Pages
{
    /// <summary>
    /// Documents page class.
    /// </summary>
    public class DocumentsPage
    {
        private IWebDriver Driver;

        /// <summary>
        /// Initialises document page class instance.
        /// </summary>
        /// <param name="Driver">Driver.</param>
        public DocumentsPage(IWebDriver Driver)
        {
            this.Driver = Driver;
        }
    }
}