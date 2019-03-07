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

namespace SyncWindowsInterface
{
    public partial class winMain : Form
    {
        public winMain()
        {
            InitializeComponent();
        }


        

        private void btnSyncNow_Click(object sender, EventArgs e)
        {
            txtStatus.Text = Sync.Synchronise("ProductsScope") + Sync.Synchronise("OrdersScope");
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
