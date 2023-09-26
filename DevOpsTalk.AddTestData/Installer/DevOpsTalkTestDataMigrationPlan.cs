using Umbraco.Cms.Infrastructure.Migrations;

namespace DevOpsTalk.AddTestData.Installer
{
    public class DevOpsTalkTestDataMigrationPlan : MigrationPlan
    {
        public DevOpsTalkTestDataMigrationPlan(string name) : base(name)
        {
            From(string.Empty).To<DevOpsTalkTestDataMigrations>("DevOpsTalkTestDataModification");

        }
    }
}
