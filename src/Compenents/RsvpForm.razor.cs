using AllisonOwenWedding.DataAccess;
using AllisonOwenWedding.Services;
using AllisonOwenWedding.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AllisonOwenWedding.Compenents
{
    /// <summary>
    /// For interacting with the Rsvp form
    /// </summary>
    public partial class RsvpForm
    {
        [Inject]
        private ILogger<RsvpForm> Logger { get; set; }

        [Inject]
        private IWeddingService WeddingService { get; set; }

        [Inject]
        private IEmailService EmailService { get; set; }

        [Parameter]
        public WeddingInvitee WeddingInvitee { get; set; }

        [Parameter]
        public EventCallback ResetForm { get; set; }

        private Dialog ErrorDialog { get; set; }

        private bool IsGuestInputDisabled
        {
            get
            {
                return !WeddingInvitee.Accepted;
            }
        }

        /// <summary>
        /// Update the invitee and request the form to reset
        /// </summary>
        private async Task UpdateInviteeAsync()
        {
            string fullName = WeddingInvitee.InviteeIdentifiers[0].FullName;
            Logger.LogInformation("Updating '{FullName}': Accepted: {Accepted} Guests: {Guests}", fullName, WeddingInvitee.Accepted, WeddingInvitee.GuestsComing);

            WeddingInvitee.Completed = true;
            WeddingInvitee.GuestsComing = WeddingInvitee.Accepted ? WeddingInvitee.GuestsComing : 0;

            bool databaseResult = await WeddingService.UpdateInviteeAsync();
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
