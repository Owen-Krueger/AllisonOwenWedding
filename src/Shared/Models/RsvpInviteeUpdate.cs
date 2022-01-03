namespace AllisonOwenWedding.Models
{
    /// <summary>
    /// Update information for the RSVP form.
    /// </summary>
    public class RsvpInviteeUpdate
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public RsvpInviteeUpdate() { }

        /// <summary>
        /// Constructor setting properties based on invitee from database.
        /// </summary>
        public RsvpInviteeUpdate(WeddingInvitee invitee)
        {
            FullName = invitee.InviteeIdentifiers[0].FullName;

            if (invitee.Completed)
            {
                RsvpResponse = invitee.Accepted ? AcceptedResponse.Accept : AcceptedResponse.Reject;
            }
            else
            {
                RsvpResponse = AcceptedResponse.Default;
            }
        }

        /// <summary>
        /// Invitee full name to update.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// The response in the 'Accepted' field.
        /// </summary>
        public AcceptedResponse RsvpResponse { get; set; }

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
