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
using Data;
using SyncSql;
using SyncLog;
using System.Diagnostics;

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



            for (int i = 0; i < noOfLines; i++)
            {
                dataGridView1.Rows.Add(SyncLog.Read()[i]);
            }
        }




        private void btnSyncNow_Click(object sender, EventArgs e)
        {
            txtStatus.Text = Sync.Synchronise("ProductsScope") + Sync.Synchronise("OrdersScope");
        }

        private void ButtonLoadProvider_Click(object sender, EventArgs e)
        {


            if (TestConnection(InputProviderConnectionString))
            {
                ProviderConnectionString = InputProviderConnectionString.Text;
                foreach (string tableName in GetProvisionedTables(ProviderConnectionString))
                {
                    CheckedListBox_ProvisionedProviderTables.Items.Add(tableName);
                }

                foreach (string tableName in GetUnprovisionedTables(ProviderConnectionString))
                {
                    CheckedListBox_UnprovisionedProviderTables.Items.Add(tableName);
                }
            }

        }

        private void ButtonLoadClient_Click(object sender, EventArgs e)
        {
            if (TestConnection(InputClientConnectionString))
                ClientConnectionString = InputClientConnectionString.Text;



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

        private List<string> GetProvisionedTables(string pConnectionString)
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

        private List<string> GetUnprovisionedTables(string pConnectionString)
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

        private List<string> GetAllTables(string pConnectionString)
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

        private bool TestConnection(string pConnectionString)
        {
            try
            {
                SqlConnection testConn = new SqlConnection(pConnectionString);
                testConn.Open();
                testConn.Close();
                return true;
            }
            catch (Exception e)
            {

                string message = "Could not establish a connection to the database. Please check that the supplied connection string is valid.";
                string caption = "Connection Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);

                return false;
            }
        }

        private void Button_ProvisionClient_Click(object sender, EventArgs e)
        {
            if (TestConnection(InputProviderConnectionString) && TestConnection(InputClientConnectionString))
            {
                foreach (var itemChecked in CheckedListBox_ProvisionedProviderTables.CheckedItems)
                {
                    if (GetProvisionedTables(ProviderConnectionString).Contains(itemChecked.ToString()))
                    {
                        try
                        {
                            Debug.WriteLine("ClientConn = " + ClientConnectionString);
                            Debug.WriteLine("ServerConn = " + ProviderConnectionString);
                            Provisioning.CreateClientProvision(itemChecked.ToString() + "Scope", ClientConnectionString, ProviderConnectionString);
                        }
                        catch
                        {
                            MessageBox.Show(string.Format("There was an error whilst provisioning the \"{0}\" table on the client database. Please check the log.", itemChecked.ToString()), "Provisioning Error", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show(string.Format("The \"{0}\" table did not exist on the provider database anymore.", itemChecked.ToString()), "Provisioning Error", MessageBoxButtons.OK);
                    }
                }
                MessageBox.Show("All tables were successfully provisioned on the client database.", "Success", MessageBoxButtons.OK);

            }
        }

        private void Button_ProvisionProvider_Click(object sender, EventArgs e)
        {
            if (TestConnection(InputProviderConnectionString))
            {
                foreach (var itemChecked in CheckedListBox_UnprovisionedProviderTables.CheckedItems)
                {
                    if (GetUnprovisionedTables(ProviderConnectionString).Contains(itemChecked.ToString()))
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
                        MessageBox.Show(string.Format("The \"{0}\" table did not exist on the provider database anymore.", itemChecked.ToString()), "Provisioning Error", MessageBoxButtons.OK);
                    }

                    MessageBox.Show("All tables were successfully provisioned on the provider database.", "Success", MessageBoxButtons.OK);

                }
            }




            /*
            private void OLD_btnSyncNow_Click(object sender, EventArgs e)
            {

                Synchronise("ProductsScope");

                Synchronise("OrdersScope");

                Synchronise("z_Scope_2Bapv1CatagoryMap");
                Synchronise("z_Scope_2Bapv1CategoryToLevelMap");
                Synchronise("z_Scope_AssessmentScheme");
                Synchronise("z_Scope_AssessmentSchemeJudgement");
                Synchronise("z_Scope_CurriculumFramework");
                Synchronise("z_Scope_FrameworkCategory");
                Synchronise("z_Scope_Note");
                Synchronise("z_Scope_Objective");
                Synchronise("z_Scope_ObjectiveLevel");
                Synchronise("z_Scope_ObjectiveLevelScheme");
                Synchronise("z_Scope_ObjectiveLevelYearGroup");
                Synchronise("z_Scope_Observation");
                Synchronise("z_Scope_ObservationLearner");
                Synchronise("z_Scope_ObservationNote");
                Synchronise("z_Scope_ObservationObjective");
                Synchronise("z_Scope_SchoolYearPeriod");
                Synchronise("z_Scope_AdminModuleMenuItem");
                Synchronise("z_Scope_AdminModuleMenuItemRoleItem");

                Synchronise("z_Scope_AuditEvent");
                Synchronise("z_Scope_AuditEventType");
                Synchronise("z_Scope_AvatarFileInfo");
                Synchronise("z_Scope_BookBand");
                Synchronise("z_Scope_BookBandYearGroup");
                Synchronise("z_Scope_BookPack");
                Synchronise("z_Scope_BookPackMiscueBook");
                Synchronise("z_Scope_BookPackSchool");
                Synchronise("z_Scope_Client");
                Synchronise("z_Scope_DbVersion");
                Synchronise("z_Scope_Group");
                Synchronise("z_Scope_GroupUser");

                Synchronise("z_Scope_HiLo");
                Synchronise("z_Scope_Learner");
                Synchronise("z_Scope_LearnerGroup");
                Synchronise("z_Scope_LearnerProfile");
                Synchronise("z_Scope_LearnerTag");
                Synchronise("z_Scope_MiscueBook");
                Synchronise("z_Scope_MiscueSession");
                Synchronise("z_Scope_MiscueSessionComment");
                Synchronise("z_Scope_MiscueSessionLevel");
                Synchronise("z_Scope_MiscueSessionRecordFileInfo");
                Synchronise("z_Scope_MiscueType");
                Synchronise("z_Scope_MiscueTypeGroup");


            }
            */
        }

    }
}
