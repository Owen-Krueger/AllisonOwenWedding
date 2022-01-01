namespace AllisonOwenWedding.Models
{
    /// <summary>
    /// Update information for the RSVP form.
    /// </summary>
    public class RsvpInviteeUpdate2
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public RsvpInviteeUpdate2() { }

        /// <summary>
        /// Constructor setting properties based on invitee from database.
        /// </summary>
        public RsvpInviteeUpdate2(WeddingInvitee invitee)
        {
            WeddingInvitee = invitee;
        }

        /// <summary>
        /// The response in the 'Accepted' field.
        /// </summary>
        public AcceptedResponse RsvpResponse
        {
            get
            {
                if (WeddingInvitee.Completed)
                {
                    return WeddingInvitee.Accepted ? AcceptedResponse.Accept : AcceptedResponse.Reject;
                }
                else
                {
                    return AcceptedResponse.Default;
                }
            }

         }

        public WeddingInvitee WeddingInvitee { get; set; } = new();

        /// <summary>
        /// The number of guests coming. 0 if not accepted.
        /// </summary>
        public int GuestsComing 
        { 
            get
            {
                return RsvpResponse == AcceptedResponse.Accept ? _guestsComing : 0;
            }
            set 
            {
                _guestsComing = value;
            } 
        }

        /// <summary>
        /// The internal number of guests coming value.
        /// </summary>
        private int _guestsComing;

        /// <summary>
        /// Whether or not the user accepted the RSVP request.
        /// </summary>
        public bool Accepted
        {
            get
            {
                return RsvpResponse == AcceptedResponse.Accept;
            }
        }
    }
}
