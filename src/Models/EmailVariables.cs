namespace AllisonOwenWedding.Models
{
    /// <summary>
    /// Variables needed to send emails.
    /// </summary>
    public class EmailVariables
    {
        /// <summary>
        /// The email host.
        /// </summary>
        public string EmailHost { get; set; }

        /// <summary>
        /// The email address/username to send from.
        /// </summary>
        public string EmailUsername { get; set; }

        /// <summary>
        /// The email password.
        /// </summary>
        public string EmailPassword { get; set; }

        /// <summary>
        /// The address to send the update to.
        /// </summary>
        public string EmailRecipient { get; set; }

        /// <summary>
        /// The email port to utilize.
        /// </summary>
        public int EmailPort { get; set; }
    }
}
