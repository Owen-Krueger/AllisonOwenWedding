using Microsoft.AspNetCore.Components;

namespace AllisonOwenWedding.Pages
{
    public partial class Index
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        private void NavigateToRsvpPage()
        {
            NavigationManager.NavigateTo("rsvp");
        }
    }
}
