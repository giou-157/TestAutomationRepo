using CWS2POC.Pages;
using NUnit.Framework;
using CWS2POC.Utility;
using CWS2POC.Hooks;
using AventStack.ExtentReports.Gherkin.Model;
using SharpCompress.Common;
/*
/// <summary>
/// Dashboard test steps class.
/// </summary>
[Binding] 
public class DashboardSteps
{
    private readonly DashboardPage _dashboardPage;

    /// <summary>
    /// Initialises DashboardPage with the driver instance from Hooks.
    /// </summary>
    public DashboardSteps()
    {
        _dashboardPage = new DashboardPage(Hooks.Driver);
    }

    /// <summary>
    /// Simulates user selecting a mini application by its name.
    /// </summary>
    /// <param name="MiniApp">Name of the mini application to be selected.</param>
    [When(@"the user selects (.*)")]
    public void WhenTheUserSelects(String MiniApp)
    {
        _dashboardPage.ClickPatientSearchButton(MiniApp);
    }

    /// <summary>
    /// Simulates user clicking on the patient search button.
    /// </summary>
    [When(@"the user clicks on patient search")]
    public void WhenTheUserSelectsPS()
    {
        _dashboardPage.ClickPatientSearchButton();
    }

    /// <summary>
    /// Simulates user clicking on the Name field.
    /// </summary>
    [When(@"the user click in Name")]
    public void WhenTheUserClicksOnName()
    {
        _dashboardPage.ClickName();
    }

    /// <summary>
    /// Simulates user clicking on the Date of Birth field.
    /// </summary>
    [When(@"the user click in DOB")]
    public void WhenTheUserClicksOnDOB()
    {
        _dashboardPage.ClickDOB();
    }

    /// <summary>
    /// Simulates user entering a key and selecting a mini application.
    /// </summary>
    /// <param name="Key">The input key provided by the user.</param>
    /// <param name="MiniApp">Name of the mini application.</param>
    [When(@"the user enters the (.*) and clicks on (.*)")]
    public void WhenTheUserEntersTheAndClicksOnBloodBank(String Key, String MiniApp)
    {
        _dashboardPage.EnterInput(Key);
        _dashboardPage.ClickPatientSearchButton(MiniApp);
    }

    /// <summary>
    /// Simulates user selecting a gender radio button and clicking on a mini application.
    /// </summary>
    /// <param name="Gender">The gender selected by the user.</param>
    /// <param name="MiniApp">Name of the mini application.</param>
    [When(@"the user choose (.*) radio button and clicks on (.*)")]
    public void WhenTheUserSelectsTheGenderAndClicksOnBloodBank(string Gender, string MiniApp)
    {
        _dashboardPage.SelectGenderRdo(Gender);
        _dashboardPage.ClickPatientSearchButton(MiniApp);
    }

    /// <summary>
    /// Simulates user entering names and selecting a gender radio button for patient search.
    /// </summary>
    /// <param name="Forename">User's forename.</param>
    /// <param name="Surname">User's surname.</param>
    /// <param name="Gender">Selected gender radio button.</param>
    [When(@"the user enters (.*) followed by (.*) and selects (.*) radio button")]
    public void EntersParmsForPatientSearchByName(String Forename, String Surname, String Gender)
    {
        _dashboardPage.EnterNames(Forename, Surname);
        _dashboardPage.SelectGenderRdo(Gender);
    }

    /// <summary>
    /// Simulates user entering Date of Birth and selecting a gender radio button for patient search.
    /// </summary>
    /// <param name="dob">Date of Birth provided by the user.</param>
    /// <param name="Gender">Selected gender radio button.</param>
    [When(@"the user enters (.*) and selects (.*) radio button")]
    public void EntersParmsForPatientSearchByName(String dob, String Gender)
    {
        _dashboardPage.EnterDOB(dob);
        _dashboardPage.SelectGenderDOBRdo(Gender);
    }

    /// <summary>
    /// Simulates user clicking on a specific mini application.
    /// </summary>
    /// <param name="MiniApp">Name of the mini application.</param>
    [When(@"the user clicks on (.*) App")]
    public void SelectionofMiniApp(string MiniApp)
    {
        _dashboardPage.ClickPatientSearchButton(MiniApp);
    }

    /// <summary>
    /// Simulates validation of associated key and viewing it in the homepage.
    /// </summary>
    /// <param name="Key">The associated key for validation.</param>
    /// <param name="MiniApp">Name of the mini application.</param>
    [When, Then(@"the Associated (.*) can now viewed in (.*) Homepage along with first report")]
    public void ThenTheAssociatedCanNowViewedInSelectedHomepage(String Key, String MiniApp)
    {
        //_dashboardPage.ValidateBBText(MiniApp);
        _dashboardPage.ValidateHeader();
    }

    /// <summary>
    /// Simulates validation of associated names and viewing them in the mini application homepage.
    /// </summary>
    /// <param name="Forename">User's forename.</param>
    /// <param name="Surname">User's surname.</param>
    /// <param name="MiniApp">Name of the mini application.</param>
    [Then(@"the Associated (.*) and (.*) is visible in (.*) Homepage")]
    public void ThenTheAssociatedNamesInMiniappSearchResult(String Forename, String Surname, String MiniApp)
    {
        _dashboardPage.ValidateBBKey(MiniApp);
        _dashboardPage.ValidateNames(Forename, Surname);
        _dashboardPage.ClickFirstTestResult();
        _dashboardPage.ValidateHeader();
    }
}
*/