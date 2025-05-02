using CWS2POC.Pages;
using NUnit.Framework;
using CWS2POC.Utility;
using CWS2POC.Hooks;
using AventStack.ExtentReports.Gherkin.Model;
using OpenQA.Selenium;
using ABUHB.AuthorizationServer;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Step definitions for ETR-related feature scenarios.
/// Relies on Page Object Moodels.
/// </summary>
[Binding]
public class ETRCWS2Steps
{
    private readonly LoginPage _loginPage;
    private readonly HomePage _homePage;
    /*private readonly ElectronicTestRequestPage _testRequestPage;*/

    /// <summary>
    /// Initialises a new instance of the <see cref="ETRCWS2Steps"/> class.
    /// </summary>
    public ETRCWS2Steps()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer(TestInputs.ConnectionString);
        var options = optionsBuilder.Options;

        _loginPage = new LoginPage(Hooks.Driver, options);
        _homePage = new HomePage(Hooks.Driver, options);
        /*_testRequestPage = new ElectronicTestRequestPage(Hooks.Driver, options);*/
    }

    [Given(@"an user with rol_ETR_RequestTests role can log in with valid credentials")]
    public async Task GivenUserETRRoleCanLogIn()
    {
        await _loginPage.DeleteAllRolesAndPersona(TestInputs.Id1);
        string[] roleIds = { TestInputs.CWSABasicUser_Id, TestInputs.PatientSearchBasicUser_Id, TestInputs.ETR_RequestTest_Id };
        await _loginPage.AssignRoleToUser(roleIds, TestInputs.Id1);

        _homePage.Login(TestInputs.Username1, TestInputs.Password1);
        string title = BrowserActions.GetPageTitle(Hooks.Driver);
        Assert.That(title == "Home Page", Is.True, $"Unexpected page title: {title}");
    }

    [Given(@"an user without rol_ETR_RequestTests role can log in with valid credentials")]
    public async Task GivenUserNoETRRoleCanLogIn()
    {
        await _loginPage.DeleteAllRolesAndPersona(TestInputs.Id1);
        string[] roleIds = { TestInputs.CWSABasicUser_Id, TestInputs.PatientSearchBasicUser_Id};
        await _loginPage.AssignRoleToUser(roleIds, TestInputs.Id1);

        _homePage.Login(TestInputs.Username1, TestInputs.Password1);
        string title = BrowserActions.GetPageTitle(Hooks.Driver);
        Assert.That(title == "Home Page", Is.True, $"Unexpected page title: {title}");
    }

    [Given(@"an user with relevant roles can log in with valid credentials")]
    public async Task GivenUserCanLogIn()
    {
        await _loginPage.DeleteAllRolesAndPersona(TestInputs.Id1);
        string[] roleIds = { TestInputs.CWSABasicUser_Id, TestInputs.PatientSearchBasicUser_Id, TestInputs.ETR_RequestTest_Id};
        await _loginPage.AssignRoleToUser(roleIds, TestInputs.Id1);

        _homePage.Login(TestInputs.Username1, TestInputs.Password1);
        string title = BrowserActions.GetPageTitle(Hooks.Driver);
        Assert.That(title == "Home Page", Is.True, $"Unexpected page title: {title}");
    }
    
    [Given(@"the user is on the Electronic Test Request screen")]
    public async Task GivenTheUserIsOnTheElectronicTestRequestScreen()
    {
        await _loginPage.DeleteAllRolesAndPersona(TestInputs.Id1);
        string[] roleIds = { TestInputs.CWSABasicUser_Id, TestInputs.PatientSearchBasicUser_Id, TestInputs.ETR_RequestTest_Id };
        await _loginPage.AssignRoleToUser(roleIds, TestInputs.Id1);

        _homePage.Login(TestInputs.Username1, TestInputs.Password1);
        string title = BrowserActions.GetPageTitle(Hooks.Driver);
        Assert.That(title == "Home Page", Is.True, $"Unexpected page title: {title}");

        string urlETR = TestInputs.ETR_url;
        BrowserActions.NavigateTo(Hooks.Driver, urlETR);
        Assert.That(BrowserActions.GetPageTitle(Hooks.Driver), Is.EqualTo("WCP Reverse Stapling - CWS2"));
    }

    [Given(@"the user is on the Electronic Test Request screen with active ETR")]
    public async Task GivenTheUserIsOnTheETR()
    {
        await _loginPage.DeleteAllRolesAndPersona(TestInputs.Id1);
        string[] roleIds = { TestInputs.CWSABasicUser_Id, TestInputs.PatientSearchBasicUser_Id, TestInputs.ETR_RequestTest_Id };
        await _loginPage.AssignRoleToUser(roleIds, TestInputs.Id1);

        _homePage.Login(TestInputs.Username1, TestInputs.Password1);
        string title = BrowserActions.GetPageTitle(Hooks.Driver);
        Assert.That(title == "Home Page", Is.True, $"Unexpected page title: {title}");

        string urlETR = TestInputs.ETR_url;
        BrowserActions.NavigateTo(Hooks.Driver, urlETR);
        Assert.That(BrowserActions.GetPageTitle(Hooks.Driver), Is.EqualTo("WCP Reverse Stapling - CWS2"));

        bool isVisible = BrowserActions.IsElementVisible(Hooks.Driver, Locators.RequestTestBtt);
        Assert.That(isVisible, Is.True);
        BrowserActions.Click(Hooks.Driver, Locators.RequestTestBtt);
        BrowserActions.Wait(Hooks.Driver, Locators.ExitWCPBtt);
       
    }

    [When(@"the user navigates to ETR screen")]
    public void TheUserNavigatesToETR()
    {
        BrowserActions.Click(Hooks.Driver, Locators.PatientSearch);
        string pageTitle = BrowserActions.GetPageTitle(Hooks.Driver);
        Assert.That(pageTitle, Is.EqualTo("Find a Patient"));
        BrowserActions.SendKeys(Hooks.Driver, Locators.SearchBox_SBX, TestInputs.crn1);
        BrowserActions.Click(Hooks.Driver, Locators.ETR);
        string html = BrowserActions.GetPageHtml(Hooks.Driver);
    }

    [When(@"the user clicks 'Patient Search' on the side bar")]
    public void TheUserClickPatientSearch()
    {
        BrowserActions.Click(Hooks.Driver, Locators.PatientSearch);
        string pageTitle = BrowserActions.GetPageTitle(Hooks.Driver);
        Assert.That(pageTitle, Is.EqualTo("Find a Patient"));
    }

    [When(@"the user inputs a valid crn and clicks 'ETR'")]
    public void TheUserInputsCRN()
    {
        BrowserActions.SendKeys(Hooks.Driver, Locators.SearchBox_SBX, TestInputs.crn1);
        BrowserActions.Click(Hooks.Driver, Locators.ETR);
        string html = BrowserActions.GetPageHtml(Hooks.Driver);
        /*BrowserActions.WaitUntilHtmlChanges(Hooks.Driver, html, TimeSpan.FromSeconds(10));*/
    }

    

    [When(@"user clicks 'Request Test' button")]
    public void WhenUserClicksReqTest()
    {
        bool isVisible = BrowserActions.IsElementVisible(Hooks.Driver, Locators.RequestTestBtt);
        Assert.That(isVisible, Is.True);
        BrowserActions.Click(Hooks.Driver, Locators.RequestTestBtt);
    }

    [When(@"user clicks 'Back to CWS' button")]
    public void WhenUserClicksExitWCP()
    {
        
        bool isVisible = BrowserActions.IsElementVisible(Hooks.Driver, Locators.ExitWCPBtt);
        Assert.That(isVisible, Is.True);
        string initialHTML = BrowserActions.GetPageHtml(Hooks.Driver);
        BrowserActions.Click(Hooks.Driver, Locators.ExitWCPBtt);
        BrowserActions.WaitForTitle(Hooks.Driver, "Patient Master", TimeSpan.FromSeconds(10));

    }

    [Then(@"the user can access the screen successfully")]
    public void ThenUserIsOnETR()
    {
        Assert.That(BrowserActions.GetPageTitle(Hooks.Driver), Is.EqualTo("WCP Reverse Stapling - CWS2"));
    }

    [Then(@"the user is displayed Denied Access screen")]
    public void ThenUserIsNOTOnETR()
    {
        Assert.That(BrowserActions.GetPageTitle(Hooks.Driver), Is.EqualTo("Access Denied - CWS2"));
    }

    [Then(@"the user is redireted to the ETR screen")]
    public void TheUserIsOnETRScreen()
    {
        Assert.That(BrowserActions.GetPageTitle(Hooks.Driver), Is.EqualTo("WCP Reverse Stapling - CWS2"));
    }

    [Then(@"'Request Test' button is hidden, 'Back to CWS' button appears with ETR hidden div")]
    public void ETRShows()
    {
        BrowserActions.Wait(Hooks.Driver, Locators.ExitWCPBtt);
        BrowserActions.Wait(Hooks.Driver, Locators.ETRHiddenDiv);

        bool isNotVisible = BrowserActions.IsElementVisible(Hooks.Driver, Locators.RequestTestBtt);
        Assert.That(isNotVisible, Is.False);


        bool isVisible = BrowserActions.IsElementVisible(Hooks.Driver, Locators.ExitWCPBtt);
        Assert.That(isVisible, Is.True);

        bool hasAppeared = BrowserActions.IsElementVisible(Hooks.Driver, Locators.ETRHiddenDiv);
        Assert.That(hasAppeared, Is.True);
    }

    [Then(@"user is redirected to CWS pathology")]
    public void ETRVanish()
    {
        
        string title = BrowserActions.GetPageTitle(Hooks.Driver);

        Assert.That(title, Is.EqualTo("Patient Master"));
    }
}

