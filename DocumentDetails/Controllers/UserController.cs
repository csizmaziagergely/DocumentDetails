using DocumentDetails.DTOs;
using DocumentDetails.Services;
using DocumentDetails.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DocumentDetails.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly BCryptPasswordHasher _hasher;

        public UserController(UserService userService, BCryptPasswordHasher hasher)
        {
            _userService = userService;
            _hasher = hasher;
        }

        [HttpPost]
        public async Task<ActionResult<UserView>> NewUser(UserCreateLogin newUser)
        {
            newUser.Password = _hasher.HashPassword(newUser.Password);
            try
            {
                var createdUser = await _userService.NewUser(newUser);
                return CreatedAtRoute("GetUserById", new { userId = createdUser.Id }, createdUser);
            }
            catch (DbUpdateException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{userId}", Name = "GetUserById")]
        public async Task<ActionResult<UserView>> GetUserById(int userId)
        {
            try
            {
                return await _userService.GetById(userId);
            }
            catch (InvalidOperationException)
            {
                return NotFound($"User with ID:{userId} not found.");
            }
        }
    }
}
