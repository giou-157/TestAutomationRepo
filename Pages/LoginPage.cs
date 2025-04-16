using ABUHB.AuthorizationServer;
using CWS2POC.Utility;
using CWS2POC;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Microsoft.EntityFrameworkCore;
using ABUHB.AuthorizationServer.Models.MembershipDatabase;
using Microsoft.AspNetCore.Identity;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace CWS2POC.Pages
{
    /// <summary>
    /// Login Page class.
    /// </summary>
    public class LoginPage
    {
        private IWebDriver Driver;
        private readonly DbContextOptions<ApplicationDbContext>? _options;

        /// <summary>
        /// Initialises instance of LoginPage.
        /// </summary>
        /// <param name="Driver">Driver.</param>
        public LoginPage(IWebDriver Driver)
        {
            this.Driver = Driver;
        }

        /// <summary>
        /// Initialise login page instance.
        /// </summary>
        /// <param name="Driver">Driver.</param>
        /// <param name="options">DB Context.</param>
        public LoginPage(IWebDriver Driver, DbContextOptions<ApplicationDbContext> options)
        {
            this.Driver = Driver;
            _options = options;


        }

        /// <summary>
        /// Checks the Login Page Title is clickable.
        /// </summary>
        /// <exception cref="Exception">Exception.</exception>
        public void EnsureLoginPageTitleIsClickable()
        {
            try
            {
                // Locate the element
                IWebElement loginPageTitleElement = Driver.FindElement(By.XPath(Locators.LoginPageTitle));

                // Check if the element is displayed and enabled, indicating it is clickable
                if (!loginPageTitleElement.Displayed || !loginPageTitleElement.Enabled)
                {
                    throw new Exception("The login page title element is not clickable.");
                }

                // Optional log message or action if the element is clickable
                Console.WriteLine("The login page title element is clickable.");
            }
            catch (NoSuchElementException)
            {
                // Handle the case where the element is not found
                throw new Exception("The login page title element was not found on the page.");
            }
            catch (Exception ex)
            {
                // Log other potential exceptions for debugging
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw; // Rethrow the exception if needed for the test to fail
            }
        }

        /// <summary>
        /// Turns Active status of the given user to True.
        /// </summary>
        /// <param name="id">User id.</param>
        public async Task TurnStatusToActive(string id)
        {
            var userId = id;
            if (_options == null)
                throw new ArgumentNullException(nameof(_options));

            using (var context = new ApplicationDbContext(_options))
            {
                var userProperty = await context.AspNetUserProperties!
                    .FirstOrDefaultAsync(u => u.UserId == userId);

                if (userProperty != null)
                {
                    userProperty.Active = true; // Set status to Active
                    await context.SaveChangesAsync();
                }
            }

        }

        /// <summary>
        /// Turns Active status of the given user to False.
        /// </summary>
        /// <param name="id">User id.</param>
        public async Task TurnStatusToInactive(string id)
        {
            var userId = id;
            if (_options == null)
                throw new ArgumentNullException(nameof(_options));

            using (var context = new ApplicationDbContext(_options))
            {
                var userProperty = await context.AspNetUserProperties!
                    .FirstOrDefaultAsync(u => u.UserId == userId);

                if (userProperty != null)
                {
                    userProperty.Active = false; // Set status to Inactive
                    await context.SaveChangesAsync();
                }
            }

        }

        /// <summary>
        /// Removes all roles associated to the given persona.
        /// </summary>
        /// <param name="personaId">Persona Id.</param>
        public async Task EmptyPersonaFromRoles(Guid personaId)
        {
            if (_options == null)
                throw new ArgumentNullException(nameof(_options));

            using (var context = new ApplicationDbContext(_options))
            {
                var personaRoleMappings = context.AspNetPersonaRoleMapping!
                                                 .Where(pr => pr.PersonaId == personaId);

                context.AspNetPersonaRoleMapping!.RemoveRange(personaRoleMappings);

                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Deletes all roles and personas associated to a given user.
        /// </summary>
        /// <param name="id">User id.</param>
        public async Task DeleteAllRolesAndPersona(string id)
        {
            if (_options == null)
                throw new ArgumentNullException(nameof(_options));

            using (var context = new ApplicationDbContext(_options))
            {
                var userRoles = context.Set<IdentityUserRole<string>>()
                               .Where(r => r.UserId == id);
                context.Set<IdentityUserRole<string>>().RemoveRange(userRoles);

                var userPersonaMappings = context.AspNetUserPersonaMapping!.Where(p => p.UserId == id);
                context.AspNetUserPersonaMapping!.RemoveRange(userPersonaMappings);

                await context.SaveChangesAsync();
            }

        }

        /// <summary>
        /// Assigns given persona to given user.
        /// </summary>
        /// <param name="personaId">Persona id.</param>
        /// <param name="userId">User id.</param>
        public async Task AssignPersonaToUser(Guid personaId, string userId)
        {
            if (_options == null)
                throw new ArgumentNullException(nameof(_options));

            using (var context = new ApplicationDbContext(_options))
            {
                // Create a new mapping record
                var newMapping = new AspNetUserPersona
                {
                    PersonaId = personaId,
                    UserId = userId,
                };

                // Add the new record to the DbSet
                context.AspNetUserPersonaMapping!.Add(newMapping);

                // Save changes to the database
                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Assigns given role(s) to given persona.
        /// </summary>
        /// <param name="roleIds">Role ids.</param>
        /// <param name="personaId">Persona id.</param>
        public async Task AssignRolesToPersona(string[] roleIds, Guid personaId)
        {
            if (_options == null)
                throw new ArgumentNullException(nameof(_options));

            using (var context = new ApplicationDbContext(_options))
            {
                foreach (var role in roleIds)
                {
                    var newMapping = new AspNetPersonaRole
                    {
                        RoleId = role,
                        PersonaId = personaId,
                    };

                    context.AspNetPersonaRoleMapping!.Add(newMapping);

                    await context.SaveChangesAsync();
                }
            }
        }

        /// <summary>
        /// Assigns given role(s) to given user.
        /// </summary>
        /// <param name="roleIds">Role ids.</param>
        /// <param name="userId">User id.</param>
        public async Task AssignRoleToUser(string[] roleIds, string userId)
        {
            if (_options == null)
                throw new ArgumentNullException(nameof(_options));

            using (var context = new ApplicationDbContext(_options))
            {
                foreach (var role in roleIds)
                {
                    var newMappings = roleIds.Select(roleId => new IdentityUserRole<string>
                    {
                        RoleId = roleId,
                        UserId = userId
                    });

                    context.Set<IdentityUserRole<string>>().AddRange(newMappings);

                    await context.SaveChangesAsync();
                }
            }
        }

        /// <summary>
        /// Enters username in respective textbox for login.
        /// </summary>
        /// <param name="username">Username.</param>
        public void EnterUsername(string username)
        {
            BrowserActions.SendKeys(Driver, Locators.UsernameField, username);
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Enters password in respective textbox for login.
        /// </summary>
        /// <param name="password">Password.</param>
        public void EnterPassword(string password)
        {
            BrowserActions.SendKeys(Driver, Locators.PasswordField, password);
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Gets Login Error.
        /// </summary>
        /// <returns>Error.</returns>
        public String GetLoginError()
        {
           return BrowserActions.GetText(Driver, Locators.ErrorMessage);
            
        }

        /// <summary>
        /// Clicks Login button.
        /// </summary>
        public void ClickLoginButton()
        {
            BrowserActions.Click(Driver, Locators.LoginButton);
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Logs user out.
        /// </summary>
        public void UserLogout()
        {
            BrowserActions.Click(Driver, Locators.Profile_DD);
            Thread.Sleep(2000);
            Actions actions = new Actions(Driver);
            actions.SendKeys(Keys.Tab).SendKeys(Keys.Tab).SendKeys(Keys.Enter).SendKeys(Keys.Tab).SendKeys(Keys.Tab).SendKeys(Keys.Enter).Perform();
            Thread.Sleep(4000);
        }

        /// <summary>
        /// Tests login validation.
        /// </summary>
        public void LoginTextValidation()
        {
            try
            {
                BrowserActions.ValidateTextPresentAndAssert(Driver, Locators.LoginPageTitle, TestInputs.LoginText);
                Console.WriteLine("Text validation passed.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Text validation failed: {ex.Message}");
            }

        }

        /// <summary>
        /// Gets title of the page the user is on.
        /// </summary>
        /// <returns>Title.</returns>
        public string GetPageTitle()
        {
            string title = Driver.Title;
            return title;
        }

        public bool IsDashboardDisplayed() => Driver.FindElement(By.XPath(Locators.DashboardPageTitle)).Displayed;
        public bool IsLoginErrorMsgDisplayed() => Driver.FindElement(By.XPath(Locators.ErrorMessage)).Displayed;
    }
}
