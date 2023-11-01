using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserServiceApi.Dto.Request;
using UserServiceApi.Service;

namespace UserServiceApi.Controllers
{
    [ApiController]
    [Route("userservice/api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserRegistrationRequestDto registrationModel)
        {
            try
            {
                var newUser = await _userService.CreateUserAsync(registrationModel);
                if (newUser == null)
                {
                    return Conflict("User Already Exists");
                }
                return new ObjectResult(new { userId = newUser.UserId }) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                // Handle registration errors
                return StatusCode(500, "An error occurred while registering the user.");
            }
        }

        [HttpGet("{userId}")]
        [Authorize]
        public async Task<IActionResult> GetUser(Guid userId)
        {
            var user = await _userService.GetUserAsync(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            return Ok(user);
        }
    }

}
