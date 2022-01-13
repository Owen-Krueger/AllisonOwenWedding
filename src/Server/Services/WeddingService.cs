using AllisonOwenWedding.DataAccess;
using AllisonOwenWedding.Models;
using Microsoft.EntityFrameworkCore;

namespace AllisonOwenWedding.Services
{
    /// <inheritdoc />
    public class WeddingService : IWeddingService
    {
        private readonly ILogger<WeddingService> _logger;
        private readonly IWeddingEntities _weddingEntities;

        /// <summary>
        /// Constructor
        /// </summary>
        public WeddingService(ILogger<WeddingService> logger, IWeddingEntities weddingEntities)
        {
            _logger = logger;
            _weddingEntities = weddingEntities;
        }

        /// <inheritdoc />
        public WeddingInvitee FindInvitee(string fullName)
        {
            _logger.LogInformation("Attempting to find '{FullName}'", fullName);

            var invitee = _weddingEntities.WeddingInvitees
                .Where(x => x.InviteeIdentifiers
                    .Any(y =>
                        y.FullName.Equals(fullName.ToUpper())
                    )
                )
                .Include(x => x.InviteeIdentifiers)
                .FirstOrDefault();

            if (invitee != null)
            {
                invitee.FullName = fullName;
            }

            return invitee;
        }

        /// <inheritdoc />
        public async Task<bool> UpdateInviteeAsync()
        {
            int modifiedCount = await _weddingEntities.SaveChangesAsync();
            if (modifiedCount != 1)
            {
                _logger.LogError("Expected 1 modified record. {ModifiedCount} modified.", modifiedCount);
            }

            return modifiedCount == 1;
        }
    }
}
