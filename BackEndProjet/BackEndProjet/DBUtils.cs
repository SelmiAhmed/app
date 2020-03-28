using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace BackEndProjet
{
    public class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"desktop-olse3hj\sqlexpress";

            string database = "projet";
            string username = "";
            string password = "";

            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }

    }
}