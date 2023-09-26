using Microsoft.Extensions.Hosting;
using Umbraco.Cms.Core.Extensions;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;

namespace DevOpsTalk.AddTestData.Services
{
    internal class TestDataService : ITestDataService
    {
        private readonly IMemberGroupService _memberGroupService;
        private readonly IMemberService _memberService;
        private readonly IHostEnvironment _hostEnvironment;
        //Fake members to add
        private readonly List<string> _names = new() { "Jillian Kent", "Rhonda Henry", "Elise Mendez", "Everett Kane", "Tracy Petty", "Shannon Farmer", "Emanuel Hancock", "Sam Moore", "Ralph Dunlap", "Sal Pham", "Tamra Larsen", "Rubin Cantu", "Sanford Lawrence", "Donald Tanner", "Brett May", "Florine Stein", "Val Mccarty", "Josephine Patel", "Kent Nicholson", "Willy Perry", "Georgette Chaney", "Brain Washington", "Kim Frank", "Katy Ochoa", "Emilio Herman", "Shawn Perez", "Reyna Edwards", "Gordon Knight", "Charlene Brown", "Gary Obrien", "Jared Vasquez", "Brooke Stevenson", "Haley Savage", "Timothy Murray", "Stella Vargas", "Flossie Tucker", "Autumn York", "Brenda Holmes", "Douglas Gallagher", "Art Mason", "Stanford Benitez", "Eileen Blackburn", "Wilda Jefferson", "Florencio Roberson", "Erica Hahn", "Lionel Osborne", "Preston Michael", "Amber Hopkins", "Angelica Ferrell", "Angeline Cooper" };

        public TestDataService(
            IMemberGroupService memberGroupService,
            IMemberService memberService,
            IHostEnvironment hostEnvironment)
        {
            _memberGroupService = memberGroupService;
            _memberService = memberService;
            _hostEnvironment = hostEnvironment;
        }

        public void AddTestData()
        {
            EnsureMemberGroupsExists();
            EnsureViewsCopiedToDisk();
            AddMembers();
        }

        /// <summary>
        /// Adds Some test members
        /// </summary>
        private void AddMembers()
        {
            var random = new Random();
            var groups = new string[] { string.Empty, "Admin", "Employee", "Admin,Employee" };
            foreach (var name in _names)
            {
                var email = name.Replace(" ", string.Empty) + "@contoso.com";
                var member = _memberService.CreateMember(email, email, name, "member");
                _memberService.Save(member);

                //Add random groups
                var i = random.Next(0, groups.Length);
                foreach (var groupItem in groups[i].Split(",", StringSplitOptions.RemoveEmptyEntries))
                {
                    _memberService.AssignRole(member.Id, groupItem);
                }
            }
        }

        /// <summary>
        /// Ensures the member groups exists.
        /// </summary>
        private void EnsureMemberGroupsExists()
        {
            var memberGroups = new List<string> { "Admin", "Employee" };
            foreach (var membergroup in memberGroups)
            {
                var group = _memberGroupService.GetByName(membergroup);
                if (group == null)
                {
                    group = new MemberGroup()
                    {
                        Name = membergroup
                    };
                    _memberGroupService.Save(group);
                }
            }
        }

        /// <summary>
        /// Copies login functionality and modified content page
        /// </summary>
        private void EnsureViewsCopiedToDisk()
        {
            var currrentAssembly = this.GetType().Assembly;
            var assemblyname = currrentAssembly.GetName().Name ?? string.Empty;

            foreach (var manifestResource in currrentAssembly.GetManifestResourceNames())
            {
                var manifestResourceName = manifestResource.Replace(assemblyname, string.Empty);

                var manifestParts = manifestResourceName.Split('.', StringSplitOptions.RemoveEmptyEntries);
                manifestParts = manifestParts.Skip(1).ToArray();
                var folder = string.Join("/", manifestParts.Take(manifestParts.Length - 2));
                var filename = string.Join(".", manifestParts.Skip(manifestParts.Length - 2));

                var folderOndisk = _hostEnvironment.MapPathContentRoot(folder);

                if (!Directory.Exists(folderOndisk))
                {
                    Directory.CreateDirectory(folderOndisk);
                }

                var fileOnDisk = Path.Combine(folderOndisk, filename);

                using var stream = currrentAssembly.GetManifestResourceStream(manifestResource);
                using var fileStream = new FileStream(fileOnDisk, FileMode.Create, FileAccess.Write);
                stream?.CopyTo(fileStream);
            }
        }
    }
}
