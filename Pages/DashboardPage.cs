using CWS2POC.Features;
using CWS2POC.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V127.Runtime;
using OpenQA.Selenium.Interactions;

namespace CWS2POC.Pages
{
    /// <summary>
    /// Dashboard page class.
    /// </summary>
    public class DashboardPage
    {
        //reference variable
        private IWebDriver Driver;

        /// <summary>
        /// Initialises instance of Dashboard page class.
        /// </summary>
        /// <param name="Driver"></param>
        public DashboardPage(IWebDriver Driver)
        {
            this.Driver = Driver;
        }

        /// <summary>
        /// Clicks patient search button.
        /// </summary>
        public void ClickPatientSearchButton()
        {
            BrowserActions.Click(Driver, Locators.PatientSearch);
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Clicks on name title.
        /// </summary>
        public void ClickName()
        {
            BrowserActions.Click(Driver, Locators.NameTitle);
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Clicks on DOB.
        /// </summary>
        public void ClickDOB()
        {
            BrowserActions.Click(Driver, Locators.DOBTitle);
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Clicks first test result.
        /// </summary>
        public void ClickFirstTestResult()
        {
            BrowserActions.Click(Driver, Locators.NameSearchResult);
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Enters input.
        /// </summary>
        /// <param name="input">Text to input.</param>
        public void EnterInput(string input)
        {
            BrowserActions.SendKeys(Driver, Locators.SearchBox_SBX, input);
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Enters names.
        /// </summary>
        /// <param name="input1">Name.</param>
        /// <param name="input2">Name.</param>
        public void EnterNames(string input1, string input2)
        {
            BrowserActions.SendKeys(Driver, Locators.Forename_TBX, input1);
            Thread.Sleep(2000);
            BrowserActions.SendKeys(Driver, Locators.Surname_TBX, input2);
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Enters DOB.
        /// </summary>
        /// <param name="DOB">DOB string format.</param>
        public void EnterDOB(string DOB)
        {
            BrowserActions.Click(Driver, Locators.DOBTitle);
            BrowserActions.TypeDateOneByOne(Driver, Locators.DOBTitle, DOB);
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Validates BB key.
        /// </summary>
        /// <param name="Key">Key to validate.</param>
        public void ValidateBBKey(string Key)
        {
            // Check if the string is in the page source
            bool isKeyPresent = BrowserActions.IsStringPresentInPageSource(Driver, Key);
            // Output the result
            Console.WriteLine(isKeyPresent ? "String is present in the page source." : "String Not Present");
        }

        /// <summary>
        /// Validates header.
        /// </summary>
        public void ValidateHeader()
        {
            //Check if name present in header
            bool isNamePresent = BrowserActions.IsNamePresent(Driver,Locators.Name);
            Console.WriteLine(isNamePresent ? "Name is present in the page." : "Name Not Present");
            //check the fields sex,DOB,CRN,NHS are present
            bool isSexPresent = BrowserActions.IsTextPresentAndAssert(Driver,Locators.Sex_Field,TestInputs.SEX);
            Console.WriteLine(isSexPresent ? "SEX is present in the page." : "SEX Not Present");
            bool isDOBPresent = BrowserActions.IsTextPresentAndAssert(Driver,Locators.DOB_Field,TestInputs.DOB);
            Console.WriteLine(isDOBPresent ? "DOB is present in the page." : "DOB Not Present");
            bool isCRNPresent = BrowserActions.IsTextPresentAndAssert(Driver,Locators.CRN_Field,TestInputs.CRN);
            Console.WriteLine(isCRNPresent ? "CRN is present in the page." : "CRN Not Present");
            bool isNHSPresent = BrowserActions.IsTextPresentAndAssert(Driver,Locators.NHS_Field,TestInputs.NHS);
            Console.WriteLine(isNHSPresent ? "NHS is present in the page." : "NHS Not Present");


            //check see more is available
            bool isSeeMorePresent = BrowserActions.IsTextPresentAndAssert(Driver, Locators.See_More_DD, TestInputs.SeeMore);
            Console.WriteLine(isSeeMorePresent ? "See More is present in the page." : "See More Not Present");

            //can maximize the see more
            BrowserActions.Click(Driver, Locators.See_More_DD);
            Thread.Sleep(8000);
            bool isHADPresent = BrowserActions.IsTextPresentAndAssert(Driver, Locators.Hide_Additional_Details, TestInputs.HideAdditionalDetails);
            Console.WriteLine(isHADPresent ? "HAD is present in the page." : "HAD Not Present");
            //Add wait 
            //can see fields alerts,demographics,address,gpdetails,next of kin
            bool isAlertsPresent = BrowserActions.IsTextPresentAndAssert(Driver, Locators.Alerts_Field, TestInputs.Alerts);
            Console.WriteLine(isAlertsPresent ? "Alerts is present in the page." : "Alerts Not Present");
            bool isDemoPresent = BrowserActions.IsTextPresentAndAssert(Driver, Locators.Demographics_Field, TestInputs.Demographics);
            Console.WriteLine(isDemoPresent ? "Demographics is present in the page." : "Demographics Not Present");
            bool isGPPresent = BrowserActions.IsTextPresentAndAssert(Driver, Locators.GPDetails_Field, TestInputs.GPDetails);
            Console.WriteLine(isGPPresent ? "GP is present in the page." : "GP Not Present");
            bool isNOKPresent = BrowserActions.IsTextPresentAndAssert(Driver, Locators.NextOfKin_Field, TestInputs.NOK);
            Console.WriteLine(isNOKPresent ? "NOK is present in the page." : "NHS Not Present");
            //minimize
            BrowserActions.Click(Driver, Locators.Hide_Additional_Details);
            Thread.Sleep(2000);

            //after minimize i should not see thoe fields
            bool isSeeMorePresentBack = BrowserActions.IsTextPresentAndAssert(Driver, Locators.See_More_DD, TestInputs.SeeMore);
            Console.WriteLine(isSeeMorePresentBack ? "See More is present in the page." : "See More Not Present");
        }

        /// <summary>
        /// Validates names.
        /// </summary>
        /// <param name="Forename">First name.</param>
        /// <param name="Surname">Last name.</param>
        public void ValidateNames(string Forename, string Surname)
        {
            // Check if the string is in the page source
            bool isForenameyPresent = BrowserActions.IsStringPresentInPageSource(Driver, Forename);
            // Output the result
            Console.WriteLine(isForenameyPresent ? "String is present in the page source." : "String Not Present");
            // Check if the string is in the page source
            bool isSurnamePresent = BrowserActions.IsStringPresentInPageSource(Driver, Surname);
            // Output the result
            Console.WriteLine(isSurnamePresent ? "String is present in the page source." : "String Not Present");
        }

        /// <summary>
        /// Validate BB text.
        /// </summary>
        /// <param name="MiniApp">Mini app.</param>
        public void ValidateBBText(string MiniApp)
        {
            bool isTextPresent = BrowserActions.IsTextPresentAndAssert(Driver, Locators.BBPageTitle, MiniApp);
            //Output the result
            Console.WriteLine(isTextPresent ? "Validation Passed" : "Text does not match the expected value.");
            Thread.Sleep(3000);
        }

        /// <summary>
        /// Selects gender rdo.
        /// </summary>
        /// <param name="Gender">Gender.</param>
        public void SelectGenderRdo(string Gender)
        {
            if (Gender.ToLower() == "male")
            {
                BrowserActions.Click(Driver, Locators.Male_RBTN);
                Console.WriteLine("Clicked Male button");
            }
            else if (Gender.ToLower() == "female")
            {
                BrowserActions.Click(Driver, Locators.Female_RBTN);
                Console.WriteLine("Clicked Female button");
            }
            else
            {
                Console.WriteLine("Gender not recognized");
            }
        }

        /// <summary>
        /// Selects gender DOB rdo.
        /// </summary>
        /// <param name="Gender">Gender.</param>
        public void SelectGenderDOBRdo(string Gender)
        {
            if (Gender.ToLower() == "male")
            {
                BrowserActions.Click(Driver, Locators.Male_DOB_RBTN);
                Console.WriteLine("Clicked Male button");
            }
            else if (Gender.ToLower() == "female")
            {
                BrowserActions.Click(Driver, Locators.Female_DOB_RBTN);
                Console.WriteLine("Clicked Female button");
            }
            else
            {
                Console.WriteLine("Gender not recognized");
            }
        }

        /// <summary>
        /// View first BB Report.
        /// </summary>
        public void ViewFirstBBReport()
        {
            BrowserActions.Click(Driver,Locators.CollapseAll);
            Actions actions = new Actions(Driver);
            actions.SendKeys(Keys.Tab).SendKeys(Keys.Enter).Perform();
            Thread.Sleep(4000);

        }

        /// <summary>
        /// Clicks patient search button.
        /// </summary>
        /// <param name="input"></param>
        public void ClickPatientSearchButton(string input)
        {
            Actions actions = new Actions(Driver);
            switch (input)
            {
                case "ATD":
                    actions.SendKeys(Keys.Tab).SendKeys(Keys.Enter).Perform();
                    break;

                case "Patient Demographics":
                    actions.SendKeys(Keys.Tab).SendKeys(Keys.Tab).SendKeys(Keys.Enter).Perform();
                    break;

                case "Documents":
                    actions.SendKeys(Keys.Tab).SendKeys(Keys.Tab).SendKeys(Keys.Tab).SendKeys(Keys.Enter).Perform();
                    break;

                case "Patient Registration":
                    actions.SendKeys(Keys.Tab).SendKeys(Keys.Tab).SendKeys(Keys.Tab).SendKeys(Keys.Tab).SendKeys(Keys.Enter).Perform();
                    break;

                case "Blood Bank":
                    actions.SendKeys(Keys.Tab).SendKeys(Keys.Tab).SendKeys(Keys.Tab).SendKeys(Keys.Tab).SendKeys(Keys.Tab).SendKeys(Keys.Enter).Perform();
                    break;

                case "Patient Search":
                    BrowserActions.Click(Driver, Locators.PatientSearch);
                    Thread.Sleep(2000);
                    break;

                case "WardList":
                    BrowserActions.Click(Driver, Locators.WardList);
                    Thread.Sleep(2000);
                    break;

                case "Settings":
                    BrowserActions.Click(Driver,Locators.Profile_DD);
                    actions.SendKeys(Keys.Tab).SendKeys(Keys.Enter).Perform();
                    Thread.Sleep(2000);
                    break;

                case "D2RA":
                    BrowserActions.Click(Driver, Locators.WardList);
                    Thread.Sleep(2000);
                    BrowserActions.Click(Driver, Locators.Admitted_Date_Label);
                    Thread.Sleep(2000);
                    Thread.Sleep(2000);
                    actions.SendKeys(Keys.Tab).SendKeys(Keys.Enter).Perform();
                    Thread.Sleep(2000);
                    break;

                default:
                    Console.WriteLine("Invalid key provided.");
                    break;
            }
        }

    }
}
