﻿using System.Data;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.SqlServer;

namespace Evnt_Nxt_DAL_
{
    public static class DatabaseContext
    {
    public static readonly string ConnectionString = "Server = mssqlstud.fhict.local;Database = dbi567108_nxtevnt;User Id = dbi567108_nxtevnt;Password = Test123; TrustServerCertificate = True; ";
        
    
    public static SqlConnection CreateOpenConnection()
    {
        var connection = new SqlConnection(ConnectionString);
        connection.Open();
        return connection;
    }

    }
}

        

    

