using AllisonOwenWedding.DataAccess;

namespace AllisonOwenWedding.Pages
{
    /// <summary>
    /// For interacting with the Rsvp page
    /// </summary>
    public partial class Rsvp
    {
        private WeddingInvitee WeddingInvitee { get; set; } = null;

        /// <summary>
        /// Sets the invitee
        /// </summary>
        private void SetWeddingInvitee(WeddingInvitee weddingInvitee)
        {
            WeddingInvitee = weddingInvitee;
            StateHasChanged();
        }

        /// <summary>
        /// Resets the request form
        /// </summary>
        private void ResetForm()
        {
            WeddingInvitee = null;
            StateHasChanged();
        }
    }
}
