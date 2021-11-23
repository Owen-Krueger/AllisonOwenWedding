namespace AllisonOwenWedding.Models
{
    /// <summary>
    /// The various responses to an RSVP request.
    /// </summary>
    public enum AcceptedResponse
    {
        /// <summary>
        /// Default request. Should not be set by the user.
        /// </summary>
        Default = -1,

        /// <summary>
        /// User accepted the RSVP.
        /// </summary>
        Accept = 0,

        /// <summary>
        /// User rejected the RSVP.
        /// </summary>
        Reject = 1
    }
}
