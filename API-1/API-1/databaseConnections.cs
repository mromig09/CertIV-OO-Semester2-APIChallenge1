using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace API_1
{
    public class databaseConnections
    {
        public static SqlConnection GetConnection()
        {
            //@"Server=myServerAddress;Database=myDatabase;User Id=MyUsername;Password=myPassword;"
            string ConnString = @"Server=tcp:civapi.database.windows.net,1433;Initial Catalog=civapi;User ID=civ_user;Password=Monday1330";
            return new SqlConnection(ConnString);
        }
    }
}