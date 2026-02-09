using Transport_Management_Systems_Portal_REST_API.DTOs;

namespace Transport_Management_Systems_Portal_REST_API.Controllers
{
    public class AuthenticationController : ControllerBase
    {
        public AuthenticationController()
        {

        }

        public IActionResult Login()
        {
            var userDto = new UserReadDto
            {
                Id = 1,
                Username = "testuser",
                Email = "testuser@example.com",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            return Ok(userDto);
        }
    }
}