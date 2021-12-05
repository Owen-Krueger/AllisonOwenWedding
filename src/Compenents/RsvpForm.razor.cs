using AllisonOwenWedding.DataAccess;
using AllisonOwenWedding.Models;
using AllisonOwenWedding.Services;
using AllisonOwenWedding.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Polly;
using System.Threading.Tasks;

namespace AllisonOwenWedding.Compenents
{
    /// <summary>
    /// For interacting with the Rsvp form
    /// </summary>
    public partial class RsvpForm
    {
        /// <summary>
        /// For logging.
        /// </summary>
        [Inject]
        private ILogger<RsvpForm> Logger { get; set; }

        /// <summary>
        /// For updating invitee.
        /// </summary>
        [Inject]
        private IWeddingService WeddingService { get; set; }

        /// <summary>
        /// For sending emails.
        /// </summary>
        [Inject]
        private IEmailService EmailService { get; set; }

        /// <summary>
        /// Invitee from database to update.
        /// </summary>
        [Parameter]
        public WeddingInvitee WeddingInvitee { get; set; }

        /// <summary>
        /// Form update properties.
        /// </summary>
        private RsvpInviteeUpdate InviteeUpdate { get; set; }

        /// <summary>
        /// Callback to reset form to search.
        /// </summary>
        [Parameter]
        public EventCallback ResetForm { get; set; }

        /// <summary>
        /// Ref to the error dialog.
        /// </summary>
        private Dialog ErrorDialog { get; set; }

        /// <summary>
        /// Set form elements to invitee information from database.
        /// </summary>
        protected override void OnInitialized()
        {
            InviteeUpdate = new(WeddingInvitee);
        }

        /// <summary>
        /// Whether or not the number of guests coming input is disabled.
        /// </summary>
        private bool IsGuestInputDisabled
        {
            get
            {
                return !InviteeUpdate.Accepted;
            }
        }

        /// <summary>
        /// Whether or not the submit button is disabled.
        /// </summary>
        private bool IsSubmitButtonDisabled
        {
            get
            {
                return InviteeUpdate.RsvpResponse == AcceptedResponse.Default;
            }
        }

        /// <summary>
        /// Update the invitee and request the form to reset
        /// </summary>
        public async Task UpdateInviteeAsync()
        {
            string fullName = WeddingInvitee.InviteeIdentifiers[0].FullName;
            Logger.LogInformation("Updating '{FullName}': Accepted: {Accepted} Guests: {Guests}", fullName, WeddingInvitee.Accepted, WeddingInvitee.GuestsComing);
            
            WeddingInvitee.Completed = true;
            WeddingInvitee.Accepted = InviteeUpdate.Accepted;
            WeddingInvitee.GuestsComing = InviteeUpdate.GuestsComing;

            var databasePolicy = Policy.HandleResult<bool>(x => !x).RetryAsync(3);
            bool databaseResult = await databasePolicy.ExecuteAsync(() => WeddingService.UpdateInviteeAsync());

            bool emailResult = EmailService.SendUpdateEmail(fullName, WeddingInvitee.Accepted, WeddingInvitee.GuestsComing);

            if(!databaseResult && !emailResult)
            {
                Logger.LogError("Failed to update database and send email update.");
                ErrorDialog.Show();
            }
            else
            {
                await ResetForm.InvokeAsync();
            }
        }
    }
}
