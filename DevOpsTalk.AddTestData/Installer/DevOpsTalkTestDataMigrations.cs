using DevOpsTalk.AddTestData.Services;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.Configuration.Models;
using Umbraco.Cms.Core.IO;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Strings;
using Umbraco.Cms.Infrastructure.Migrations;
using Umbraco.Cms.Infrastructure.Packaging;

namespace DevOpsTalk.AddTestData.Installer
{
    public class DevOpsTalkTestDataMigrations : PackageMigrationBase
    {
        private readonly ITestDataService _testDataService;

        public DevOpsTalkTestDataMigrations(IPackagingService packagingService,
            IMediaService mediaService,
            MediaFileManager mediaFileManager,
            MediaUrlGeneratorCollection mediaUrlGenerators,
            IShortStringHelper shortStringHelper,
            IContentTypeBaseServiceProvider contentTypeBaseServiceProvider,
            IMigrationContext context,
            IOptions<PackageMigrationSettings> packageMigrationsSettings,
            ITestDataService testDataService) : base(packagingService, mediaService, mediaFileManager, mediaUrlGenerators, shortStringHelper, contentTypeBaseServiceProvider, context, packageMigrationsSettings)
        {
            _testDataService = testDataService;
        }

        protected override void Migrate()
        {
            _testDataService.AddTestData();
        }
    }
}
