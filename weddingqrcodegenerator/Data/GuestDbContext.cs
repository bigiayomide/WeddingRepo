using Microsoft.EntityFrameworkCore;
namespace weddingqrcodegenerator.Data
{
    public class GuestDbContext : DbContext
    {
        public GuestDbContext(DbContextOptions<GuestDbContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Guest> Guest => Set<Models.Guest>();
    }
}