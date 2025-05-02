using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWS2POC.Utility
{
    /// <summary>
    /// Test inputs class.
    /// </summary>
    public static class TestInputs
    {
        public const string DevUrl = "https://7a601devcwsiis1.cymru.nhs.uk:2048/ABUHB.CWS";
        public const string UATUrl = "https://7a600devswuat01.cymru.nhs.uk:2048/ABUHB.CWS";
        public const string Webapp4_URL = "https://7a600srvwebapp4.cymru.nhs.uk:2076/ABUHB.CWS/";
        public const string LoginText = "Log in to CWS";
        public const string Username = "arjun@wales.nhs.uk";
        public const string Password = "Aryan061711";
        public const string Username1 = "ABB.SoftwareTestAccount@wales.nhs.uk";
        public const string Password1 = "moleunicorn3";
        public const string Id1 = "ff48e2ad-24c7-4e55-a10b-f34a98f0bec1";
        public const string SEX = "SEX:";
        public const string DOB = "DOB:";
        public const string NHS = "NHS:";
        public const string CRN = "CRN:";
        public const string SeeMore = "See More";
        public const string HideAdditionalDetails = "Hide Additional Details";
        public const string Alerts = "Alerts";
        public const string Demographics = "Demographics";
        public const string GPDetails = "GP Details";
        public const string NOK = "Next Of Kin";
        public const string ConnectionString = "Database=ABUHB.AuthorizationServer.Membership;Server=7A601DEVCWSSQL4.cymru.nhs.uk,1435;User ID=sa;Password=Ora2SS2k12;TrustServerCertificate=True;";


        // Roles and Personas Ids:
        public static string ETR_url = "https://7a601devcwsiis1.cymru.nhs.uk/ABUHB.CWS.ETR/?crn=999305"; // While navigation to ETR is not ready.
        public const string AutomatedTestPersona_Id = "844DBDA2-853A-4BDF-871D-3C9420B5BF27";
        public const string CWSABasicUser_Id = "68497b59-7feb-4d83-a060-4d6c41f35acf";
        public const string PatientSearchBasicUser_Id = "0721b648-82b6-4968-8203-923dcd93fae6";
        public const string WardListBasicUser_Id = "57b8c658-3c85-4d04-baf9-bee41fd20466";
        public const string ETR_RequestTest_Id = "08e48709-6998-49ab-ade1-850935c8bd2c";

        // Test CRNs
        public const string crn1 = "999305";
    }
}
