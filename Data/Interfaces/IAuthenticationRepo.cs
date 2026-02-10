using Transport_Management_Systems_Portal_REST_API.Models;

namespace Transport_Management_Systems_Portal_REST_API.Data.Interfaces
{
    public interface IAuthenticationRepo
    {
        Task<bool> SaveChangesAsync();

        Task CreateUserAsync(User user);

        Task<User?> GetUserAsync(string email);
    }
}