using CWS2POC.Pages;
using NUnit.Framework;
using CWS2POC.Utility;
using CWS2POC.Hooks;


public class DocumentsSteps
{
    private readonly DocumentsPage _DocumentsPage;

    public DocumentsSteps()
    {
        _DocumentsPage = new DocumentsPage(Hooks.Driver);
    }
}