using System.Data.SqlClient;
using DatabaseCalculator;

namespace ConsoleCalculator
{
    public class DBSave : IDBSave
    {
        public void SaveEFModel(string message)
        {
            using (CalculatorProjectEntities databaseCalc = new CalculatorProjectEntities())
            {
                CalculatorLog log = new CalculatorLog
                {
                    message = message
                };
                databaseCalc.CalculatorLogs.Add(log);
                databaseCalc.SaveChanges();
            }
        }

        public void SaveSP(string message)
        {
            string connectionString = @"Server=FARHAN\SQLEXPRESS;Database=CalculatorProject;User ID=sa;Password=Dmc208209";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand insertValues = new SqlCommand("Insert into CalculatorLog(message) values(@message)", connection);
                insertValues.Parameters.AddWithValue("@message", message);
                connection.Open();
                insertValues.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
