using Microsoft.AspNetCore.Components;

namespace AllisonOwenWedding.Shared
{
    public partial class Dialog
    {
        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public bool ShowDialog { get; set; } = false;

        [Parameter]
        public bool ShowOkayButton { get; set; } = false;

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Show the dialog.
        /// </summary>
        public void Show()
        {
            ShowDialog = true;
            StateHasChanged();
        }

        /// <summary>
        /// Close the dialog.
        /// </summary>
        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }
    }
}
