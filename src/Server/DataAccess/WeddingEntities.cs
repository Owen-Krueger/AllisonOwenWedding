using AllisonOwenWedding.Models;
using Microsoft.EntityFrameworkCore;

namespace AllisonOwenWedding.DataAccess
{
    /// <inheritdoc />
    public class WeddingEntities : DbContext, IWeddingEntities
    {
        /// <inheritdoc />
        public DbSet<WeddingInvitee> WeddingInvitees { get; set; }

        /// <inheritdoc />
        public DbSet<InviteeIdentifier> InviteeIdentifiers { get; set; }

        /// <summary> 
        /// Constructor 
        /// </summary>
        public WeddingEntities(DbContextOptions<WeddingEntities> dbContextOptions) : base(dbContextOptions) { }

        /// <summary>
        /// Sets up the relationships for the data collections.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<WeddingInvitee>()
                .HasMany(x => x.InviteeIdentifiers)
                .WithOne(x => x.WeddingInvitee)
                .HasPrincipalKey(x => x.UserId)
                .HasForeignKey(x => x.UserId);
        }
    }
}
