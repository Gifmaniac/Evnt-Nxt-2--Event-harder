using System.Data;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.SqlServer;

namespace Evnt_Nxt_DAL_
{
    public class DatabaseContext
    {
        public readonly string ConnectionString;


        // This logic selects the connection string based on the "DatabaseMode" config value.
        // It allows switching between my production database and demo database, without me hardcoding a different key
        public DatabaseContext(IConfiguration configuration)
        {
            var key = configuration["DatabaseMode"] ?? "DefaultConnection";
            ConnectionString = configuration.GetConnectionString(key)!;
        }


        public SqlConnection CreateOpenConnection()
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }
    }
}

        

    

