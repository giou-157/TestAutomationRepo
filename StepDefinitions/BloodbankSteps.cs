using CWS2POC.Pages;
using NUnit.Framework;
using CWS2POC.Utility;
using CWS2POC.Hooks;

/// <summary>
/// Step definitions for blood bank-related feature scenarios.
/// Relies on Page Object Moodels.
/// </summary>
public class BloodbankSteps
{
    private readonly LoginPage _loginPage;
    private readonly HomePage _homePage;
    private readonly BloodbankPage _bloodbankPage;

    /// <summary>
    /// Initialises a new instance of the <see cref="BloodbankSteps"/> class.
    /// </summary>
    public BloodbankSteps()
    {
        _loginPage = new LoginPage(Hooks.Driver);
        _homePage = new HomePage(Hooks.Driver);
        _bloodbankPage = new BloodbankPage(Hooks.Driver);
    }

    // Background steps
    [Given(@"the user is on the Authorisation Server login page")]
    public void UserIsOnLoginPage()
    {
        _loginPage.DeleteAllRolesAndPersona(TestInputs.Id1).Wait();
        string[] roleIds = { TestInputs.PatientSearchBasicUser_Id  };
        _loginPage.AssignRoleToUser(roleIds, TestInputs.Id1).Wait();
        string pageTitle = BrowserActions.GetPageTitle(Hooks.Driver);
        Assert.That(pageTitle, Is.EqualTo("ABUHB Authorization Server"));
    }

    [When(@"the user enters some valid credentials")]
    public void WhenTheUserEntersValidCredentials()
    {
        _loginPage.EnterUsername(TestInputs.Username1);
        _loginPage.EnterPassword(TestInputs.Password1);
    }

    [When(@"the user proceeds to click login button")]
    public void WhenTheUserClicksOnTheLoginButton()
    {
        _loginPage.ClickLoginButton();
        string pageTitle = BrowserActions.GetPageTitle(Hooks.Driver);
        Assert.That(pageTitle, Is.EqualTo("Home Page"));
    }

    [When(@"the user clicks on patient search button")]
    public void WhenTheUserClicksOnPatientSearch()
    {
        BrowserActions.Click(Hooks.Driver, Locators.PatientSearch);
        string pageTitle = BrowserActions.GetPageTitle(Hooks.Driver);
        Assert.That(pageTitle, Is.EqualTo("Find a Patient"));
    }

    // Scenario 1:
    [When(@"the user enters the (.*) and clicks on (.*)")]
    public void WhenTheUserEntersTheKeyAndClicksOnMiniApp(string key, string miniApp)
    {
        // Implementation for searching by CRN/NHS number
        // Use 'key' and 'miniApp' parameters
    }

    // Scenario 2: 
    // Scenario 3:
}
