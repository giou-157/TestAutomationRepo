using ABUHB.AuthorizationServer;
using CWS2POC.Hooks;
using CWS2POC.Pages;
using CWS2POC.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using NUnit.Framework;

/// <summary>
/// Defines the steps to test the Active User feature.
/// Only Active users should be able to access CWS2.
/// </summary>
[Binding]
public class ActivityStatusLoginSteps
{
    private readonly LoginPage _loginPage;
    private bool _isActiveUser;

    /// <summary>
    /// Initialise instance of the test.
    /// </summary>
    public ActivityStatusLoginSteps()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer(TestInputs.ConnectionString);
        var options = optionsBuilder.Options;

        _loginPage = new LoginPage(Hooks.Driver, options);
    }

    /// <summary>
    /// Turn user into Active/Inactive depending on the test case.
    /// </summary>
    /// <param name="status">True = Active / False = Inactive </param>
    [Given(@"the user is (true|false)")]
    public async Task GivenTheUserWithStatus(string status)
    {
        _loginPage.EnsureLoginPageTitleIsClickable();
        _loginPage.LoginTextValidation();
        _isActiveUser = status == "true";

        if (status == "true")
        {
            await _loginPage.TurnStatusToActive(TestInputs.Id1);
        }
        else
        {
            await _loginPage.TurnStatusToInactive(TestInputs.Id1);
        }
    }

    /// <summary>
    /// Enters credentials to log in.
    /// </summary>
    /// <param name="username">Username.</param>
    /// <param name="password">Password.</param>
    [When(@"user enters valid credentials (.*) and (.*)")]
    public void WhenTheUserEntersCredentials(string username, string password)
    {
        _loginPage.EnterUsername(username);
        _loginPage.EnterPassword(password);
    }

    /// <summary>
    /// Clicks on login button.
    /// </summary>
    [When(@"the user clicks login button")]
    public void WhenTheUserClicksLoginButton()
    {
        _loginPage.ClickLoginButton();
        _loginPage.TurnStatusToActive(TestInputs.Id1).Wait(); // Turn status back to active to avoid disruption.
    }

    /// <summary>
    /// Checks user is on Home Page after login.
    /// </summary>
    /// <param name="pageName">Page name, here is Home Page.</param>
    [Then(@"the user is in (.*)")]
    public void ThenTheUserLogsInSuccessfully(string pageName)
    {
        string title = _loginPage.GetPageTitle();
        Assert.That(title, Is.EqualTo(pageName).Or.EqualTo("Access Denied"));
    }

    /// <summary>
    /// Checks the correct error message is displayed for Inactive user.
    /// </summary>
    /// <param name="expectedError">Error message that should be displayed.</param>
    [Then(@"the error message should be ""(.*)""")]
    public void ThenTheErrorMessageShouldBe(string expectedError)
    {
        Assert.That(_loginPage.IsLoginErrorMsgDisplayed(), Is.True);
        Assert.That(_loginPage.GetLoginError(), Is.EqualTo(expectedError));    
    }
}
