using AllisonOwenWedding.DataAccess;
using System.Threading.Tasks;

namespace AllisonOwenWedding.Services
{
    /// <summary>
    /// For doing wedding operations.
    /// </summary>
    public interface IWeddingService
    {
        /// <summary>
        /// Updates the entities
        /// </summary>
        Task UpdateInviteeAsync();

        /// <summary>
        /// Attempt to find the wedding invitee based on a name string
        /// </summary>
        WeddingInvitee FindInvitee(string fullName);
    }
}
