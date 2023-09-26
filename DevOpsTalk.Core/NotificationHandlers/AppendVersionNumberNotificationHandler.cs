using DevopsTalk.Core.Helpers;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace DevOpsTalk.Core.NotificationHandlers
{
    /// <summary>
    /// Notification handler to append the version number to the server variables
    /// </summary>
    public class AppendVersionNumberNotificationHandler : INotificationHandler<ServerVariablesParsingNotification>
    {
        private readonly IVersionInfoHelper _versionInfoHelper;

        public AppendVersionNumberNotificationHandler(IVersionInfoHelper versionInfoHelper)
        {
            _versionInfoHelper = versionInfoHelper;
        }

        /// <summary>
        /// Handles a notification
        /// </summary>
        /// <param name="notification">The notification</param>
        public void Handle(ServerVariablesParsingNotification notification)
        {
            notification.ServerVariables.Add("devopsTalkPackageVersion", _versionInfoHelper.GetVersion());
        }
    }
}
