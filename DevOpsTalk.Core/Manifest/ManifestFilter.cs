using DevopsTalk.Core.Helpers;
using Umbraco.Cms.Core.Manifest;

namespace DevopsTalk.Core.Manifest
{
    public class ManifestFilter : IManifestFilter
    {
        private readonly IVersionInfoHelper _versionInfoHelper;

        public ManifestFilter(IVersionInfoHelper versionInfoHelper)
        {
            _versionInfoHelper = versionInfoHelper;
        }

        public void Filter(List<PackageManifest> manifests)
        {
            manifests.Add(new PackageManifest
            {
                PackageName = "Devops Talk",
                Version = _versionInfoHelper.GetVersion(),
                AllowPackageTelemetry = false,
                BundleOptions = BundleOptions.Independent,
                Dashboards = new[] { new ManifestDashboard
                    {
                        Alias = "devopsTalkDashboard",
                        View = "/App_Plugins/DevOpsTalk/memberresetdashboard.html",
                        Sections = new[] {"member" }
                    }
                },
                Scripts = new[]
                    {
                    "/App_Plugins/DevOpsTalk/memberresetdashboard.controller.js"
                    }
            });
        }
    }
}
