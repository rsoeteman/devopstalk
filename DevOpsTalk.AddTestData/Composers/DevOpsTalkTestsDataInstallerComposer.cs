using DevOpsTalk.AddTestData.Services;
using DevOpsTalk.AddTestData.Installer;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;

namespace DevOpsTalk.AddTestData.Composers
{
    public class DevOpsTalkTestsDataInstallerComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddTransient<ITestDataService, TestDataService>();
            builder.AddNotificationHandler<UmbracoApplicationStartingNotification, DevOpsTalkTestDataInstaller>();
        }
    }
}