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
        /// Attempt to find the wedding invitee based on a name string.
        /// </summary>
        WeddingInvitee FindInvitee(string fullName);

        /// <summary>
        /// Updates the entities.
        /// </summary>
        /// <returns>Whether or not the insert was successful.</returns>
        Task<bool> UpdateInviteeAsync();
    }
}
