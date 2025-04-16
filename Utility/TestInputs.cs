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
    }
}
