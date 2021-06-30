using System.ComponentModel.DataAnnotations;

namespace AllisonOwenWedding.Models
{
    /// <summary>
    /// For searching for an invitee
    /// </summary>
    public class RsvpSearchRequest
    {
        /// <summary>
        /// The full name string of the desired invitee
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string FullName { get; set; }
    }
}
