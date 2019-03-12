namespace SyncWindowsInterface
{
    partial class winMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSync = new System.Windows.Forms.TabPage();
            this.txtStatus = new System.Windows.Forms.RichTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSyncNow = new System.Windows.Forms.Button();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.CheckedListBox_ProvisionedClientTables = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CheckedListBox_UnprovisionedProviderTables = new System.Windows.Forms.CheckedListBox();
            this.Button_ProvisionTables = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.InputClientConnectionString = new System.Windows.Forms.TextBox();
            this.Button_LoadClient = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.InputProviderConnectionString = new System.Windows.Forms.TextBox();
            this.Button_LoadProvider = new System.Windows.Forms.Button();
            this.Button_DeprovisionProvider = new System.Windows.Forms.Button();
            this.Button_DeprovisionClient = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabSync.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabSync);
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(657, 451);
            this.tabControl1.TabIndex = 0;
            // 
            // tabSync
            // 
            this.tabSync.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabSync.Controls.Add(this.txtStatus);
            this.tabSync.Controls.Add(this.dataGridView1);
            this.tabSync.Controls.Add(this.btnSyncNow);
            this.tabSync.Location = new System.Drawing.Point(4, 22);
            this.tabSync.Name = "tabSync";
            this.tabSync.Padding = new System.Windows.Forms.Padding(3);
            this.tabSync.Size = new System.Drawing.Size(649, 425);
            this.tabSync.TabIndex = 0;
            this.tabSync.Text = "Sync";
            // 
            // txtStatus
            // 
            this.txtStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtStatus.Location = new System.Drawing.Point(6, 83);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(214, 336);
            this.txtStatus.TabIndex = 3;
            this.txtStatus.Text = "";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Red;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(226, 7);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(417, 412);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnSyncNow
            // 
            this.btnSyncNow.Location = new System.Drawing.Point(6, 6);
            this.btnSyncNow.Name = "btnSyncNow";
            this.btnSyncNow.Size = new System.Drawing.Size(214, 46);
            this.btnSyncNow.TabIndex = 0;
            this.btnSyncNow.Text = "Sync Now";
            this.btnSyncNow.UseVisualStyleBackColor = true;
            this.btnSyncNow.Click += new System.EventHandler(this.btnSyncNow_Click);
            // 
            // tabSettings
            // 
            this.tabSettings.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabSettings.Controls.Add(this.Button_DeprovisionClient);
            this.tabSettings.Controls.Add(this.Button_DeprovisionProvider);
            this.tabSettings.Controls.Add(this.label5);
            this.tabSettings.Controls.Add(this.CheckedListBox_ProvisionedClientTables);
            this.tabSettings.Controls.Add(this.label4);
            this.tabSettings.Controls.Add(this.CheckedListBox_UnprovisionedProviderTables);
            this.tabSettings.Controls.Add(this.Button_ProvisionTables);
            this.tabSettings.Controls.Add(this.label2);
            this.tabSettings.Controls.Add(this.InputClientConnectionString);
            this.tabSettings.Controls.Add(this.Button_LoadClient);
            this.tabSettings.Controls.Add(this.label1);
            this.tabSettings.Controls.Add(this.InputProviderConnectionString);
            this.tabSettings.Controls.Add(this.Button_LoadProvider);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(649, 425);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "Settings";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(228, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Tables which are currently being synchronised:";
            // 
            // CheckedListBox_ProvisionedClientTables
            // 
            this.CheckedListBox_ProvisionedClientTables.FormattingEnabled = true;
            this.CheckedListBox_ProvisionedClientTables.Location = new System.Drawing.Point(9, 206);
            this.CheckedListBox_ProvisionedClientTables.Name = "CheckedListBox_ProvisionedClientTables";
            this.CheckedListBox_ProvisionedClientTables.Size = new System.Drawing.Size(408, 94);
            this.CheckedListBox_ProvisionedClientTables.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(246, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tables which are not currently being synchronised:";
            // 
            // CheckedListBox_UnprovisionedProviderTables
            // 
            this.CheckedListBox_UnprovisionedProviderTables.FormattingEnabled = true;
            this.CheckedListBox_UnprovisionedProviderTables.Location = new System.Drawing.Point(9, 93);
            this.CheckedListBox_UnprovisionedProviderTables.Name = "CheckedListBox_UnprovisionedProviderTables";
            this.CheckedListBox_UnprovisionedProviderTables.Size = new System.Drawing.Size(408, 94);
            this.CheckedListBox_UnprovisionedProviderTables.TabIndex = 9;
            // 
            // Button_ProvisionTables
            // 
            this.Button_ProvisionTables.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Button_ProvisionTables.Location = new System.Drawing.Point(423, 164);
            this.Button_ProvisionTables.Name = "Button_ProvisionTables";
            this.Button_ProvisionTables.Size = new System.Drawing.Size(127, 23);
            this.Button_ProvisionTables.TabIndex = 7;
            this.Button_ProvisionTables.Text = "Add to Sync";
            this.Button_ProvisionTables.UseVisualStyleBackColor = true;
            this.Button_ProvisionTables.Click += new System.EventHandler(this.Button_ProvisionTables_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Client connection string:";
            // 
            // InputClientConnectionString
            // 
            this.InputClientConnectionString.Location = new System.Drawing.Point(132, 38);
            this.InputClientConnectionString.Name = "InputClientConnectionString";
            this.InputClientConnectionString.Size = new System.Drawing.Size(282, 20);
            this.InputClientConnectionString.TabIndex = 4;
            // 
            // Button_LoadClient
            // 
            this.Button_LoadClient.Location = new System.Drawing.Point(423, 36);
            this.Button_LoadClient.Name = "Button_LoadClient";
            this.Button_LoadClient.Size = new System.Drawing.Size(127, 23);
            this.Button_LoadClient.TabIndex = 3;
            this.Button_LoadClient.Text = "Update Connection";
            this.Button_LoadClient.UseVisualStyleBackColor = true;
            this.Button_LoadClient.Click += new System.EventHandler(this.Button_LoadClient_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Provider connection string:";
            // 
            // InputProviderConnectionString
            // 
            this.InputProviderConnectionString.Location = new System.Drawing.Point(145, 9);
            this.InputProviderConnectionString.Name = "InputProviderConnectionString";
            this.InputProviderConnectionString.Size = new System.Drawing.Size(269, 20);
            this.InputProviderConnectionString.TabIndex = 1;
            // 
            // Button_LoadProvider
            // 
            this.Button_LoadProvider.Location = new System.Drawing.Point(423, 7);
            this.Button_LoadProvider.Name = "Button_LoadProvider";
            this.Button_LoadProvider.Size = new System.Drawing.Size(127, 23);
            this.Button_LoadProvider.TabIndex = 0;
            this.Button_LoadProvider.Text = "Update Connection";
            this.Button_LoadProvider.UseVisualStyleBackColor = true;
            this.Button_LoadProvider.Click += new System.EventHandler(this.Button_LoadProvider_Click);
            // 
            // Button_DeprovisionProvider
            // 
            this.Button_DeprovisionProvider.Location = new System.Drawing.Point(556, 7);
            this.Button_DeprovisionProvider.Name = "Button_DeprovisionProvider";
            this.Button_DeprovisionProvider.Size = new System.Drawing.Size(84, 23);
            this.Button_DeprovisionProvider.TabIndex = 16;
            this.Button_DeprovisionProvider.Text = "Unpublish";
            this.Button_DeprovisionProvider.UseVisualStyleBackColor = true;
            this.Button_DeprovisionProvider.Click += new System.EventHandler(this.Button_DeprovisionProvider_Click);
            // 
            // Button_DeprovisionClient
            // 
            this.Button_DeprovisionClient.Location = new System.Drawing.Point(556, 36);
            this.Button_DeprovisionClient.Name = "Button_DeprovisionClient";
            this.Button_DeprovisionClient.Size = new System.Drawing.Size(84, 23);
            this.Button_DeprovisionClient.TabIndex = 18;
            this.Button_DeprovisionClient.Text = "Unsubscribe";
            this.Button_DeprovisionClient.UseVisualStyleBackColor = true;
            this.Button_DeprovisionClient.Click += new System.EventHandler(this.Button_DeprovisionClient_Click);
            // 
            // winMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 475);
            this.Controls.Add(this.tabControl1);
            this.Name = "winMain";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabSync.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabSettings.ResumeLayout(false);
            this.tabSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSync;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSyncNow;
        private System.Windows.Forms.RichTextBox txtStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InputProviderConnectionString;
        private System.Windows.Forms.Button Button_LoadProvider;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox InputClientConnectionString;
        private System.Windows.Forms.Button Button_LoadClient;
        private System.Windows.Forms.Button Button_ProvisionTables;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox CheckedListBox_UnprovisionedProviderTables;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox CheckedListBox_ProvisionedClientTables;
        private System.Windows.Forms.Button Button_DeprovisionClient;
        private System.Windows.Forms.Button Button_DeprovisionProvider;
    }
}

