using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;
using System.Diagnostics;
using SyncSql.Logging;

namespace SyncSql
{
    public static class Provisioning
    {
        public static void ProvisionTableOnProvider(string pScopeName, string pTableName, string pProviderConnectionString)
        {
            try
            {
                // connect to server database
                SqlConnection serverConn = new SqlConnection(pProviderConnectionString);
                // connection string for Eskimos test
                // SqlConnection serverConn = new SqlConnection("Data Source=q6.2eskimos.com; Initial Catalog=EskLeeTest; uid=test ; pwd=test1test");

                // define a new scope named ProductsScope
                DbSyncScopeDescription scopeDesc = new DbSyncScopeDescription(pScopeName);

                // get the description of the Products table from SyncDB dtabase
                DbSyncTableDescription tableDesc = SqlSyncDescriptionBuilder.GetDescriptionForTable(pTableName, serverConn);

                // add the table description to the sync scope definition
                scopeDesc.Tables.Add(tableDesc);

                // create a server scope provisioning object based on the ProductScope
                SqlSyncScopeProvisioning serverProvision = new SqlSyncScopeProvisioning(serverConn, scopeDesc);

                // skipping the creation of table since table already exists on server
                serverProvision.SetCreateTableDefault(DbSyncCreationOption.Skip);

                serverProvision.Apply();
            }
            catch (Exception e)
            {
                string tempErrorMessage = "There was an exception whilst creating a provider provision: " + e;
                Debug.WriteLine(tempErrorMessage);
                Logs.ProvisioningLog.WriteLine(tempErrorMessage);
                throw e;
            }
        }

        public static void ProvisionTableOnClient(string pScopeName, string pProviderConnectionString, string pClientConnectionString)
        {
            try
            {

                // create a connection to the SyncExpressDB database
                SqlConnection clientConn = new SqlConnection(pClientConnectionString);

                // create a connection to the SyncDB server database
                SqlConnection serverConn = new SqlConnection(pProviderConnectionString);
                // connection string for Eskimos test
                //SqlConnection serverConn = new SqlConnection("Data Source=q6.2eskimos.com; Initial Catalog=EskLeeTest; uid=test ; pwd=test1test");

                // get the description of ProductsScope from the SyncDB server database
                DbSyncScopeDescription scopeDesc = SqlSyncDescriptionBuilder.GetDescriptionForScope(pScopeName, serverConn);

                // create server provisioning object based on the ProductsScope
                SqlSyncScopeProvisioning clientProvision = new SqlSyncScopeProvisioning(clientConn, scopeDesc);

                // starts the provisioning process
                clientProvision.Apply();
            }
            catch (Exception e)
            {
                string tempErrorMessage = "There was an exception whilst creating a client provision: " + e;
                Debug.WriteLine(tempErrorMessage);
                Logs.ProvisioningLog.WriteLine(tempErrorMessage);
                throw e;
            }
        }

        public static void DeprovisionDatabase(string pProviderConnectionString)
        {

            SqlConnection conn = new SqlConnection(pProviderConnectionString);
            SqlSyncScopeDeprovisioning deprovisionProvider = new SqlSyncScopeDeprovisioning(conn);
            deprovisionProvider.DeprovisionStore();
        }

        public static List<string> GetAllTables(string pConnectionString)
        {
            var allTables = new List<string>();
            using (SqlConnection conn = new SqlConnection(pConnectionString))
            {
                conn.Open();
                SqlCommand getTables = new SqlCommand("SELECT * FROM Sys.Tables", conn);

                using (SqlDataReader reader = getTables.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        allTables.Add(reader[0].ToString());
                    }
                }
            }

            return allTables;
        }

        public static List<string> GetBaseTables(string pConnectionString)
        {
            var normalTables = new List<string>();
            foreach (var table in GetAllTables(pConnectionString))
                if (table != "schema_info" && table != "scope_info" && table != "scope_config" && !table.Contains("_tracking"))
                {
                    normalTables.Add(table);
                }

            return normalTables;
        }

        public static List<string> GetUnprovisionedTables(string pConnectionString)
        {
            List<string> allTables = GetAllTables(pConnectionString);
            var provisionedTables = new List<string>();

            foreach (string tempTable in allTables)
            {
                if (tempTable != "schema_info" && tempTable != "scope_info" && tempTable != "scope_config" && !tempTable.Contains("_tracking"))
                {
                    if (!allTables.Contains(tempTable + "_tracking"))
                        provisionedTables.Add(tempTable);
                }
            }
            return provisionedTables;
        }

        public static List<string> GetProvisionedTables(string pConnectionString)
        {
            List<string> allTables = GetAllTables(pConnectionString);
            var provisionedTables = new List<string>();

            foreach (string tempTable in allTables)
            {
                if (tempTable != "schema_info" && tempTable != "scope_info" && tempTable != "scope_config" && !tempTable.Contains("_tracking"))
                {
                    if (allTables.Contains(tempTable + "_tracking"))
                        provisionedTables.Add(tempTable);
                }
            }
            return provisionedTables;
        }

        public static List<string> GetUnsyncedTables(string pProviderConnectionString, string pClientConnectionString)
        {
            List<string> allProviderTables = GetAllTables(pProviderConnectionString);
            List<string> allClientTables = GetAllTables(pClientConnectionString);

            var unsyncedTables = new List<string>();

            foreach (string table in allProviderTables)
            {
                if (table != "schema_info" && table != "scope_info" && table != "scope_config" && !table.Contains("_tracking"))
                {
                    if (!allClientTables.Contains(table + "_tracking"))
                        unsyncedTables.Add(table);
                }
            }
            return unsyncedTables;
        }

        public static List<string> GetSyncedTables(string pProviderConnectionString, string pClientConnectionString)
        {
            List<string> allProviderTables = GetAllTables(pProviderConnectionString);
            List<string> allClientTables = GetAllTables(pClientConnectionString);

            var syncedTables = new List<string>();

            foreach (string table in allProviderTables)
            {
                if (table != "schema_info" && table != "scope_info" && table != "scope_config" && !table.Contains("_tracking"))
                {
                    if (allClientTables.Contains(table + "_tracking"))
                        syncedTables.Add(table);
                }
            }
            return syncedTables;
        }
    }
}
