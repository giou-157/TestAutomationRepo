using CWS2POC.Pages;
using NUnit.Framework;
using CWS2POC.Utility;
using CWS2POC.Hooks;


public class WardlistSteps
{
    private readonly WardlistPage _WardlistPage;

    public WardlistSteps()
    {
        _WardlistPage = new WardlistPage(Hooks.Driver);
    }

}