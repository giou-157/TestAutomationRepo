using ABUHB.AuthorizationServer;
using Microsoft.EntityFrameworkCore;
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
        private readonly DbContextOptions<ApplicationDbContext>? _options;

        /// <summary>
        /// Initialises instance of Electronic Test Request page class.
        /// </summary>
        /// <param name="driver">Driver.</param>
        public ElectronicTestRequestPage(IWebDriver driver)
        {
            Driver = driver;
        }

        /// <summary>
        /// Initialise ETR page instance.
        /// </summary>
        /// <param name="Driver">Driver.</param>
        /// <param name="options">DB Context.</param>
        public ElectronicTestRequestPage(IWebDriver Driver, DbContextOptions<ApplicationDbContext> options)
        {
            this.Driver = Driver;
            _options = options;


        }
    }
}
