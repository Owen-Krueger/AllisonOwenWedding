namespace AllisonOwenWedding.Models
{
    /// <summary>
    /// Variables needed to send emails.
    /// </summary>
    public class EmailVariables
    {
        /// <summary>
        /// The email address/username to send from.
        /// </summary>
        public string EmailUsername { get; set; }

        /// <summary>
        /// The address to send the update to.
        /// </summary>
        public string EmailRecipient { get; set; }
    }
}
