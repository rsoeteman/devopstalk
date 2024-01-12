using System.Reflection;

namespace DevopsTalk.Core.Helpers
{
    public class VersionInfoHelper : IVersionInfoHelper
    {
        string? _version = null;

        /// <summary>
        /// Gets the version of the package .
        /// </summary>
        /// <returns></returns>
        public string GetVersion()
        {
            _version ??= GetVersionFromAssembly();
            return _version;
        }

        /// <summary>
        /// Gets the version from assembly, called lazy loaded so only called once.
        /// </summary>
        private string GetVersionFromAssembly()
        {
            return StripInformationalBuildSHAFromVersion(GetType().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? string.Empty);
        }

        /// <summary>
        /// Strips the informational build SHA from version.
        ///  1.0.0-beta1+8e29087e722d33bc5894dbcf875c27b1c4aab4cb wil be returned as 1.0.0-beta1
        /// </summary>
        /// <param name="version">The version.</param>
        /// <returns></returns>
        private static string StripInformationalBuildSHAFromVersion(string version)
        {
            return version.Split('+')[0];
        }
    }
}
