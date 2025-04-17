using CWS2POC.Pages;
using NUnit.Framework;
using CWS2POC.Utility;
using CWS2POC.Hooks;
using AventStack.ExtentReports.Gherkin.Model;

/// <summary>
/// Step definitions for ETR-related feature scenarios.
/// Relies on Page Object Moodels.
/// </summary>
[Binding]
public class ETRCWS2Steps
{
    private readonly LoginPage _loginPage;
    private readonly HomePage _homePage;
    private readonly ElectronicTestRequestPage _testRequestPage;

    /// <summary>
    /// Initialises a new instance of the <see cref="ETRCWS2Steps"/> class.
    /// </summary>
    public ETRCWS2Steps()
    {
        _loginPage = new LoginPage(Hooks.Driver);
        _homePage = new HomePage(Hooks.Driver);
        _testRequestPage = new ElectronicTestRequestPage(Hooks.Driver);
    }
    
    [Given(@"the user is on the Electronic Test Request screen")]
    public void GivenTheUserIsOnTheElectronicTestRequestScreen()
    {
        // ONCE IMPLEMENTED, HERE WE NEED TO GIVE ALL NECESSARY ROLES TO THE TEST USER BEFORE LOGIN

        _homePage.Login(TestInputs.Username1, TestInputs.Password1);
        Assert.That(BrowserActions.GetPageTitle(Hooks.Driver), Is.EqualTo("Home Page"));

        string urlETR = TestInputs.ETR_url;
        BrowserActions.NavigateTo(Hooks.Driver, urlETR);
        Assert.That(BrowserActions.GetPageTitle(Hooks.Driver), Is.EqualTo("WCP Reverse Stapling - CWS2"));
    }

    [Given(@"the user is on the Electronic Test Request screen with active ETR")]
    public void GivenTheUserIsOnTheETR()
    {
        // ONCE IMPLEMENTED, HERE WE NEED TO GIVE ALL NECESSARY ROLES TO THE TEST USER BEFORE LOGIN

        _homePage.Login(TestInputs.Username1, TestInputs.Password1);
        Assert.That(BrowserActions.GetPageTitle(Hooks.Driver), Is.EqualTo("Home Page"));

        string urlETR = TestInputs.ETR_url;
        BrowserActions.NavigateTo(Hooks.Driver, urlETR);
        Assert.That(BrowserActions.GetPageTitle(Hooks.Driver), Is.EqualTo("WCP Reverse Stapling - CWS2"));

        bool isVisible = BrowserActions.IsElementVisible(Hooks.Driver, Locators.RequestTestBtt);
        Assert.That(isVisible, Is.True);
        BrowserActions.Click(Hooks.Driver, Locators.RequestTestBtt);
        BrowserActions.Wait(Hooks.Driver, Locators.ExitWCPBtt);
    }

    [When(@"user clicks 'Request Test' button")]
    public void WhenUserClicksReqTest()
    {
        bool isVisible = BrowserActions.IsElementVisible(Hooks.Driver, Locators.RequestTestBtt);
        Assert.That(isVisible, Is.True);
        BrowserActions.Click(Hooks.Driver, Locators.RequestTestBtt);
    }

    [When(@"user clicks 'Exit WCP' button")]
    public void WhenUserClicksExitWCP()
    {
        bool isVisible = BrowserActions.IsElementVisible(Hooks.Driver, Locators.ExitWCPBtt);
        Assert.That(isVisible, Is.True);
        BrowserActions.Click(Hooks.Driver, Locators.ExitWCPBtt);
        BrowserActions.Wait(Hooks.Driver, Locators.RequestTestBtt);
    }

    [Then(@"'Request Test' button is hidden, 'Exit WCP' button appears with ETR hidden div")]
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

    [Then(@"'Request Test' button appears, 'Exit WCP' button and ETR div is hidden")]
    public void ETRVanish()
    {
        bool isVisible = BrowserActions.IsElementVisible(Hooks.Driver, Locators.RequestTestBtt);
        Assert.That(isVisible, Is.True);

        bool isNotVisible = BrowserActions.IsElementVisible(Hooks.Driver, Locators.ExitWCPBtt);
        Assert.That(isNotVisible, Is.False);
    }
}

