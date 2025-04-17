using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWS2POC.Pages
{
    /// <summary>
    /// Electronic Test Request page class.
    /// </summary>
    public class ElectronicTestRequestPage
    {
        private IWebDriver Driver;

        /// <summary>
        /// Initialises instance of Electronic Test Request page class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public ElectronicTestRequestPage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
