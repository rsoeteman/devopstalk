using System.Reflection;

namespace DevopsTalk.Core.Helpers
{
    public class VersionInfoHelper : IVersionInfoHelper
    {
        /// <summary>
        /// Gets the version of the package .
        /// </summary>
        /// <returns></returns>
        public string GetVersion()
        {
            return GetType().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? string.Empty;
        }
    }
}
