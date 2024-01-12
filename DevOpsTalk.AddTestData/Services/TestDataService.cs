using Microsoft.Extensions.Hosting;
using Umbraco.Cms.Core.Extensions;
using Umbraco.Cms.Core.Services;

namespace DevOpsTalk.AddTestData.Services
{
    internal class TestDataService : ITestDataService
    {
        private readonly IMemberService _memberService;
        private readonly IHostEnvironment _hostEnvironment;

        public TestDataService(IMemberService memberService, IHostEnvironment hostEnvironment)
        {
            _memberService = memberService;
            _hostEnvironment = hostEnvironment;
        }

        public void AddTestData()
        {
            AddMembers();
            EnsureViewsCopiedToDisk();
        }

        /// <summary>
        /// Adds Some test members
        /// </summary>
        private void AddMembers()
        {
            //Fake members to add
            var names = new List<string> { "Jillian Kent", "Rhonda Henry", "Elise Mendez", "Everett Kane", "Tracy Petty", "Shannon Farmer", "Emanuel Hancock", "Sam Moore", "Ralph Dunlap", "Sal Pham", "Tamra Larsen", "Rubin Cantu", "Sanford Lawrence", "Donald Tanner", "Brett May", "Florine Stein", "Val Mccarty", "Josephine Patel", "Kent Nicholson", "Willy Perry", "Georgette Chaney", "Brain Washington", "Kim Frank", "Katy Ochoa", "Emilio Herman", "Shawn Perez", "Reyna Edwards", "Gordon Knight", "Charlene Brown", "Gary Obrien", "Jared Vasquez", "Brooke Stevenson", "Haley Savage", "Timothy Murray", "Stella Vargas", "Flossie Tucker", "Autumn York", "Brenda Holmes", "Douglas Gallagher", "Art Mason", "Stanford Benitez", "Eileen Blackburn", "Wilda Jefferson", "Florencio Roberson", "Erica Hahn", "Lionel Osborne", "Preston Michael", "Amber Hopkins", "Angelica Ferrell", "Angeline Cooper" };

            foreach (var name in names)
            {
                var email = name.Replace(" ", string.Empty) + "@contoso.com";
                var member = _memberService.CreateMember(email, email, name, "member");
                _memberService.Save(member);
            }
        }

        /// <summary>
        /// Copies login functionality and modified content page
        /// </summary>
        private void EnsureViewsCopiedToDisk()
        {
            var currentAssembly = this.GetType().Assembly;
            var assemblyName = currentAssembly.GetName().Name ?? string.Empty;

            foreach (var manifestResource in currentAssembly.GetManifestResourceNames())
            {
                var manifestResourceName = manifestResource.Replace(assemblyName, string.Empty);

                //Modify Resource name to a filename
                var manifestParts = manifestResourceName.Split('.', StringSplitOptions.RemoveEmptyEntries);
                manifestParts = manifestParts.Skip(1).ToArray();
                var folder = string.Join("/", manifestParts.Take(manifestParts.Length - 2));
                var filename = string.Join(".", manifestParts.Skip(manifestParts.Length - 2));

                var folderOnDisk = _hostEnvironment.MapPathContentRoot(folder);

                if (!Directory.Exists(folderOnDisk))
                {
                    Directory.CreateDirectory(folderOnDisk);
                }

                var fileOnDisk = Path.Combine(folderOnDisk, filename);

                //Replace existing files
                using var stream = currentAssembly.GetManifestResourceStream(manifestResource);
                using var fileStream = new FileStream(fileOnDisk, FileMode.Create, FileAccess.Write);
                stream?.CopyTo(fileStream);
            }
        }
    }
}
