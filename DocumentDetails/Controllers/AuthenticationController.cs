using DocumentDetails.DTOs;
using DocumentDetails.Entities;
using DocumentDetails.Enums;
using DocumentDetails.Services;
using DocumentDetails.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BpRobotics.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : Controller
    {

        private readonly UserService _userService;
        private readonly BCryptPasswordHasher _passwordHasher;
        private readonly Authenticator _authenticator;

        public AuthenticationController(UserService userService, BCryptPasswordHasher passwordHasher, Authenticator authenticator)
        {
            _userService = userService;
            _passwordHasher = passwordHasher;
            _authenticator = authenticator;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserCreateLogin loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            User user = await _userService.GetByUserName(loginRequest.UserName);

            string ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();



            if (user == null)
            {
                await _userService.NewUserLog(loginRequest, ipAddress, UserLogType.UnsuccessfulLogin);
                return Unauthorized("User does not exist");
            }

            if (!user.IsActive)
            {
                await _userService.NewUserLog(loginRequest, ipAddress, UserLogType.UnsuccessfulDeactivatedLogin);
                return Unauthorized("User is deactivated");
            }

            bool isCorrectPassword = _passwordHasher.VerifyPassword(loginRequest.Password, user.HashedPassword);

            if (!isCorrectPassword)
            {
                await _userService.NewUserLog(loginRequest, ipAddress, UserLogType.UnsuccessfulLogin);
                return Unauthorized("Incorrect password");
            }
            await _userService.NewUserLog(loginRequest, ipAddress, UserLogType.SuccessfulLogin);

            AuthenticatedUserResponse accessToken = await _authenticator.GetAccessToken(user);

            return Ok(accessToken);
        }
    }
}
