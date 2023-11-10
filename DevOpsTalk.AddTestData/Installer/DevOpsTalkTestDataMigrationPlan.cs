using Umbraco.Cms.Core.Packaging;

namespace DevOpsTalk.AddTestData.Installer
{
    public class DevOpsTalkTestDataMigrationPlan : PackageMigrationPlan
    {
        public DevOpsTalkTestDataMigrationPlan() : base("DevOpsTestDataMigrations") {}

        protected override void DefinePlan()
        {
            To<DevOpsTalkTestDataMigrations>("DevOpsTalkTestDataModification");
        }
    }
}
