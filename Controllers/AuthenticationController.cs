using Microsoft.AspNetCore.Mvc;
using Transport_Management_Systems_Portal_REST_API.Data.Interfaces;
using Transport_Management_Systems_Portal_REST_API.DTOs;
using Transport_Management_Systems_Portal_REST_API.DTOs.Request_Models;
using Transport_Management_Systems_Portal_REST_API.Models;
using Transport_Management_Systems_Portal_REST_API.Utilities;

namespace Transport_Management_Systems_Portal_REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationRepo _authenticationRepo;

        public AuthenticationController(IAuthenticationRepo authenticationRepo)
        {
            _authenticationRepo = authenticationRepo;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserReadDto>> Login(LoginRequest loginRequest)
        {
            var searchedUser = await _authenticationRepo.GetUserAsync(loginRequest.Email);

            if (searchedUser == null || !PasswordHashingUtility.VerifyPassword(loginRequest.Password, searchedUser.Password))
            {
                return BadRequest($"--> Login failed due to invalid credentials or account do not exists!");
            }
            else
            {
                var userReadDto = MapperUtility.Map<User, UserReadDto>(searchedUser);

                return Ok(userReadDto);
            }

        }

        [HttpPost("register", Name = "Register")]
        public async Task<ActionResult<UserReadDto>> Register(RegisterRequest registerRequest)
        {
            var user = new User
            {
                Email = registerRequest.Email,
                Password = PasswordHashingUtility.HashPassword(registerRequest.Password)
            };

            await _authenticationRepo.CreateUserAsync(user);
            await _authenticationRepo.SaveChangesAsync();

            var userReadDto = MapperUtility.Map<User, UserReadDto>(user);
            return CreatedAtRoute(nameof(Register), userReadDto);
        }
    }
}