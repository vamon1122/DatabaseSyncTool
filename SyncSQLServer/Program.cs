
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
using Data;
using SyncSql;

namespace SyncSQLServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Syncing...");
            Console.WriteLine(Sync.Synchronise("ProductsScope") + Sync.Synchronise("OrdersScope"));
            Console.WriteLine("Sync complete.");
        }
    }
}
