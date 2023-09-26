using DevOpsTalk.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Security;

namespace DevOpsTalk.Core.Services
{
    public class PasswordResetService : IPasswordResetService
    {
        private readonly ILogger<PasswordResetService> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public PasswordResetService(ILogger<PasswordResetService> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public void ResetPasswords(IEnumerable<MemberResetModel> members)
        {
            foreach (var member in members.Where(m => m.ShouldReset == true))
            {
                ResetPassword(member.Email, "test123456");
                _logger.LogInformation("Password reset for {email}", member.Email);
            }
        }

        /// <summary>
        /// New way of password saving since V10
        /// </summary>
        /// <param name="member">The member.</param>
        /// <param name="password">The password.</param>
        private void ResetPassword(string email, string password)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var memberManager = scope.ServiceProvider.GetService<IMemberManager>() ?? throw new ArgumentNullException("memberManager", "Membermanager can't be null");
            var memberidentity = memberManager.FindByEmailAsync(email).GetAwaiter().GetResult() ?? throw new ArgumentNullException("memberidentity", "Membermanager can't be null"); ;

            var token = memberManager.GeneratePasswordResetTokenAsync(memberidentity).GetAwaiter().GetResult();
            memberManager.ChangePasswordWithResetAsync(memberidentity.Id.ToString(), token, password);
        }
    }
}
