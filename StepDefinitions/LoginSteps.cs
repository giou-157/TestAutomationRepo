using CWS2POC.Pages;
using NUnit.Framework;
using CWS2POC.Utility;
using CWS2POC.Hooks;
using AventStack.ExtentReports.Gherkin.Model;

[Binding]
/// <summary>
/// Step definitions for login-related feature scenarios using SpecFlow.
/// Utilizes the Page Object Model to interact with the LoginPage.
/// </summary>
public class LoginSteps
{
    private readonly LoginPage _loginPage;

    /// <summary>
    /// Initializes a new instance of the <see cref="LoginSteps"/> class.
    /// Instantiates the LoginPage using the Selenium WebDriver from Hooks.
    /// </summary>
    public LoginSteps()
    {
        _loginPage = new LoginPage(Hooks.Driver);
    }

    /// <summary>
    /// Step to verify that the user is on the login page.
    /// Ensures the login page title is clickable and login text is visible.
    /// </summary>
    [Given, Then(@"the user is on the login page")]
    public void GivenTheUserIsOnTheLoginPage()
    {
        _loginPage.EnsureLoginPageTitleIsClickable();
        _loginPage.LoginTextValidation();
    }

    /// <summary>
    /// Step for entering valid credentials using values from test inputs.
    /// </summary>
    [When(@"the user enters valid credentials")]
    public void WhenTheUserEntersValidCredentials()
    {
        _loginPage.EnterUsername(TestInputs.Username);
        _loginPage.EnterPassword(TestInputs.Password);
    }

    /// <summary>
    /// Step for entering provided credentials (valid or invalid) dynamically from feature file.
    /// </summary>
    /// <param name="username">The username entered by the user.</param>
    /// <param name="password">The password entered by the user.</param>
    [When(@"I enter (.*) and (.*)")]
    public void WhenTheUserEntersInValidCredentials(string username, string password)
    {
        _loginPage.EnterUsername(username);
        _loginPage.EnterPassword(password);
    }

    /// <summary>
    /// Step to simulate the user clicking the login button.
    /// </summary>
    [When(@"the user clicks on the login button")]
    public void WhenTheUserClicksOnTheLoginButton()
    {
        _loginPage.ClickLoginButton();
    }

    /// <summary>
    /// Step to simulate the user logging out from the application.
    /// </summary>
    [When(@"the user logs out from the application")]
    public void WhenTheUserLogsouton()
    {
        _loginPage.UserLogout();
    }

    /// <summary>
    /// Step to assert the user has been successfully redirected to the dashboard.
    /// </summary>
    [Then(@"the user should be redirected to the dashboard")]
    public void ThenTheUserShouldBeRedirectedToTheDashboard()
    {
        Assert.That(_loginPage.IsDashboardDisplayed(), Is.True);
    }

    /// <summary>
    /// Step to assert the login error message matches the expected value.
    /// </summary>
    /// <param name="expectedErrorMessage">The expected error message text.</param>
    [Then(@"the error message should be (.*)")]
    public void ThenTheErrorMessageShouldBe(string expectedErrorMessage)
    {
        Assert.That(_loginPage.IsLoginErrorMsgDisplayed(), Is.True);
        Assert.That(_loginPage.GetLoginError(), Is.EqualTo(expectedErrorMessage));
    }
}