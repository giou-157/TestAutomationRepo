using CWS2POC.Pages;
using NUnit.Framework;
using CWS2POC.Utility;
using CWS2POC.Hooks;

public class BloodbankSteps
{
    private readonly BloodbankPage _BloodbankPage;

    public BloodbankSteps()
    {
        _BloodbankPage = new BloodbankPage(Hooks.Driver);
    }

}
