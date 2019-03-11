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

namespace ProvisionProvider
{
    class Program
    {
        static void Main(string[] args)
        {
            // this introduction article is worth a read 
            // https://visualstudiomagazine.com/articles/2012/06/01/database-synchronization-with-the-microsoft-sync-framework.aspx
            // sync framework tips from TechNet
            // https://social.technet.microsoft.com/wiki/contents/articles/1858.sync-framework-tips-and-troubleshooting.aspx
            // might want to look at this too for Change Tracking
            // https://mentormate.com/blog/database-synchronization-with-microsoft-sync-framework/

            Provisioning.CreateProviderProvision("BenTableScope", "BenTable", DataStore.ServerConn);
            Console.WriteLine("BenTableScope was created!");
            Console.ReadLine();
            Provisioning.CreateProviderProvision("ProductsScope", "Products", DataStore.ServerConn);
            Provisioning.CreateProviderProvision("OrdersScope", "Orders", DataStore.ServerConn);

            return;
        }

        #region 2BAP Provisions
        // don't add these if only doing the simple test
        /*
        CreateProvision("z_Scope_2Bapv1CatagoryMap", "[2bap].[2Bapv1CategoryMap]");
        CreateProvision("z_Scope_2Bapv1CategoryToLevelMap", "[2bap].[2Bapv1CategoryToLevelMap]");
        CreateProvision("z_Scope_AssessmentScheme", "[2bap].[AssessmentScheme]");
        CreateProvision("z_Scope_AssessmentSchemeJudgement", "[2bap].[AssessmentSchemeJudgement]");
        CreateProvision("z_Scope_CurriculumFramework", "[2bap].[CurriculumFramework]");
        CreateProvision("z_Scope_FrameworkCategory", "[2bap].[FrameworkCategory]");
        CreateProvision("z_Scope_Note", "[2bap].[Note]");
        CreateProvision("z_Scope_Objective", "[2bap].[Objective]");
        CreateProvision("z_Scope_ObjectiveLevel", "[2bap].[ObjectiveLevel]");
        CreateProvision("z_Scope_ObjectiveLevelScheme", "[2bap].[ObjectiveLevelScheme]");
        CreateProvision("z_Scope_ObjectiveLevelYearGroup", "[2bap].[ObjectiveLevelYearGroup]");
        CreateProvision("z_Scope_Observation", "[2bap].[Observation]");
        CreateProvision("z_Scope_ObservationLearner", "[2bap].[ObservationLearner]");
        CreateProvision("z_Scope_ObservationNote", "[2bap].[ObservationNote]");
        CreateProvision("z_Scope_ObservationObjective", "[2bap].[ObservationObjective]");
        CreateProvision("z_Scope_SchoolYearPeriod", "[2bap].[SchoolYearPeriod]");

        CreateProvision("z_Scope_AdminModuleMenuItem", "[dbo].[AdminModuleMenuItem]");
        CreateProvision("z_Scope_AdminModuleMenuItemRoleItem", "[dbo][.AdminModuleMenuItemRoleItem]");
        CreateProvision("z_Scope_AuditEvent", "[dbo].[AuditEvent]");
        CreateProvision("z_Scope_AuditEventType", "[dbo].[AuditEventType]");
        CreateProvision("z_Scope_AvatarFileInfo", "[dbo].[AvatarFileInfo]");
        CreateProvision("z_Scope_BookBand", "[dbo].[BookBand]");
        CreateProvision("z_Scope_BookBandYearGroup", "[dbo].[BookBandYearGroup]");
        CreateProvision("z_Scope_BookPack", "[dbo].[BookPack]");
        CreateProvision("z_Scope_BookPackMiscueBook", "[dbo].[BookPackMiscueBook]");
        CreateProvision("z_Scope_BookPackSchool", "[dbo].[BookPackSchool]");
        CreateProvision("z_Scope_Client", "[dbo].[Client]");
        CreateProvision("z_Scope_DbVersion", "[dbo].[DbVersion]");
        CreateProvision("z_Scope_Group", "[dbo].[Group]");
        CreateProvision("z_Scope_GroupUser", "[dbo].[GroupUser]");
        CreateProvision("z_Scope_HiLo", "[dbo].[HiLo]");
        CreateProvision("z_Scope_Learner", "[dbo].[Learner]");
        CreateProvision("z_Scope_LearnerGroup", "[dbo].[LearnerGroup]");
        CreateProvision("z_Scope_LearnerProfile", "[dbo].[LearnerProfile]");
        CreateProvision("z_Scope_LearnerTag", "[dbo].[LearnerTag]");
        CreateProvision("z_Scope_MiscueBook", "[dbo].[MiscueBook]");
        CreateProvision("z_Scope_MiscueSession", "[dbo].[MiscueSession]");
        CreateProvision("z_Scope_MiscueSessionComment", "[dbo].[MiscueSessionComment]");
        CreateProvision("z_Scope_MiscueSessionLevel", "[dbo].[MiscueSessionLevel]");
        CreateProvision("z_Scope_MiscueSessionRecordFileInfo", "[dbo].[MiscueSessionRecordFileInfo]");
        CreateProvision("z_Scope_MiscueType", "[dbo].[MiscueType]");
        CreateProvision("z_Scope_MiscueTypeGroup", "[dbo].[MiscueTypeGroup]");
        */
        #endregion

        






    }
}
