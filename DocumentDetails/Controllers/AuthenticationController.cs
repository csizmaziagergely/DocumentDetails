using DocumentDetails.DTOs;
using DocumentDetails.Entities;
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

            if (user == null)
            {
                return Unauthorized("User does not exist");
            }

            bool isCorrectPassword = _passwordHasher.VerifyPassword(loginRequest.Password, user.HashedPassword);

            if (!isCorrectPassword)
            {
                return Unauthorized("Incorrect password");
            }

            string accessToken = await _authenticator.GetAccessToken(user);

            return Ok(accessToken);
        }
    }
}
