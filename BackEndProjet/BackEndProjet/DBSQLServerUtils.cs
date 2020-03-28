using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace BackEndProjet
{
    public class DBSQLServerUtils
    {
        public static SqlConnection
                GetDBConnection(string datasource, string database, string username, string password)
        {
            //
            //Data Source=desktop-olse3hj\sqlexpress;Initial Catalog=projet;Integrated Security=True;Pooling = False;
            //
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }
    }
}