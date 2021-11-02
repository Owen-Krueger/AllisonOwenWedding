using AllisonOwenWedding.DataAccess;
using AllisonOwenWedding.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace AllisonOwenWedding.Compenents
{
    /// <summary>
    /// For interacting with the Rsvp form
    /// </summary>
    public partial class RsvpForm
    {
        [Inject]
        private IWeddingService WeddingService { get; set; }

        [Inject]
        private IEmailService EmailService { get; set; }

        [Parameter]
        public WeddingInvitee WeddingInvitee { get; set; }

        [Parameter]
        public EventCallback ResetForm { get; set; }

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
            WeddingInvitee.Completed = true;
            await WeddingService.UpdateInviteeAsync();
            EmailService.SendUpdateEmail(WeddingInvitee.InviteeIdentifiers[0].FullName, WeddingInvitee.Accepted, WeddingInvitee.GuestsComing);
            await ResetForm.InvokeAsync();
        }
    }
}
