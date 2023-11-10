using DevOpsTalk.AddTestData.Services;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace DevOpsTalk.AddTestData.Composers
{
    public class DevOpsTalkTestsDataInstallerComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddTransient<ITestDataService, TestDataService>();
        }
    }
}