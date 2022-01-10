using AllisonOwenWedding.Models;
using AllisonOwenWedding.Services;
using Microsoft.AspNetCore.Mvc;
using Polly;
using System.ComponentModel.DataAnnotations;

namespace AllisonOwenWedding.Server.Controllers
{
    [ApiController]
    [Route("invitees")]
    public class InviteesController : ControllerBase
    {
        private readonly ILogger<InviteesController> _logger;
        private readonly IWeddingService _weddingService;
        private readonly IEmailService _emailService;

        public InviteesController(ILogger<InviteesController> logger, IWeddingService weddingService, IEmailService emailService)
        {
            _logger = logger;
            _weddingService = weddingService;
            _emailService = emailService;
        }

        [HttpGet("{name}")]
        public WeddingInvitee GetInvitee([Required(AllowEmptyStrings = false)] string name)
        {
            return(_weddingService.FindInvitee(name));

        }

        [HttpPut]
        public async Task<bool> UpdateInvitee(RsvpInviteeUpdate request)
        {
            string fullName = request.FullName;
            var invitee = _weddingService.FindInvitee(request.FullName);
            _logger.LogInformation("Updating '{FullName}': Accepted: {Accepted} Guests: {Guests}", fullName, request.Accepted, invitee.GuestsComing);

            invitee.Completed = true;
            invitee.Accepted = request.Accepted;
            invitee.GuestsComing = request.GuestsComing;

            var databasePolicy = Policy.HandleResult<bool>(x => !x).RetryAsync(3);
            bool databaseResult = await databasePolicy.ExecuteAsync(() => _weddingService.UpdateInviteeAsync());

            bool emailResult = _emailService.SendUpdateEmail(fullName, request.Accepted, invitee.GuestsComing);

            if (!databaseResult && !emailResult)
            {
                _logger.LogError("Failed to update database and send email update.");
                return false;
            }

            return true;
        }
    }
}