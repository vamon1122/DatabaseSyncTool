using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Data;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;
using System.Diagnostics;
using SyncLog;

namespace SyncSql
{
    public class Provisioning
    {
        static Log ProvisioningLog = new Log("ProvisioningLog");

        public static void CreateProviderProvision(string syncScopeDescription, string syncTableDescription, string pProviderConn)
        {
            try
            {
                // connect to server database
                SqlConnection serverConn = new SqlConnection(pProviderConn);
                // connection string for Eskimos test
                // SqlConnection serverConn = new SqlConnection("Data Source=q6.2eskimos.com; Initial Catalog=EskLeeTest; uid=test ; pwd=test1test");

                // define a new scope named ProductsScope
                DbSyncScopeDescription scopeDesc = new DbSyncScopeDescription(syncScopeDescription);

                // get the description of the Products table from SyncDB dtabase
                DbSyncTableDescription tableDesc = SqlSyncDescriptionBuilder.GetDescriptionForTable(syncTableDescription, serverConn);

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
                ProvisioningLog.WriteLine(tempErrorMessage);
                throw e;
            }
        }

        public static void CreateClientProvision(string pSyncScopeDescription, string pClientConn, string pProviderConn)
        {
            try
            {

                // create a connection to the SyncExpressDB database
                SqlConnection clientConn = new SqlConnection(pClientConn);

                // create a connection to the SyncDB server database
                SqlConnection serverConn = new SqlConnection(pProviderConn);
                // connection string for Eskimos test
                //SqlConnection serverConn = new SqlConnection("Data Source=q6.2eskimos.com; Initial Catalog=EskLeeTest; uid=test ; pwd=test1test");

                // get the description of ProductsScope from the SyncDB server database
                DbSyncScopeDescription scopeDesc = SqlSyncDescriptionBuilder.GetDescriptionForScope(pSyncScopeDescription, serverConn);

                // create server provisioning object based on the ProductsScope
                SqlSyncScopeProvisioning clientProvision = new SqlSyncScopeProvisioning(clientConn, scopeDesc);

                // starts the provisioning process
                clientProvision.Apply();
            }
            catch (Exception e)
            {
                string tempErrorMessage = "There was an exception whilst creating a client provision: " + e;
                Debug.WriteLine(tempErrorMessage);
                ProvisioningLog.WriteLine(tempErrorMessage);
                throw e;
            }
        }
    }
}
