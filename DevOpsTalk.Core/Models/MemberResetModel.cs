namespace DevOpsTalk.Core.Models
{
    /// <summary>
    /// Model used in our app so we can easily filter what members should be reset
    /// </summary>
    public class MemberResetModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether the password should be reset.
        /// </summary>
        public bool ShouldReset { get; set; }

        /// <summary>
        /// Gets or sets the name of the member.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email of the member.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the id of the member.
        /// </summary>
        public Guid Id { get; set; }
    }
}
