using AllisonOwenWedding.DataAccess;
using AllisonOwenWedding.Models;
using AllisonOwenWedding.Services;
using AllisonOwenWedding.Shared;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace AllisonOwenWedding.Compenents
{
    /// <summary>
    /// For interacting with the Rsvp Search Form
    /// </summary>
    public partial class RsvpSearch
    {
        [Inject]
        private IWeddingService WeddingService { get; set; }

        [Parameter]
        public EventCallback<WeddingInvitee> SetWeddingInvitee { get; set; }

        private RsvpSearchRequest Request { get; set; } = new RsvpSearchRequest();

        private Dialog InfoDialog { get; set; }

        /// <summary>
        /// Attempt to find the invitee
        /// </summary>
        private async Task OnSubmitAsync()
        {
            var invitee = WeddingService.FindInvitee(Request.FullName);

            if (invitee != null)
            {
                await SetWeddingInvitee.InvokeAsync(invitee);
            }
            else
            {
                InfoDialog.Show();
            }
        }
    }
}
