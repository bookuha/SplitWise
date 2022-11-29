using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SplitVeryWise.Application.Contracts.DTOs.User;
using SplitVeryWise.Domain.Abstractions;

namespace SplitVeryWise.Web.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetUsers()
        {
            return Ok(await _userManager.GetUsers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetUserById(int id)
        {
            return Ok(await _userManager.GetUserById(id));
        }
        

        [HttpPost("/register")] // Yes, I know

        public async Task<ActionResult<UserResponse>> Register([FromBody] UserRegisterRequest registerRequest)
        {
            var createdUser = await _userManager.Register(registerRequest);
            return CreatedAtAction(nameof(GetUserById), new {id = createdUser.Id}, createdUser);
        }

        [HttpPost("/login")] // Not RESTful
        public async Task<ActionResult<UserResponse>> Login([FromBody] UserLoginRequest loginRequest) // Make it return JWT
        {
            return Ok(await _userManager.Login(loginRequest));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserResponse>> UpdateUser(int id, [FromBody] UserUpdateRequest updateRequest) // Todo: From Route for id?
        {
            var updatedUser = await _userManager.UpdateUser(id, updateRequest);
            return CreatedAtAction(nameof(GetUserById), new { id = updatedUser.Id }, updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserResponse>> DeleteUser(int id)
        {
            var deletedUser = await _userManager.DeleteUser(id);
            return Ok(deletedUser);
        }
    }
}
