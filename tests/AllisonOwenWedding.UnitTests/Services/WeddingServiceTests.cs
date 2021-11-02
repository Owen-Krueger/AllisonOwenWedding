using AllisonOwenWedding.DataAccess;
using AllisonOwenWedding.Services;
using Microsoft.EntityFrameworkCore;
using Moq.AutoMock;
using NUnit.Framework;
using System.Threading.Tasks;

namespace AllisonOwenWedding.UnitTests.Services
{
    public class WeddingServiceTests
    {
        [TestCase("John Doe")]
        [TestCase("JOHN DOE")]
        [TestCase("john doe")]
        [TestCase("jOhN dOe")]
        public void FindInvitee_FullNameMatches_InviteeReturned(string fullName)
        {
            var mock = new AutoMocker();
            WeddingInvitee invitee = new()
            {
                Id = 1,
                Completed = true,
                Accepted = true,
                GuestsExpected = 2,
                GuestsComing = 2
            };
            InviteeIdentifier inviteeIdentifier = new()
            {
                Id = 1,
                UserId = 1,
                FullName = "JOHN DOE"
            };
            var options = new DbContextOptionsBuilder<WeddingEntities>()
                .UseInMemoryDatabase(databaseName: $"{nameof(FindInvitee_FullNameMatches_InviteeReturned)}-{fullName}")
                .Options;
            var dataContext = new WeddingEntities(options);
            dataContext.AddRange(invitee, inviteeIdentifier);
            dataContext.SaveChanges();
            mock.Use<IWeddingEntities>(dataContext);
            var weddingService = mock.CreateInstance<WeddingService>();
            var result = weddingService.FindInvitee(fullName);
            Assert.AreEqual(invitee, result);
        }

        [Test]
        public void FindInvitee_NameNotFound_NullReturned()
        {
            var mock = new AutoMocker();
            WeddingInvitee invitee = new()
            {
                Id = 1
            };
            InviteeIdentifier inviteeIdentifier = new()
            {
                Id = 1,
                UserId = 1,
                FullName = "JOHN DOE"
            };
            var options = new DbContextOptionsBuilder<WeddingEntities>()
                .UseInMemoryDatabase(databaseName: $"{nameof(FindInvitee_NameNotFound_NullReturned)}")
                .Options;
            var dataContext = new WeddingEntities(options);
            dataContext.AddRange(invitee, inviteeIdentifier);
            dataContext.SaveChanges();
            mock.Use<IWeddingEntities>(dataContext);
            var weddingService = mock.CreateInstance<WeddingService>();
            var result = weddingService.FindInvitee("Joe Doe");
            Assert.IsNull(result);
        }

        [Test]
        public async Task UpdateInviteeAsync_InviteeUpdated_ChangesSaved()
        {
            var mock = new AutoMocker();
            WeddingInvitee invitee = new()
            {
                Id = 1,
                Completed = true,
                Accepted = false,
                GuestsComing = 2
            };
            var options = new DbContextOptionsBuilder<WeddingEntities>()
                .UseInMemoryDatabase(databaseName: $"{nameof(UpdateInviteeAsync_InviteeUpdated_ChangesSaved)}")
                .Options;
            var dataContext = new WeddingEntities(options);
            dataContext.Add(invitee);
            dataContext.SaveChanges();
            mock.Use<IWeddingEntities>(dataContext);
            var weddingService = mock.CreateInstance<WeddingService>();
            invitee.Accepted = true;
            invitee.GuestsComing = 0;
            await weddingService.UpdateInviteeAsync();
            var updatedInvitee = await dataContext.WeddingInvitees.FirstAsync();
            Assert.IsTrue(updatedInvitee.Accepted);
            Assert.AreEqual(0, updatedInvitee.GuestsComing);
        }
    }
}
