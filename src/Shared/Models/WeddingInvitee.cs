using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllisonOwenWedding.Models
{
    /// <summary>
    /// The information for an invitee.
    /// </summary>
    [Table("Invitees")]
    public class WeddingInvitee
    {
        /// <summary>
        /// The unique identifier for this invitee.
        /// </summary>
        [Key]
        public int UserId { get; set; }

        /// <summary>
        /// Whether or not the invitee has completed the form.
        /// </summary>
        public bool Completed { get; set; }

        /// <summary>
        /// Whether or not the invitee accepted the invitation.
        /// </summary>
        public bool Accepted { get; set; }

        /// <summary>
        /// The number of guests we expect may come.
        /// </summary>
        public int GuestsExpected { get; set; }

        /// <summary>
        /// The number of guests coming with the invitee.
        /// </summary>
        public int GuestsComing { get; set; }

        /// <summary>
        /// The list of identifiers for this invitee.
        /// </summary>
        public List<InviteeIdentifier> InviteeIdentifiers { get; set; } = new();
    }
}
