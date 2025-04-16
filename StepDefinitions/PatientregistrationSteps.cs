using CWS2POC.Pages;
using NUnit.Framework;
using CWS2POC.Utility;
using CWS2POC.Hooks;

[Binding]
public class PatientregistrationSteps
{
    private readonly PatientregistrationPage _PatientregistrationPage;

    public PatientregistrationSteps()
    {
        _PatientregistrationPage = new PatientregistrationPage(Hooks.Driver);
    }

}
