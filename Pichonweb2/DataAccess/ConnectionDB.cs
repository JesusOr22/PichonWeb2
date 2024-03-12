using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Pichonweb2.DataAccess
{
    public class ConnectionDB
    {
        public static readonly string ConnectionString = WebConfigurationManager.OpenWebConfiguration("~/Web.config").ConnectionStrings.ConnectionStrings["AppConn"].ToString();

        public static IDbConnection GetConnection
        {
            get
            {
                var conn = new SqlConnection(ConnectionString);
                conn.Open();
                return conn;
            }
        }
    }
}