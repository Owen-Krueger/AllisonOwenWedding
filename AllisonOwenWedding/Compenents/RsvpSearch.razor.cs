using AllisonOwenWedding.DataAccess;
using AllisonOwenWedding.Models;
using AllisonOwenWedding.Services;
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

        /// <summary>
        /// Attempt to find the invitee
        /// </summary>
        private async Task OnSubmitAsync()
        {
            await SetWeddingInvitee.InvokeAsync(WeddingService.FindInvitee(Request.FullName));
        }
    }
}
