using DevOpsTalk.Core.Models;
using DevOpsTalk.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.BackOffice.Controllers;
using Umbraco.Cms.Web.Common.Attributes;

namespace DevOpsTalk.Web.Controllers
{
    [PluginController("DevOpsTalk")]
    public class PasswordResetApiController : UmbracoAuthorizedApiController
    {
        private readonly IMemberService _memberService;
        private readonly IPasswordResetService _passwordResetService;
        private readonly ILogger<PasswordResetApiController> _logger;

        public PasswordResetApiController(IMemberService memberService, IPasswordResetService passwordResetService, ILogger<PasswordResetApiController> logger)
        {
            _memberService = memberService;
            _passwordResetService = passwordResetService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<MemberResetModel> GetAllMembers()
        {
            return _memberService.GetAllMembers().OrderBy(m=>m.Name).Select(m =>
                new MemberResetModel
                {
                    Id = m.Key,
                    Name = m.Name ?? string.Empty,
                    Email = m.Email
                });
        }

        /// <summary>
        /// Resets the passwords for the given members
        /// </summary>
        /// <param name="members">The members.</param>
        [HttpPost]
        public IActionResult ResetPasswords(IEnumerable<MemberResetModel> members)
        {
            try
            {
                _passwordResetService.ResetPasswords(members);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Error during password reset");
                return StatusCode(500);
            }
            return Ok();
        }
    }
}
