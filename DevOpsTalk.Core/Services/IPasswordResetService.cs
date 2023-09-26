using DevOpsTalk.Core.Models;

namespace DevOpsTalk.Core.Services
{
    /// <summary>
    /// Service to reset all passwords
    /// </summary>
    public interface IPasswordResetService
    {
        /// <summary>
        /// Resets the passwords for the given members
        /// </summary>
        /// <param name="member">The members</param>
        void ResetPasswords(IEnumerable<MemberResetModel> members);
    }
}
