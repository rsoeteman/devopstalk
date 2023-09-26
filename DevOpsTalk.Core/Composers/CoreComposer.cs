using DevopsTalk.Core.Helpers;
using DevopsTalk.Core.Manifest;
using DevOpsTalk.Core.NotificationHandlers;
using DevOpsTalk.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;

namespace DevOpsTalk.Core.Composers
{
    /// <summary>
    /// Register our services, helpers, notification handlers and Manifestfilter via a composer since we can't use startup.cs
    /// </summary>
    /// <seealso cref="IComposer" />
    public class CoreComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            //Register services and helpers
            builder.Services.AddTransient<IPasswordResetService, PasswordResetService>();
            builder.Services.AddTransient<IVersionInfoHelper, VersionInfoHelper>();

            //Register notification handlers
            builder.AddNotificationHandler<ServerVariablesParsingNotification, AppendVersionNumberNotificationHandler>();

            //Register Manifest filter
            builder.ManifestFilters().Append<ManifestFilter>();
        }
    }
}
