using AllisonOwenWedding.Models;
using System;
using System.Net;
using System.Net.Mail;

namespace AllisonOwenWedding.Services
{
    /// <inheritdoc />
    public class EmailService : IEmailService
    {
        private readonly EmailVariables _emailVariables;

        /// <summary>
        /// Constructor
        /// </summary>
        public EmailService(EmailVariables emailVariables)
        {
            _emailVariables = emailVariables;
        }

        /// <inheritdoc />
        public bool SendUpdateEmail(string name, bool accepted, int guestsComing)
        {
            bool success = true;
            try
            {
                var client = new SmtpClient()
                {
                    Host = _emailVariables.EmailHost,
                    Port = _emailVariables.EmailPort,
                    Credentials = new NetworkCredential(_emailVariables.EmailUsername, _emailVariables.EmailPassword),
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };

                var message = new MailMessage(_emailVariables.EmailUsername, _emailVariables.EmailRecipient)
                {
                    Subject = $"Wedding Update: {name}",
                    Body = $"{name} has updated their response to: Accepted={accepted} Guests={guestsComing}"
                };

                client.Send(message);
            }
            catch (Exception e)
            {
                success = false;
            }

            return success;
        }
    }
}
