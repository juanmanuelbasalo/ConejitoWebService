using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace ConejitoWebService.ConnectionManager
{
    public static class ConnectionHelper
    {
        public static System.Data.SqlClient.SqlConnection GetConnection(string connectionString)
        {
            return new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings[connectionString].ConnectionString);
        }
    }
}