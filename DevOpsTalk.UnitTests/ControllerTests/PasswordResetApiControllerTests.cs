using DevOpsTalk.Core.Services;
using DevOpsTalk.Web.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;

namespace DevOpsTalk.UnitTests.ControllerTests
{
    [TestFixture]
    public class PasswordResetApiControllerTests
    {
        [Test]
        public void Given_Members_GetAllMembers_Should_Return_A_Collection()
        {
            //arrange
            var members = new List<IMember>
            {
                Mock.Of<IMember>(m =>
                m.Key == new Guid("ffde2186-4a14-42b0-8cef-8b76431be90a") &&
                m.Name == "John Doe" &&
                m.Email == "jdoe@contoso.com")
            };

            var controller = new PasswordResetApiController(
                Mock.Of<IMemberService>(m=>m.GetAllMembers() == members),
                Mock.Of<IPasswordResetService>(),
                Mock.Of<ILogger<PasswordResetApiController>>());

            //act
            var result = controller.GetAllMembers();

            //assert

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("ffde2186-4a14-42b0-8cef-8b76431be90a", result.First().Id.ToString());
            Assert.AreEqual("John Doe", result.First().Name);
            Assert.AreEqual("jdoe@contoso.com", result.First().Email);

        }
    }
}
