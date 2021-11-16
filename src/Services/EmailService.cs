using AllisonOwenWedding.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Mail;

namespace AllisonOwenWedding.Services
{
    /// <inheritdoc />
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;
        private readonly SmtpClient _client;
        private readonly EmailVariables _emailVariables;

        /// <summary>
        /// Constructor
        /// </summary>
        public EmailService(ILogger<EmailService> logger, SmtpClient client, EmailVariables emailVariables)
        {
            _logger = logger;
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
                _logger.LogError("Exception thrown while sending update email: {Exception}", e.Message);
                success = false;
            }

            return success;
        }
    }
}
