using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SyncSql
{
    public static class Sql
    {
        public static bool TestSqlConnectionString(string pConnectionString)
        {
            try
            {
                SqlConnection testConn = new SqlConnection(pConnectionString);
                testConn.Open();
                testConn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
