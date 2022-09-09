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
        public ActionResult SendVerificationCode(PhoneNumberViewModel phoneNumber)
        {
            var successful = _userService.SendVerificationCode(phoneNumber);
            return Json(successful);
        }

        [HttpPost]
        [Route("verifyVerificationCode")]
        public ActionResult VerifyVerificationCode(VerifyViewModel verifyData)
        {
            var successful = _userService.VerifyVerificationCode(verifyData);
            return Json(successful);
        }

    }
}