
// https://docs.microsoft.com/en-us/previous-versions/sql/synchronization/sync-framework-2.1/ff928525(v%3dsql.110)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using Microsoft.Synchronization;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;
using Microsoft.Synchronization.Data.SqlServerCe;
using SyncSql;
using SyncSql.Logging;
using System.Configuration;


namespace SyncSQLServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string ProviderConnectionString;
            string ClientConnectionString;

            string tempProviderConn = ConfigurationManager.ConnectionStrings["defaultProviderConnectionString"].ConnectionString;
            string tempClientConn = ConfigurationManager.ConnectionStrings["defaultClientConnectionString"].ConnectionString;

            if (Sync.ConnectionStringIsValid(tempProviderConn))
            {
                ProviderConnectionString = tempProviderConn;

                if (Sync.ConnectionStringIsValid(tempClientConn))
                {
                    ClientConnectionString = tempClientConn;

                    Logs.SyncLog.WriteLine("Sync service begun at " + DateTime.Now);
                    Console.WriteLine(Sync.Synchronise("ProductsScope", ProviderConnectionString, ClientConnectionString) + Sync.Synchronise("OrdersScope", ProviderConnectionString, ClientConnectionString));
                    Logs.SyncLog.WriteLine("Sync completed at " + DateTime.Now);
                }
                else
                {
                    Logs.SyncLog.WriteLine("There was an error whilst connecting to the client database. Please check your connection and check that the client connection string, which is specified " +
                    "in the app configuration file, is valid.");
                }
            }
            else
            {
                Logs.SyncLog.WriteLine("There was an error whilst connecting to the provider database. Please check your connection and check that the provider connection string, which is specified " +
                    "in the app configuration file, is valid.");
            }

        }

        
    }
}
