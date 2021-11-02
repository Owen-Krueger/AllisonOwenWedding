using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllisonOwenWedding.DataAccess
{
    /// <summary>
    /// The identifier information for an invitee.
    /// </summary>
    [Table("InviteeIdentifiers")]
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
        public int UserId { get; set; }

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
