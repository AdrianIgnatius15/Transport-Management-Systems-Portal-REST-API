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
            var searchedUser = await _authenticationRepo.GetUserAsync(loginRequest.Email, loginRequest.Password);

            if (searchedUser == null)
            {
                return BadRequest($"--> Login failed due to invalid credentials or account do not exists!");
            }
            else
            {
                var userReadDto = MapperUtility.Map<User, UserReadDto>(searchedUser);

                return Ok(userReadDto);
            }

        }
    }
}