using DevOpsTalk.AddTestData.Services;
using Umbraco.Cms.Infrastructure.Migrations;

namespace DevOpsTalk.AddTestData.Installer
{
    public class DevOpsTalkTestDataMigrations : MigrationBase
    {
        private readonly ITestDataService _testDataService;

        public DevOpsTalkTestDataMigrations(IMigrationContext context, ITestDataService testDataService) : base(context)
        {
            _testDataService = testDataService;
        }

        protected override void Migrate()
        {
            _testDataService.AddTestData();
        }
    }
}
