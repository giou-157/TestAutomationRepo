using ABUHB.AuthorizationServer;
using CWS2POC.Utility;
using ABUHB.AuthorizationServer.Models.MembershipDatabase;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Microsoft.EntityFrameworkCore;

namespace CWS2POC.Pages
{
    /// <summary>
    /// Home Page class.
    /// </summary>
    public class HomePage
    {
        private IWebDriver Driver;
        private readonly DbContextOptions<ApplicationDbContext>? _options;

        /// <summary>
        /// Initialises instance of HomePage class.
        /// </summary>
        /// <param name="Driver">Driver.</param>
        public HomePage(IWebDriver Driver)
        {
            this.Driver = Driver;
        }

        /// <summary>
        /// Initialises instance of HomePage.
        /// </summary>
        /// <param name="Driver">Driver.</param>
        /// <param name="options">Db context.</param>
        public HomePage(IWebDriver Driver, DbContextOptions<ApplicationDbContext> options)
        {
            this.Driver = Driver;
            _options = options;
        }

        /// <summary>
        /// Logs user in.
        /// </summary>
        /// <param name="username">User username.</param>
        /// <param name="password">User password.</param>
        public void Login (string username, string password)
        {
            var loginPage = new LoginPage(Driver);
            loginPage.EnterUsername(username);
            loginPage.EnterPassword(password);
            loginPage.ClickLoginButton();

        }

        /// <summary>
        /// Gets title of the page the user is on.
        /// </summary>
        /// <returns>Page title.</returns>
        public string GetPageTitle()
        {
            string title = Driver.Title;
            return title;
        }

        /// <summary>
        /// Takes user to User Settings page.
        /// </summary>
        public void GoToUserSettings()
        {
            BrowserActions.Click(Driver, Locators.UserSettings);
        }

        /// <summary>
        /// Takes user to Patient Search page.
        /// </summary>
        public void GoToPatientSearch()
        {
            BrowserActions.Click(Driver, Locators.PatientSearch);
        }

        /// <summary>
        /// Takes user to Ward List page.
        /// </summary>
        public void GoToWardList()
        {
            BrowserActions.Click(Driver, Locators.WardList);
        }

        /// <summary>
        /// Takes user to CWS.
        /// </summary>
        public void GoToCWS()
        {
            BrowserActions.Click(Driver, Locators.CWS);
        }

        /// <summary>
        /// Gets Denied Access message.
        /// </summary>
        /// <returns>Denied access message.</returns>
        public string GetDeniedAccessMessage() 
        {
            return BrowserActions.GetText(Driver, Locators.MissingRole);
        }
    }
}
