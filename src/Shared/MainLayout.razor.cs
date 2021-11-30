using Microsoft.AspNetCore.Components;
using System;
using System.Text;

namespace AllisonOwenWedding.Shared
{
    /// <summary>
    /// The main layout.
    /// </summary>
    public partial class MainLayout
    {
        [Inject]
        NavigationManager NavigationManager { get; set; }

        private static int DaysTillWedding()
        {
            DateTime weddingDate = new(2022, 2, 19);
            return (weddingDate - DateTime.Today).Days;
        }

        /// <summary>
        /// Get the class for a link based on the link.
        /// </summary>
        public string GetLinkClass(string link)
        {
            StringBuilder classBuilder = new();
            classBuilder.Append("nav-link");
            string relativeUrl = NavigationManager.ToBaseRelativePath(NavigationManager.Uri);
            classBuilder.Append(relativeUrl.Equals(link) ? " active-link" : string.Empty);
            return classBuilder.ToString();
        }
    }
}
