using System.ComponentModel.DataAnnotations;

namespace AllisonOwenWedding.DataAccess
{
    /// <summary>
    /// The identifier information for an invitee.
    /// </summary>
    public class InviteeIdentifier
    {
        /// <summary>
        /// The unique identifier for this record.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The identifier for the wedding invitee.
        /// </summary>
        public int InviteeId { get; set; }

        /// <summary>
        /// The full name string of the invitee.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// The wedding invitee.
        /// </summary>
        public WeddingInvitee WeddingInvitee { get; set; }
    }
}
