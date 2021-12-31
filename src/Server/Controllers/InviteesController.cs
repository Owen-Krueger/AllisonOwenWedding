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
        public WeddingInvitee Get([Required(AllowEmptyStrings = false)]string name)
        {
            return _weddingService.FindInvitee(name);
        }

        [HttpPut]
        public async Task<bool> UpdateInvitee(RsvpInviteeUpdate2 request)
        {
            string fullName = request.WeddingInvitee.InviteeIdentifiers[0].FullName;
            _logger.LogInformation("Updating '{FullName}': Accepted: {Accepted} Guests: {Guests}", fullName, request.Accepted, request.WeddingInvitee.GuestsComing);

            request.WeddingInvitee.Completed = true;
            request.WeddingInvitee.Accepted = request.Accepted;
            request.WeddingInvitee.GuestsComing = request.GuestsComing;

            var databasePolicy = Policy.HandleResult<bool>(x => !x).RetryAsync(3);
            bool databaseResult = await databasePolicy.ExecuteAsync(() => _weddingService.UpdateInviteeAsync());

            bool emailResult = _emailService.SendUpdateEmail(fullName, request.Accepted, request.WeddingInvitee.GuestsComing);

            return databaseResult && emailResult;
            //if (!databaseResult && !emailResult)
            //{
            //    _logger.LogError("Failed to update database and send email update.");
            //    ErrorDialog.Show();
            //}
            //else
            //{
            //    await ResetForm.InvokeAsync();
            //}
        }
    }
}