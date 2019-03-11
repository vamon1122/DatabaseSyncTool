using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Data
{
    public static class DataStore
    {
        // create a connection to the SyncDB server database
        public static string ServerConn { get { return @"Data Source=sanfrancisco\mssql2012dev; Initial Catalog=SyncDB; uid=sa ; pwd=L3tme1n"; } }

        // create a connection to the SyncExpressDB database
        public static string ClientConn { get { return @"Data Source=BRANSON\SQLEXPRESS; Initial Catalog=SyncDBLocal; uid=sa ; pwd=L3tme1n"; } }
    }
}
