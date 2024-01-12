using Umbraco.Cms.Core.Packaging;

namespace DevOpsTalk.AddTestData.Installer
{
    /// <summary>
    /// Migration plan for our DevOpsTalk package
    /// </summary>
    /// <seealso cref="Umbraco.Cms.Core.Packaging.PackageMigrationPlan" />
    public class DevOpsTalkTestDataMigrationPlan : PackageMigrationPlan
    {
        public DevOpsTalkTestDataMigrationPlan() : base("DevOpsTalk") { }

        protected override void DefinePlan()
        {
            To<DevOpsTalkTestDataMigrations>("DevOpsTalkTestDataModification");
        }
    }
}