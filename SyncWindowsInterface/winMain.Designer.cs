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
            this.Button_UnprovisionClient = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.Button_ProvisionProvider = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.CheckedListBox_UnprovisionedProviderTables = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Button_ProvisionClient = new System.Windows.Forms.Button();
            this.CheckedListBox_ProvisionedProviderTables = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.InputClientConnectionString = new System.Windows.Forms.TextBox();
            this.ButtonLoadClient = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.InputProviderConnectionString = new System.Windows.Forms.TextBox();
            this.ButtonLoadProvider = new System.Windows.Forms.Button();
            this.Button_UnprovisionProvider = new System.Windows.Forms.Button();
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
            this.tabControl1.Size = new System.Drawing.Size(577, 451);
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
            this.tabSync.Size = new System.Drawing.Size(569, 425);
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
            this.dataGridView1.Size = new System.Drawing.Size(0, 412);
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
            this.tabSettings.Controls.Add(this.Button_UnprovisionProvider);
            this.tabSettings.Controls.Add(this.label5);
            this.tabSettings.Controls.Add(this.Button_UnprovisionClient);
            this.tabSettings.Controls.Add(this.checkedListBox1);
            this.tabSettings.Controls.Add(this.Button_ProvisionProvider);
            this.tabSettings.Controls.Add(this.label4);
            this.tabSettings.Controls.Add(this.CheckedListBox_UnprovisionedProviderTables);
            this.tabSettings.Controls.Add(this.label3);
            this.tabSettings.Controls.Add(this.Button_ProvisionClient);
            this.tabSettings.Controls.Add(this.CheckedListBox_ProvisionedProviderTables);
            this.tabSettings.Controls.Add(this.label2);
            this.tabSettings.Controls.Add(this.InputClientConnectionString);
            this.tabSettings.Controls.Add(this.ButtonLoadClient);
            this.tabSettings.Controls.Add(this.label1);
            this.tabSettings.Controls.Add(this.InputProviderConnectionString);
            this.tabSettings.Controls.Add(this.ButtonLoadProvider);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(569, 425);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "Settings";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(337, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Tables which are currently being synced from the provider to the client";
            // 
            // Button_UnprovisionClient
            // 
            this.Button_UnprovisionClient.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Button_UnprovisionClient.Location = new System.Drawing.Point(423, 390);
            this.Button_UnprovisionClient.Name = "Button_UnprovisionClient";
            this.Button_UnprovisionClient.Size = new System.Drawing.Size(134, 23);
            this.Button_UnprovisionClient.TabIndex = 13;
            this.Button_UnprovisionClient.Text = "Remove from Sync";
            this.Button_UnprovisionClient.UseVisualStyleBackColor = true;
            this.Button_UnprovisionClient.Click += new System.EventHandler(this.Button_UnprovisionClient_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(9, 319);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(408, 94);
            this.checkedListBox1.TabIndex = 12;
            // 
            // Button_ProvisionProvider
            // 
            this.Button_ProvisionProvider.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Button_ProvisionProvider.Location = new System.Drawing.Point(426, 164);
            this.Button_ProvisionProvider.Name = "Button_ProvisionProvider";
            this.Button_ProvisionProvider.Size = new System.Drawing.Size(134, 23);
            this.Button_ProvisionProvider.TabIndex = 11;
            this.Button_ProvisionProvider.Text = "Make Syncable";
            this.Button_ProvisionProvider.UseVisualStyleBackColor = true;
            this.Button_ProvisionProvider.Click += new System.EventHandler(this.Button_ProvisionProvider_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(287, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tables which are not available for syncing from the provider";
            // 
            // CheckedListBox_UnprovisionedProviderTables
            // 
            this.CheckedListBox_UnprovisionedProviderTables.FormattingEnabled = true;
            this.CheckedListBox_UnprovisionedProviderTables.Location = new System.Drawing.Point(9, 93);
            this.CheckedListBox_UnprovisionedProviderTables.Name = "CheckedListBox_UnprovisionedProviderTables";
            this.CheckedListBox_UnprovisionedProviderTables.Size = new System.Drawing.Size(408, 94);
            this.CheckedListBox_UnprovisionedProviderTables.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(327, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tables which are available for syncing from the provider to the client";
            // 
            // Button_ProvisionClient
            // 
            this.Button_ProvisionClient.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Button_ProvisionClient.Location = new System.Drawing.Point(423, 277);
            this.Button_ProvisionClient.Name = "Button_ProvisionClient";
            this.Button_ProvisionClient.Size = new System.Drawing.Size(134, 23);
            this.Button_ProvisionClient.TabIndex = 7;
            this.Button_ProvisionClient.Text = "Add to Sync";
            this.Button_ProvisionClient.UseVisualStyleBackColor = true;
            this.Button_ProvisionClient.Click += new System.EventHandler(this.Button_ProvisionClient_Click);
            // 
            // CheckedListBox_ProvisionedProviderTables
            // 
            this.CheckedListBox_ProvisionedProviderTables.FormattingEnabled = true;
            this.CheckedListBox_ProvisionedProviderTables.Location = new System.Drawing.Point(9, 206);
            this.CheckedListBox_ProvisionedProviderTables.Name = "CheckedListBox_ProvisionedProviderTables";
            this.CheckedListBox_ProvisionedProviderTables.Size = new System.Drawing.Size(408, 94);
            this.CheckedListBox_ProvisionedProviderTables.TabIndex = 6;
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
            // ButtonLoadClient
            // 
            this.ButtonLoadClient.Location = new System.Drawing.Point(423, 36);
            this.ButtonLoadClient.Name = "ButtonLoadClient";
            this.ButtonLoadClient.Size = new System.Drawing.Size(134, 23);
            this.ButtonLoadClient.TabIndex = 3;
            this.ButtonLoadClient.Text = "Update Data Client";
            this.ButtonLoadClient.UseVisualStyleBackColor = true;
            this.ButtonLoadClient.Click += new System.EventHandler(this.ButtonLoadClient_Click);
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
            // ButtonLoadProvider
            // 
            this.ButtonLoadProvider.Location = new System.Drawing.Point(423, 7);
            this.ButtonLoadProvider.Name = "ButtonLoadProvider";
            this.ButtonLoadProvider.Size = new System.Drawing.Size(134, 23);
            this.ButtonLoadProvider.TabIndex = 0;
            this.ButtonLoadProvider.Text = "Update Data Provider";
            this.ButtonLoadProvider.UseVisualStyleBackColor = true;
            this.ButtonLoadProvider.Click += new System.EventHandler(this.ButtonLoadProvider_Click);
            // 
            // Button_UnprovisionProvider
            // 
            this.Button_UnprovisionProvider.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Button_UnprovisionProvider.Location = new System.Drawing.Point(423, 248);
            this.Button_UnprovisionProvider.Name = "Button_UnprovisionProvider";
            this.Button_UnprovisionProvider.Size = new System.Drawing.Size(134, 23);
            this.Button_UnprovisionProvider.TabIndex = 15;
            this.Button_UnprovisionProvider.Text = "Make Unsyncable";
            this.Button_UnprovisionProvider.UseVisualStyleBackColor = true;
            this.Button_UnprovisionProvider.Click += new System.EventHandler(this.Button_UnprovisionProvider_Click);
            // 
            // winMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 475);
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
        private System.Windows.Forms.Button ButtonLoadProvider;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox InputClientConnectionString;
        private System.Windows.Forms.Button ButtonLoadClient;
        private System.Windows.Forms.CheckedListBox CheckedListBox_ProvisionedProviderTables;
        private System.Windows.Forms.Button Button_ProvisionClient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox CheckedListBox_UnprovisionedProviderTables;
        private System.Windows.Forms.Button Button_ProvisionProvider;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Button_UnprovisionClient;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button Button_UnprovisionProvider;
    }
}

