using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SyncSql;
using System.Data.SqlClient;
using Microsoft.Synchronization;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;
using Microsoft.Synchronization.Data.SqlServerCe;
using System.Windows.Forms;
using System.Diagnostics;

namespace SyncSql
{
    public static class Sync
    {
        private static readonly Log SyncLog = new Log("SyncLog");

        public static string Synchronise(string syncScope)
        {
            try
            {
                // If all these sync requests are atomic, what happens if there are joined tables, triggers etc?
                // Can sync requests be combined?

                SqlConnection clientConn = new SqlConnection(DataStore.ClientConn);

                SqlConnection serverConn = new SqlConnection(DataStore.ProviderConn);

                //SqlConnection serverConn = new SqlConnection("Data Source=q6.2eskimos.com; Initial Catalog=EskLeeTest; uid=test ; pwd=test1test");

                // create the sync orhcestrator
                SyncOrchestrator syncOrchestrator = new SyncOrchestrator();

                // set local provider of orchestrator to a sync provider associated with the 
                // ProductsScope in the SyncExpressDB express client database
                syncOrchestrator.LocalProvider = new SqlSyncProvider(syncScope, clientConn);

                // set the remote provider of orchestrator to a server sync provider associated with
                // the ProductsScope in the SyncDB server database
                syncOrchestrator.RemoteProvider = new SqlSyncProvider(syncScope, serverConn);

                // set the direction of sync session to Upload and Download
                syncOrchestrator.Direction = SyncDirectionOrder.UploadAndDownload;

                
                string stats = "";

                // subscribe for errors that occur when applying changes to the client
                ((SqlSyncProvider)syncOrchestrator.LocalProvider).ApplyChangeFailed += new EventHandler<DbApplyChangeFailedEventArgs>(Program_ApplyChangeFailed);

                // execute the synchronization process
                SyncOperationStatistics syncStats = syncOrchestrator.Synchronize();

                // print statistics

                stats = "\r\n" + syncScope + ": " + syncStats.SyncStartTime + "\r\n";
                stats = stats + "Start Time: " + syncStats.SyncStartTime + "\r\n";
                stats = stats + "Total Changes Uploaded: " + syncStats.UploadChangesTotal + "\r\n";
                stats = stats + "Total Changes Downloaded: " + syncStats.DownloadChangesTotal + "\r\n";
                stats = stats + "Complete Time: " + syncStats.SyncEndTime + "\r\n";

                SyncLog.WriteLine(stats);

                return stats;

                void Program_ApplyChangeFailed(object sender, DbApplyChangeFailedEventArgs e)
                {
                    // display conflict type
                    stats += "\r\n" + e.Conflict.Type;

                    // display error message 
                    stats += "\r\n" + e.Error;
                }
            }
            catch (Exception e)
            {
                string message = "There was an error whilst syncing the data. Did you loose connection?";
                string caption = "Sync Error";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);

                if (result == DialogResult.Yes)
                {

                    // Closes the parent form.

                    //this.Close();

                }

                Debug.WriteLine("Exception whilst syncing = " + e);
                return "There was an exception whilst syncing: " + e;
            }
        }


    }
}
