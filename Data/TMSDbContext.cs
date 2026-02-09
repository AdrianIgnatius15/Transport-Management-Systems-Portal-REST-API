using Microsoft.EntityFrameworkCore;
using Transport_Management_Systems_Portal_REST_API.Models;

namespace Transport_Management_Systems_Portal_REST_API.Data
{
    public class TMSDbContext : DbContext
    {
        public TMSDbContext(DbContextOptions<TMSDbContext> dbContext) : base(dbContext)
        {

        }

        public DbSet<User> Users { get; set; } = null!;
    }
}