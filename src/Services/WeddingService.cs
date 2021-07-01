using AllisonOwenWedding.DataAccess;
using System.Linq;
using System.Threading.Tasks;

namespace AllisonOwenWedding.Services
{
    /// <inheritdoc />
    public class WeddingService : IWeddingService
    {
        private readonly IWeddingEntities _weddingEntities;

        /// <summary>
        /// Constructor
        /// </summary>
        public WeddingService(IWeddingEntities weddingEntities)
        {
            _weddingEntities = weddingEntities;
        }

        /// <inheritdoc />
        public WeddingInvitee FindInvitee(string fullName)
        {
            var invitee = _weddingEntities.WeddingInvitees
                .Where(x => x.InviteeIdentifiers
                    .Any(y =>
                        y.FullName.Equals(fullName.ToUpper())
                    )
                ).FirstOrDefault();

            return invitee;
        }

        /// <inheritdoc />
        public async Task UpdateInviteeAsync()
        {
            await _weddingEntities.SaveChangesAsync();
        }
    }
}
