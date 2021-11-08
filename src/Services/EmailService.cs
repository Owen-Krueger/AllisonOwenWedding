using AllisonOwenWedding.Models;
using System;
using System.Net.Mail;

namespace AllisonOwenWedding.Services
{
    /// <inheritdoc />
    public class EmailService : IEmailService
    {
        private readonly SmtpClient _client;
        private readonly EmailVariables _emailVariables;

        /// <summary>
        /// Constructor
        /// </summary>
        public EmailService(SmtpClient client, EmailVariables emailVariables)
        {
            _client = client;
            _emailVariables = emailVariables;
        }

        /// <inheritdoc />
        public bool SendUpdateEmail(string name, bool accepted, int guestsComing)
        {
            bool success = true;
            try
            {
                var message = new MailMessage(_emailVariables.EmailUsername, _emailVariables.EmailRecipient)
                {
                    Subject = $"Wedding Update: {name}",
                    Body = $"{name} has updated their response to: Accepted={accepted} Guests={guestsComing}"
                };

                _client.Send(message);
            }
            catch (Exception e)
            {
                success = false;
            }

            return success;
        }
    }
}
