using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Configuration;
using Evnt_Nxt_DAL_;

namespace Evnt_Nxt_Business_
{ 
    public class Service
    {
        private readonly DatabaseContext DatabaseContext;

        // Constructor accepts DatabaseContext via Dependency Injection
        public Service(DatabaseContext databaseContext)
        {
            this.DatabaseContext = databaseContext;
        }

        public bool CheckDatabaseConnection()
        {
            return DatabaseContext.TestConnection();
        }
        public void PerformDatabaseOperation()
        {
            SqlConnection connection = null;
            try
            {
                using (connection = DatabaseContext.GetConnection())
                {
                    Console.WriteLine("Attempting to open database connection...");
                    connection.Open(); // This is where the error could occur
                    Console.WriteLine("Database connection established.");

                    // Your database logic here

                }
            }
            catch (SqlException sqlEx)
            {
                // Log database-specific errors
                Console.WriteLine($"SQL Error: {sqlEx.Message}");
            }
            catch (InvalidOperationException invalidOpEx)
            {
                // This might happen if the connection is in an invalid state
                Console.WriteLine($"Invalid Operation Error: {invalidOpEx.Message}");
            }
            catch (Exception ex)
            {
                // Catch any other general errors
                Console.WriteLine($"General Error: {ex.Message}");
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
    }
}