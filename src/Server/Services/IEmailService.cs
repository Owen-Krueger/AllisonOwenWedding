namespace AllisonOwenWedding.Services
{
    /// <summary>
    /// For sending email updates.
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Sends an email update.
        /// </summary>
        /// <param name="name">Name of the invitee.</param>
        /// <param name="accepted">Whether or not the invitee accepted the invite.</param>
        /// <param name="guestsComing">The number of guests coming with.</param>
        /// <returns>Whether or not the email was successfully sent.</returns>
        bool SendUpdateEmail(string name, bool accepted, int guestsComing);
    }
}
