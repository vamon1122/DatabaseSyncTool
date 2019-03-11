using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;
using Data;
using SyncSql;


namespace ProvisionClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Provisioning.CreateClientProvision("ProductsScope", DataStore.ClientConn, DataStore.ServerConn);
            Provisioning.CreateClientProvision("OrdersScope", DataStore.ClientConn, DataStore.ServerConn);
        }

        #region 2BAP Provisions
        // don't run these for simple test
        /*
        CreateProvision("z_Scope_2Bapv1CatagoryMap");
        CreateProvision("z_Scope_2Bapv1CategoryToLevelMap");
        CreateProvision("z_Scope_AssessmentScheme");
        CreateProvision("z_Scope_AssessmentSchemeJudgement");
        CreateProvision("z_Scope_CurriculumFramework");
        CreateProvision("z_Scope_FrameworkCategory");
        CreateProvision("z_Scope_Note");
        CreateProvision("z_Scope_Objective");
        CreateProvision("z_Scope_ObjectiveLevel");
        CreateProvision("z_Scope_ObjectiveLevelScheme");
        CreateProvision("z_Scope_ObjectiveLevelYearGroup");
        CreateProvision("z_Scope_Observation");
        CreateProvision("z_Scope_ObservationLearner");
        CreateProvision("z_Scope_ObservationNote");
        CreateProvision("z_Scope_ObservationObjective");
        CreateProvision("z_Scope_SchoolYearPeriod");
        CreateProvision("z_Scope_AdminModuleMenuItem");
        CreateProvision("z_Scope_AdminModuleMenuItemRoleItem");

        CreateProvision("z_Scope_AuditEvent");
        CreateProvision("z_Scope_AuditEventType");
        CreateProvision("z_Scope_AvatarFileInfo");
        CreateProvision("z_Scope_BookBand");
        CreateProvision("z_Scope_BookBandYearGroup");
        CreateProvision("z_Scope_BookPack");
        CreateProvision("z_Scope_BookPackMiscueBook");
        CreateProvision("z_Scope_BookPackSchool");
        CreateProvision("z_Scope_Client");
        CreateProvision("z_Scope_DbVersion");
        CreateProvision("z_Scope_Group");
        CreateProvision("z_Scope_GroupUser");

        CreateProvision("z_Scope_HiLo");
        CreateProvision("z_Scope_Learner");
        CreateProvision("z_Scope_LearnerGroup");
        CreateProvision("z_Scope_LearnerProfile");
        CreateProvision("z_Scope_LearnerTag");
        CreateProvision("z_Scope_MiscueBook");
        CreateProvision("z_Scope_MiscueSession");
        CreateProvision("z_Scope_MiscueSessionComment");
        CreateProvision("z_Scope_MiscueSessionLevel");
        CreateProvision("z_Scope_MiscueSessionRecordFileInfo");
        CreateProvision("z_Scope_MiscueType");
        CreateProvision("z_Scope_MiscueTypeGroup");
        */
        #endregion
    }
}
