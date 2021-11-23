using AllisonOwenWedding.DataAccess;
using AllisonOwenWedding.Models;
using NUnit.Framework;

namespace AllisonOwenWedding.UnitTests.Models
{
    public class RsvpInviteeUpdateTests
    {
        [Test]
        public void RsvpInviteeUpdate_AcceptedResponse_ExpectedProperties()
        {
            int guestsComing = 14;
            RsvpInviteeUpdate model = new()
            {
                RsvpResponse = AcceptedResponse.Accept,
                GuestsComing = guestsComing
            };

            Assert.IsTrue(model.Accepted);
            Assert.AreEqual(guestsComing, model.GuestsComing);
        }

        [Test]
        public void RsvpInviteeUpdate_RejectedResponse_ExpectedProperties()
        {
            RsvpInviteeUpdate model = new()
            {
                RsvpResponse = AcceptedResponse.Reject,
                GuestsComing = 14
            };

            Assert.IsFalse(model.Accepted);
            Assert.AreEqual(0, model.GuestsComing);
        }

        [TestCase(true, AcceptedResponse.Accept)]
        [TestCase(false, AcceptedResponse.Reject)]
        public void RsvpInviteeUpdate_InviteeCompleted_RsvpResponseSet(bool accepted, AcceptedResponse expectedAcceptedResponse)
        {
            WeddingInvitee invitee = new()
            {
                Completed = true,
                Accepted = accepted
            };
            RsvpInviteeUpdate model = new(invitee);

            Assert.AreEqual(expectedAcceptedResponse, model.RsvpResponse);
        }

        [Test]
        public void RsvpInviteeUpdate_InviteeNotCompleted_DefaultRsvpResponse()
        {
            WeddingInvitee invitee = new()
            {
                Completed = false,
                Accepted = true
            };
            RsvpInviteeUpdate model = new(invitee);

            Assert.AreEqual(AcceptedResponse.Default, model.RsvpResponse);
        }
    }
}
