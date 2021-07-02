using Microsoft.AspNetCore.Components;

namespace AllisonOwenWedding.Shared
{
    /// <summary>
    /// The main layout.
    /// </summary>
    public partial class MainLayout
    {
        [Inject]
        NavigationManager NavigationManager { get; set; }

        /// <summary>
        /// Get the class for a link based on the link.
        /// </summary>
        public string GetLinkClass(string link)
        {
            string relativeUrl = NavigationManager.ToBaseRelativePath(NavigationManager.Uri);
            return relativeUrl.Equals(link) ? "active-link" : string.Empty;
        }
    }
}
