using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using Microsoft.Synchronization;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;
using Microsoft.Synchronization.Data.SqlServerCe;
using SyncSql;
using System.Diagnostics;
using System.Configuration;

namespace SyncWindowsInterface
{
    public partial class winMain : Form
    {
        private static readonly Log SyncLog = new Log("SyncLog");

        public string ProviderConnectionString { get; set; }
        public string ClientConnectionString { get; set; }

        public winMain()
        {
            InitializeComponent();
            int noOfLines = SyncLog.Read().Count();
            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].Name = "History Of Logs";
            dataGridView1.Columns[0].Width = 450; //Cannot be dynamic aparrently

            InputProviderConnectionString.Text = ConfigurationManager.ConnectionStrings["defaultProviderConnectionString"].ConnectionString;
            InputClientConnectionString.Text = ConfigurationManager.ConnectionStrings["defaultClientConnectionString"].ConnectionString;

            for (int i = 0; i < noOfLines; i++)
            {
                dataGridView1.Rows.Add(SyncLog.Read()[i]);
            }
        }

        

        private void DisplayFailedConnectionError()
        {
            string message = "Could not establish a connection to the database. Please check that the supplied connection string is valid.";
            string caption = "Connection Error";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons);

        }

        private bool ProviderConnectionExists()
        {
            if (string.IsNullOrEmpty(ProviderConnectionString) || string.IsNullOrWhiteSpace(ProviderConnectionString))
            {
                string message = "A valid connection has not yet been submitted for the provider database.";
                string caption = "Connection Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                return false;
            }

            return true;
        }

        private bool ClientConnectionExists()
        {
            if (string.IsNullOrEmpty(ClientConnectionString) || string.IsNullOrWhiteSpace(ClientConnectionString))
            {
                string message = "A valid connection has not yet been submitted for the client database.";
                string caption = "Connection Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                return false;
            }

            return true;
        }

        private void UpdateLists()
        {
            UpdateUnsyncedList();
            UpdateSyncedList();
        }

        private void UpdateUnsyncedList()
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

        private void UpdateSyncedList()
        {
            CheckedListBox_ProvisionedClientTables.Items.Clear();

            if (!string.IsNullOrEmpty(ClientConnectionString) && !string.IsNullOrWhiteSpace(ClientConnectionString) && !string.IsNullOrEmpty(ProviderConnectionString) && !string.IsNullOrWhiteSpace(ProviderConnectionString)) //Using 'ProviderConnectionExists()' & 'ClientConnectionExists()' would cause a message to be shown
            {
                foreach (string tableName in Provisioning.GetSyncedTables(ProviderConnectionString, ClientConnectionString))
                {
                    CheckedListBox_ProvisionedClientTables.Items.Add(tableName);
                }
            }
        }

        private bool TestConnection(TextBox pInput)
        {
            if (TestConnection(pInput.Text))
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

        private bool TestConnection(string pConnectionString)
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

        private void ProvisionTablesOnClient()
        {
            if (ClientConnectionExists() && ProviderConnectionExists())
            {
                foreach (var itemChecked in CheckedListBox_UnprovisionedProviderTables.CheckedItems)
                {
                    if (Provisioning.GetProvisionedTables(ProviderConnectionString).Contains(itemChecked.ToString()))
                    {
                        try
                        {
                            Provisioning.CreateClientProvision(itemChecked.ToString() + "Scope", ClientConnectionString, ProviderConnectionString);
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

        private void ProvisionTablesOnProvider()
        {
            if (ProviderConnectionExists())
            {
                foreach (var itemChecked in CheckedListBox_UnprovisionedProviderTables.CheckedItems)
                {
                    if (Provisioning.GetUnprovisionedTables(ProviderConnectionString).Contains(itemChecked.ToString()))
                    {
                        try
                        {
                            Provisioning.CreateProviderProvision(itemChecked.ToString() + "Scope", itemChecked.ToString(), ProviderConnectionString);
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

        private void btnSyncNow_Click(object sender, EventArgs e)
        {
            if (ClientConnectionExists() && ProviderConnectionExists()) {
                foreach (string tableName in Provisioning.GetProvisionedTables(ClientConnectionString))
                {
                    if (Provisioning.GetProvisionedTables(ProviderConnectionString).Contains(tableName.ToString()))
                    {
                        try
                        {
                            txtStatus.Text += Sync.Synchronise(tableName + "Scope");
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

        private void Button_LoadProvider_Click(object sender, EventArgs e)
        {
            if (TestConnection(InputProviderConnectionString))
            {
                ProviderConnectionString = InputProviderConnectionString.Text;
            }
            else
            {
                ProviderConnectionString = null;
                DisplayFailedConnectionError();
            }

            UpdateLists();
        }

        private void Button_LoadClient_Click(object sender, EventArgs e)
        {
            if (TestConnection(InputClientConnectionString))
            {
                ClientConnectionString = InputClientConnectionString.Text;
            }
            else
            {
                ClientConnectionString = null;
                DisplayFailedConnectionError();
            }

            //If ProviderConnectionExists
            UpdateLists();
        }

        private void Button_ProvisionTables_Click(object sender, EventArgs e)
        {
            if (ClientConnectionExists() && ProviderConnectionExists())
            {
                ProvisionTablesOnProvider();
                ProvisionTablesOnClient();
            }

            UpdateLists();
        }

        private void Button_DeprovisionProvider_Click(object sender, EventArgs e)
        {
            if (ProviderConnectionExists())
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

            UpdateLists();
        }

        private void Button_DeprovisionClient_Click(object sender, EventArgs e)
        {
            if (ClientConnectionExists())
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

            UpdateLists();
        }
    }
}
