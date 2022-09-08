using EnsureThat;
using Microsoft.AspNetCore.Mvc;
using PatisserieAPI.Interfaces;
using PatisserieAPI.ViewModels;

namespace PatisserieAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;

        public UsersController(ILogger<UsersController> logger,
            IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost]
        [Route("sendVerificationCode")]
        public async Task<ActionResult> SendVerificationCode(string phoneNumber)
        {
            var twilioServiceId = await _userService.SendVerificationCode(phoneNumber);
            return Json(twilioServiceId);
        }
    }
}