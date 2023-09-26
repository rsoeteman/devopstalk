using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Migrations;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core;
using Umbraco.Cms.Infrastructure.Migrations.Upgrade;
using Umbraco.Cms.Core.Scoping;

namespace DevOpsTalk.AddTestData.Installer
{
    public class DevOpsTalkTestDataInstaller : INotificationHandler<UmbracoApplicationStartingNotification>
    {
        private readonly ICoreScopeProvider _scopeProvider;
        private readonly IKeyValueService _keyValueService;
        private readonly IMigrationPlanExecutor _migrationPlanExecutor;
        private readonly ILogger<DevOpsTalkTestDataInstaller> _logger;

        public DevOpsTalkTestDataInstaller(IMigrationPlanExecutor migrationPlanExecutor, ICoreScopeProvider scopeProvider,
           IKeyValueService keyValueService, ILogger<DevOpsTalkTestDataInstaller> logger)
        {
            _scopeProvider = scopeProvider;
            _keyValueService = keyValueService;
            _logger = logger;
            _migrationPlanExecutor = migrationPlanExecutor;
        }
        public void Handle(UmbracoApplicationStartingNotification notification)
        {
            if (notification.RuntimeLevel >= RuntimeLevel.Run)
            {
                var plan = new DevOpsTalkTestDataMigrationPlan("DevOpsTestDataMigrations");
                _logger.LogDebug("DevOpsTestData: Check install");
                var upgrader = new Upgrader(plan);
                upgrader.Execute(_migrationPlanExecutor, _scopeProvider, _keyValueService);
            }
        }
    }
}
