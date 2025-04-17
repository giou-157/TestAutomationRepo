using System.Security.Cryptography.X509Certificates;

namespace CWS2POC.Utility
{
    /// <summary>
    /// A static class containing XPath locators for various elements across multiple pages of the application.
    /// </summary>
    public static class Locators
    {// Login Page Locators
        /// <summary>XPath for the title element on the login page.</summary>
        public static string LoginPageTitle = "//*[@id='loginContainer']/div[1]/table/tbody/tr/td[1]";
        /// <summary>XPath for the username input field.</summary>
        public static string UsernameField = "//*[@id='Email']";
        /// <summary>XPath for the password input field.</summary>
        public static string PasswordField = "//*[@id='Password']";
        /// <summary>XPath for the login button.</summary>
        public static string LoginButton = "//*[@id='loginButton']";
        /// <summary>XPath for the error message displayed upon login failure.</summary>
        public static string ErrorMessage = "//*[@id='loginMessage']";

        // Dashboard Page Locators
        /// <summary>XPath for the dashboard page title.</summary>
        public static string DashboardPageTitle = "/html/body/div/div[1]/main/h1";
        /// <summary>XPath for the Name tab.</summary>
        public static string NameTitle = "//*[@id='name-tab']";
        /// <summary>XPath for the Date of Birth (DOB) tab.</summary>
        public static string DOBTitle = "//*[@id='DOB-tab']";
        /// <summary>XPath for the Patient Search menu item.</summary>
        public static string PatientSearch = "//*[@id='NavItem 0']/span";
        /// <summary>XPath for the Ward List menu item.</summary>
        public static string WardList = "//*[@id='NavItem 1']/span";
        /// <summary>XPath for the CWS menu item.</summary>
        public static string CWS = "//*[@id='NavItem 2']/span[text()='CWS']";
        /// <summary>XPath for the User Settings menu item.</summary>
        public static string UserSettings = "//*[@id='NavItem 2']/span[text()='User Settings']";
        /// <summary>XPath for the patient search input box.</summary>
        public static string SearchBox_SBX = "//*[@id='txtPatientSearch']";
        /// <summary>XPath for the Blood Bank button.</summary>
        public static string BloodBank_BTN = "//*[@id='Blood Bank']";
        /// <summary>XPath for the ATD button.</summary>
        public static string ATD_BTN = "//*[@id='ATD']";
        /// <summary>XPath for the Patient Demographics button.</summary>
        public static string PatientDemo_BTN = "//*[@id='Patient Demographics']";
        /// <summary>XPath for the Documents button.</summary>
        public static string Documents_BTN = "//*[@id='Documents']";
        /// <summary>XPath for the Patient Registration button.</summary>
        public static string PatientRegistration_BTN = "//*[@id='Patient Registration']";
        /// <summary>XPath for the Forename input field.</summary>
        public static string Forename_TBX = "//*[@id='txtForename']";
        /// <summary>XPath for the Surname input field.</summary>
        public static string Surname_TBX = "//*[@id='txtSurname']";
        /// <summary>XPath for the Male radio button for name search.</summary>
        public static string Male_RBTN = "//*[@id='nameSearch']/div[2]/input";
        /// <summary>XPath for the Female radio button for name search.</summary>
        public static string Female_RBTN = "//*[@id='nameSearch']/div[3]/input";
        /// <summary>XPath for the Male radio button for DOB search.</summary>
        public static string Male_DOB_RBTN = "//*[@id='dobSearch']/div[1]/div[2]/input";
        /// <summary>XPath for the Female radio button for DOB search.</summary>
        public static string Female_DOB_RBTN = "//*[@id='dobSearch']/div[1]/div[3]/label";
        /// <summary>XPath for the user profile dropdown menu.</summary>
        public static string Profile_DD = "//*[@id='dropdownUser1']/span";
        /// <summary>XPath for the logout hyperlink.</summary>
        public static string Logout_HLink = "//*[@id='btnSignOut']";
        /// <summary>XPath for the Date of Birth input field.</summary>
        public static string DOB_TBX = "//*[@id='dob']";
        /// <summary>XPath for the missing role warning message.</summary>
        public static string MissingRole = "//h6[text()='You do not have the required access for this page']";

        // Miniapp Header Locators
        /// <summary>XPath for the Name field in the miniapp header.</summary>
        public static string Name = "//*[@id='nhs-patient-banner-2']/div[1]/div[1]/div[1]/div[1]/span";
        /// <summary>XPath for the Gender field in the miniapp header.</summary>
        public static string Sex_Field = "//*[@id='nhs-patient-banner-2']/div[1]/div[1]/div[2]/div[1]/div[1]/div/span";
        /// <summary>XPath for the Date of Birth field in the miniapp header.</summary>
        public static string DOB_Field = "//*[@id='nhs-patient-banner-2']/div[1]/div[1]/div[2]/div[1]/div[2]/div/span/span";
        /// <summary>XPath for the NHS field in the miniapp header.</summary>
        public static string NHS_Field = "//*[@id='pt-ids']/div[1]/div/span";
        /// <summary>XPath for the CRN field in the miniapp header.</summary>
        public static string CRN_Field = "//*[@id='pt-ids']/div[2]/div/span";
        /// <summary>XPath for the 'See More' dropdown in the miniapp header.</summary>
        public static string See_More_DD = "//*[@id='expandPatientBanner']";
        /// <summary>XPath for the Alerts field in the miniapp header.</summary>
        public static string Alerts_Field = "//*[@id='bannerDropDown']/div/div[1]/div[1]/h1";
        /// <summary>XPath for the Demographics field in the miniapp header.</summary>
        public static string Demographics_Field = "//*[@id='bannerDropDown']/div/div[1]/div[2]/h2";
        /// <summary>XPath for the Address field in the miniapp header.</summary>
        public static string Address_Field = "//*[@id='bannerDropDown']/div/div[1]/div[2]/h3";
        /// <summary>XPath for the GP Details field in the miniapp header.</summary>
        public static string GPDetails_Field = "//*[@id='bannerDropDown']/div/div[1]/div[3]/h2";
        /// <summary>XPath for the Next of Kin field in the miniapp header.</summary>
        public static string NextOfKin_Field = "//*[@id='bannerDropDown']/div/div[1]/div[4]/h2";
        /// <summary>XPath for hiding additional details in the miniapp header.</summary>
        public static string Hide_Additional_Details = "//*[@id='hideExpandedPatientBanner']";

        // BloodBank Page Locators
        /// <summary>XPath for the BloodBank page title.</summary>
        public static string BBPageTitle = "/html/body/div/div[1]/main/h1";
        /// <summary>XPath for the 'Collapse All' button on the BloodBank page.</summary>
        public static string CollapseAll = "//*[@id='btnCollapseAll']";
        /// <summary>XPath for the name search result on the BloodBank page.</summary>
        public static string NameSearchResult = "/html/body/main/table/tbody/tr/td[2]";

        // Wardlist Page Locators
        /// <summary>XPath for the admitted date label on the Wardlist page.</summary>
        public static string Admitted_Date_Label = "//*[@id='AdmissionDetailsContent 999315']/div[1]/table/tbody/tr[2]/td/label";

        // Electronic Test Request page locators
        public static string RequestTestBtt = "//button[@id='btnRequestTest']";
        public static string ExitWCPBtt = "//button[@id='btnExitWcp']";
        public static string ETRHiddenDiv = "//div[@id='hdnDiv']";
    }
}
