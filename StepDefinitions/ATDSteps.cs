using CWS2POC.Pages;
using NUnit.Framework;
using CWS2POC.Utility;
using CWS2POC.Hooks;

public class ATDSteps
{
    private readonly ATDPage _ATDPage;

    public ATDSteps()
    {
        _ATDPage = new ATDPage(Hooks.Driver);
    }

}