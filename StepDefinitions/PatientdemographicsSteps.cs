using CWS2POC.Pages;
using NUnit.Framework;
using CWS2POC.Utility;
using CWS2POC.Hooks;

public class PatientdemographicsSteps
{
    private readonly PatientdemographicsPage _PatientdemographicsPage;

    public PatientdemographicsSteps()
    {
        _PatientdemographicsPage = new PatientdemographicsPage(Hooks.Driver);
    }

}
