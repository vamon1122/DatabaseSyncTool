
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

            if (Sync.TestSqlConnectionString(tempProviderConn))
            {
                ProviderConnectionString = tempProviderConn;

                if (Sync.TestSqlConnectionString(tempClientConn))
                {
                    ClientConnectionString = tempClientConn;

                    Console.WriteLine("Syncing...");
                    Console.WriteLine(Sync.Synchronise("ProductsScope", ProviderConnectionString, ClientConnectionString) + Sync.Synchronise("OrdersScope", ProviderConnectionString, ClientConnectionString));
                    Console.WriteLine("Sync complete.");
                }
                else
                {
                    WriteLineError("There was an error whilst connecting to the client database. Please check your connection and check that the client connection string, which is specified " +
                    "in the app configuration file, is valid.");
                }
            }
            else
            {
                WriteLineError("There was an error whilst connecting to the provider database. Please check your connection and check that the provider connection string, which is specified " +
                    "in the app configuration file, is valid.");
            }


            void WriteLineError(string pString)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(pString);
                Console.ResetColor();
                Console.Write("(press enter to dismiss)");
                Console.ReadLine();
            }

        }

        
    }
}
