using Microsoft.EntityFrameworkCore;
using Transport_Management_Systems_Portal_REST_API.Data.Interfaces;
using Transport_Management_Systems_Portal_REST_API.Models;

namespace Transport_Management_Systems_Portal_REST_API.Data.Repositories
{
    public class AuthenticationRepo : IAuthenticationRepo
    {
        private readonly TMSDbContext _dbContext;

        public AuthenticationRepo(TMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
        }

        public async Task<User?> GetUserAsync(string email)
        {
            var searchedResult = await _dbContext.Users.FirstOrDefaultAsync(user => user.Email == email);

            return searchedResult;
        }

        public async Task<bool> SaveChangesAsync()
            => await _dbContext.SaveChangesAsync() >= 0;
    }
}