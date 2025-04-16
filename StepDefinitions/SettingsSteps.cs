using CWS2POC.Pages;
using NUnit.Framework;
using CWS2POC.Utility;
using CWS2POC.Hooks;

public class SettingsSteps
{
    private readonly SettingsPage _SettingsPage;

    public SettingsSteps()
    {
        _SettingsPage = new SettingsPage(Hooks.Driver);
    }

}
