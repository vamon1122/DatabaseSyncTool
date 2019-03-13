using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Synchronization.Data;
using SyncSql;
using SyncSql.Logging;
using System.Configuration;

namespace SyncWindowsInterface
{
    public partial class winMain : Form
    {
        #region Variables & Properties
        public string ProviderConnectionString { get; set; }
        public string ClientConnectionString { get; set; }
        #endregion

        public winMain()
        {
            InitializeComponent();
            int noOfLines = Logs.SyncLog.Read().Count();
            //dataGridView1.ColumnCount = 1;
            //dataGridView1.Columns[0].Name = "History Of Logs";
            //dataGridView1.Columns[0].Width = 450; //Cannot be dynamic aparrently

            string tempProviderConn = ConfigurationManager.ConnectionStrings["defaultProviderConnectionString"].ConnectionString;
            string tempClientConn = ConfigurationManager.ConnectionStrings["defaultClientConnectionString"].ConnectionString;

            if (Sync.ConnectionStringIsValid(tempProviderConn))
            {
                InputProviderConnectionString.Text = tempProviderConn;
                ProviderConnectionString = tempProviderConn;
                UpdateAllLists();
            }

            if (Sync.ConnectionStringIsValid(tempClientConn))
            {
                InputClientConnectionString.Text = tempClientConn;
                ClientConnectionString = tempClientConn;
                UpdateAllLists();
            }

            for (int i = 0; i < noOfLines; i++)
            {
                //dataGridView1.Rows.Add(SyncLog.Read()[i]);
            }
        }

        #region Methods
        private void DisplayFailedConnectionError()
        {
            string message = "Could not establish a connection to the database. Please check that the supplied connection string is valid.";
            string caption = "Connection Error";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons);

        }

        private void DisplayNoConnectionError(string pDatabaseType)
        {
            string message = string.Format("A valid connection has not yet been submitted for the {0} database. Please enter a connection string for the {0} in the 'Settings' tab.", pDatabaseType);
            string caption = "Connection Error";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons);
        }

        private bool ProviderConnectionStringExists()
        {
            if (string.IsNullOrEmpty(ProviderConnectionString) || string.IsNullOrWhiteSpace(ProviderConnectionString))
            {
                DisplayNoConnectionError("provider");
                return false;
            }

            return true;
        }

        private bool ClientConnectionStringExists()
        {
            if (string.IsNullOrEmpty(ClientConnectionString) || string.IsNullOrWhiteSpace(ClientConnectionString))
            {
                DisplayNoConnectionError("client");
                return false;
            }

            return true;
        }

        private void UpdateAllLists()
        {
            UpdateUnsyncedTablesList();
            UpdateSyncedTablesList();
        }

        private void UpdateUnsyncedTablesList()
        {
            CheckedListBox_UnprovisionedProviderTables.Items.Clear();

            if (!string.IsNullOrEmpty(ProviderConnectionString) && !string.IsNullOrWhiteSpace(ProviderConnectionString)) //Using 'ProviderConnectionExists()' would cause a message to be shown
            {
                if (!string.IsNullOrEmpty(ClientConnectionString) && !string.IsNullOrWhiteSpace(ClientConnectionString)) //Using 'ClientConnectionExists()' would cause a message to be shown
                {
                    foreach (string tableName in Provisioning.GetUnsyncedTables(ProviderConnectionString, ClientConnectionString))
                    {
                        CheckedListBox_UnprovisionedProviderTables.Items.Add(tableName);
                    }
                }
                else
                {
                    foreach (string tableName in Provisioning.GetBaseTables(ProviderConnectionString))
                    {
                        CheckedListBox_UnprovisionedProviderTables.Items.Add(tableName);
                    }
                }
            }
        }

        private void UpdateSyncedTablesList()
        {
            ListBox_ProvisionedClientTables.Items.Clear();

            if (!string.IsNullOrEmpty(ClientConnectionString) && !string.IsNullOrWhiteSpace(ClientConnectionString) && !string.IsNullOrEmpty(ProviderConnectionString) && !string.IsNullOrWhiteSpace(ProviderConnectionString)) //Using 'ProviderConnectionExists()' & 'ClientConnectionExists()' would cause a message to be shown
            {
                foreach (string tableName in Provisioning.GetSyncedTables(ProviderConnectionString, ClientConnectionString))
                {
                    ListBox_ProvisionedClientTables.Items.Add(tableName);
                }
            }
        }

        private bool ConnectionStringIsValid(TextBox pInput)
        {
            if (Sync.ConnectionStringIsValid(pInput.Text))
            {
                pInput.BackColor = System.Drawing.Color.LightGreen;
                return true;
            }
            else
            {
                pInput.BackColor = System.Drawing.Color.LightSalmon;
                return false;
            }
        }
        #endregion

        #region Button Handlers
        private void Button_SyncNow_Click(object sender, EventArgs e)
        {
            if (ClientConnectionStringExists() && ProviderConnectionStringExists()) {
                foreach (string tableName in Provisioning.GetProvisionedTables(ClientConnectionString))
                {
                    if (Provisioning.GetProvisionedTables(ProviderConnectionString).Contains(tableName.ToString()))
                    {
                        try
                        {
                            txtStatus.Text += Sync.Synchronise(tableName + "Scope", ProviderConnectionString, ClientConnectionString);
                        }
                        catch
                        {
                            MessageBox.Show(string.Format("There was an error whilst syncing the \"{0}\" table. Please check the log.", tableName.ToString()), "Sync Error", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show(string.Format("The \"{0}\" table did not exist on the provider database anymore.", tableName.ToString()), "Sync Error", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void Button_UpdateProviderConnectionString_Click(object sender, EventArgs e)
        {
            if (ConnectionStringIsValid(InputProviderConnectionString))
            {
                ProviderConnectionString = InputProviderConnectionString.Text;
                ConfigurationManager.ConnectionStrings["defaultProviderConnectionString"].ConnectionString = ProviderConnectionString;
            }
            else
            {
                ProviderConnectionString = null;
                DisplayFailedConnectionError();
            }

            UpdateAllLists();
        }

        private void Button_UpdateClientConnectionString_Click(object sender, EventArgs e)
        {
            if (ConnectionStringIsValid(InputClientConnectionString))
            {
                ClientConnectionString = InputClientConnectionString.Text;
                ConfigurationManager.ConnectionStrings["defaultClientConnectionString"].ConnectionString = ClientConnectionString;
            }
            else
            {
                ClientConnectionString = null;
                DisplayFailedConnectionError();
            }

            //If ProviderConnectionExists
            UpdateAllLists();
        }

        private void Button_ProvisionTables_Click(object sender, EventArgs e)
        {
            if (ClientConnectionStringExists() && ProviderConnectionStringExists())
            {
                ProvisionTablesOnProvider();
                ProvisionTablesOnClient();
            }

            UpdateAllLists();

            void ProvisionTablesOnClient()
            {
                if (ClientConnectionStringExists() && ProviderConnectionStringExists())
                {
                    foreach (var itemChecked in CheckedListBox_UnprovisionedProviderTables.CheckedItems)
                    {
                        if (Provisioning.GetProvisionedTables(ProviderConnectionString).Contains(itemChecked.ToString()))
                        {
                            try
                            {
                                Provisioning.ProvisionTableOnClient(itemChecked.ToString() + "Scope", ProviderConnectionString, ClientConnectionString);
                            }
                            catch
                            {
                                MessageBox.Show(string.Format("There was an error whilst provisioning the \"{0}\" table on the client database. Please check the log.", itemChecked.ToString()), "Provisioning Error", MessageBoxButtons.OK);
                            }
                        }
                        else
                        {
                            MessageBox.Show(string.Format("Could not provision the table on the client. The \"{0}\" table did not exist on the provider database anymore.", itemChecked.ToString()), "Provisioning Error", MessageBoxButtons.OK);
                        }
                    }
                    //MessageBox.Show("All tables were successfully provisioned on the client database.", "Success", MessageBoxButtons.OK);

                }
            }

            void ProvisionTablesOnProvider()
            {
                if (ProviderConnectionStringExists())
                {
                    foreach (var itemChecked in CheckedListBox_UnprovisionedProviderTables.CheckedItems)
                    {
                        if (Provisioning.GetUnprovisionedTables(ProviderConnectionString).Contains(itemChecked.ToString()))
                        {
                            try
                            {
                                Provisioning.ProvisionTableOnProvider(itemChecked.ToString() + "Scope", itemChecked.ToString(), ProviderConnectionString);
                            }
                            catch
                            {
                                MessageBox.Show(string.Format("There was an error whilst provisioning the \"{0}\" table on the provider database. Please check the log.", itemChecked.ToString()), "Provisioning Error", MessageBoxButtons.OK);
                            }
                        }
                        else
                        {
                            //MessageBox.Show(string.Format("The \"{0}\" table has already been provisioned on the provider!", itemChecked.ToString()), "Provisioning Error", MessageBoxButtons.OK);
                        }

                        //MessageBox.Show("All tables were successfully provisioned on the provider database.", "Success", MessageBoxButtons.OK);

                    }
                }
            }
        }

        private void Button_DeprovisionProvider_Click(object sender, EventArgs e)
        {
            if (ProviderConnectionStringExists())
            {
                try
                {
                    Provisioning.DeprovisionDatabase(InputProviderConnectionString.Text);
                }
                catch (DbNotProvisionedException)
                {
                    string message = "This database has already been unpublished!";
                    string caption = "Already Unpublished";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons);
                }
            }

            UpdateAllLists();
        }

        private void Button_DeprovisionClient_Click(object sender, EventArgs e)
        {
            if (ClientConnectionStringExists())
            {
                try
                {
                    Provisioning.DeprovisionDatabase(InputClientConnectionString.Text);
                }
                catch (DbNotProvisionedException)
                {
                    string message = "This database has already been unsubscribed!";
                    string caption = "Already Unsubscribed";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons);
                }
            }

            UpdateAllLists();
        }
        #endregion
    }
}
