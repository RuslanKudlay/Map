using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.AppcationDbContext
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions opt) : base(opt)
        {
                
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserLocation> UserLocations { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync();
        }
    }
}
