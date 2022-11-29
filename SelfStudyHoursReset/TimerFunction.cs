using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace SelfStudyHoursReset
{
    public class TimerFunction
    {
        [FunctionName("ResetSelfStudyHours")]
        public void Run([TimerTrigger("0 0 0 * * 0")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            const string CONNECTION_STRING = "Server=tcp:simple-ser.database.windows.net,1433;Initial Catalog=plannabelle-db;Persist Security Info=False;User ID=adm10117299;Password=Landseen76;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            const string PROCEDURE_NAME = "ResetSelfStudyHours";

            using (SqlConnection sqlConnection = new SqlConnection(CONNECTION_STRING))
            using (SqlCommand sqlCommand = new SqlCommand(PROCEDURE_NAME, sqlConnection))
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
