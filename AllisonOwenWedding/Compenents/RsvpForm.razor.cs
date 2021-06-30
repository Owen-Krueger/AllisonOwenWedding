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

        [Parameter]
        public WeddingInvitee WeddingInvitee { get; set; }

        [Parameter]
        public EventCallback ResetForm { get; set; }

        /// <summary>
        /// Update the invitee and request the form to reset
        /// </summary>
        private async Task UpdateInviteeAsync()
        {
            await WeddingService.UpdateInviteeAsync();
            await ResetForm.InvokeAsync();
        }
    }
}
