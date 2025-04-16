using ABUHB.AuthorizationServer;
using CWS2POC.Hooks;
using CWS2POC.Pages;
using CWS2POC.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Text.Json;

/// <summary>
/// Defines the steps to test Role-Persona conversion feature.
/// </summary>
[Binding]
public class PersonaToRoleSteps
{
    private readonly LoginPage _loginPage;
    private readonly HomePage _homePage;
    private bool _isActiveUser;
    private string _userId;
    private Guid _personaId;

    /// <summary>
    /// Initialise instance of the test.
    /// </summary>
    public PersonaToRoleSteps()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer(TestInputs.ConnectionString);
        var options = optionsBuilder.Options;

        _userId = TestInputs.Id1;
        _personaId = new Guid(TestInputs.AutomatedTestPersona_Id);

        _loginPage = new LoginPage(Hooks.Driver, options);
        _homePage = new HomePage(Hooks.Driver, options);
    }

    /// <summary>
    /// Removes all roles and persona associated to the user.
    /// </summary>
    [Given(@"the user has no role or personas associated to it")]
    public async Task GivenTheUserHasNoRole()
    {
        _loginPage.EnsureLoginPageTitleIsClickable();
        _loginPage.LoginTextValidation();
         await _loginPage.DeleteAllRolesAndPersona(_userId);
    }

    /// <summary>
    /// Sets up user role(s)/persona(s).
    /// Clears user of all associated roles and personas, and assigns roles and personas relevant to the test case.
    /// </summary>
    [Given(@"the user has at least one role or persona associated to it")]
    public async Task GivenTheUserHasPermissions()
    {
        await _loginPage.DeleteAllRolesAndPersona(_userId);
        await _loginPage.EmptyPersonaFromRoles(_personaId);

        _loginPage.EnsureLoginPageTitleIsClickable();
        _loginPage.LoginTextValidation();
        string[] roleIds = { TestInputs.CWSABasicUser_Id };
        await _loginPage.AssignRoleToUser(roleIds, _userId);

        string[] rolesIds = { TestInputs.PatientSearchBasicUser_Id, TestInputs.WardListBasicUser_Id };
       
        await _loginPage.AssignRolesToPersona(rolesIds, _personaId);

        await _loginPage.AssignPersonaToUser(_personaId, _userId);
    }


    /// <summary>
    /// Enters credentials to log in.
    /// </summary>
    /// <param name="username">Username.</param>
    /// <param name="password">Password.</param>
    [When(@"user enters the valid credentials (.*) and (.*)")]
    public void WhenTheUserEntersTheCredentials(string username, string password)
    {
        _loginPage.EnterUsername(username);
        _loginPage.EnterPassword(password);
    }

    /// <summary>
    /// Clicks on login button.
    /// </summary>
    [When(@"the user clicks the login button")]
    public void WhenTheUserClicksTheLoginButton()
    {
        _loginPage.ClickLoginButton();
        _loginPage.TurnStatusToActive(_userId).Wait(); // Turn status back to active to avoid disruption.
    }

    /// <summary>
    /// Checks Denied Access message is displayed to the user in all parts of the system..
    /// </summary>
    /// <param name="deniedAccessMessage">Denied access message to display.</param>
    [Then(@"the user is displayed (.*) for any functionality")]
    public void ThenTheUserLogsInSuccessfully(string deniedAccessMessage)
    {
        string message = _homePage.GetDeniedAccessMessage();
        Assert.That(message, Is.EqualTo(deniedAccessMessage));

        _homePage.GoToPatientSearch();
        Assert.That(message, Is.EqualTo(deniedAccessMessage));

        _homePage.GoToWardList();
        Assert.That(message, Is.EqualTo(deniedAccessMessage));

        _homePage.GoToUserSettings();
        Assert.That(message, Is.EqualTo(deniedAccessMessage));
    }

    /// <summary>
    /// Checks the user can land on all functionalities associated to its role(s) and persona(s)
    /// </summary>
    /// <param name="pageNamesJson"></param>
    [Then(@"the user can access the relevant functionalities and pages (.*)")]
    public void ThenTheUserHasAccess(string pageNamesJson)
    {
        var pageNames = JsonSerializer.Deserialize<string[]>(pageNamesJson) ?? throw new InvalidOperationException("Deserialization returned null"); ;

        string homePage = _homePage.GetPageTitle();
        Assert.That(homePage, Is.EqualTo(pageNames[0]));

        _homePage.GoToPatientSearch();
        string patientSearch = _homePage.GetPageTitle();
        Assert.That(patientSearch, Is.EqualTo(pageNames[1]));

        _homePage.GoToWardList();
        string wardList = _homePage.GetPageTitle();
        Assert.That(wardList, Does.Contain(pageNames[2]));

    }

}
