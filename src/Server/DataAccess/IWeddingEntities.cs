using AllisonOwenWedding.Models;
using Microsoft.EntityFrameworkCore;

namespace AllisonOwenWedding.DataAccess
{
    /// <summary>
    /// Contains the data collections for the wedding.
    /// </summary>
    public interface IWeddingEntities
    {
        /// <summary>
        /// The collection of wedding invitees.
        /// </summary>
        DbSet<WeddingInvitee> WeddingInvitees { get; set; }

        /// <summary>
        /// The collection of invitee identifiers.
        /// </summary>
        DbSet<InviteeIdentifier> InviteeIdentifiers { get; set; }

        /// <summary>
        /// Commit any changes to the entities
        /// </summary>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
