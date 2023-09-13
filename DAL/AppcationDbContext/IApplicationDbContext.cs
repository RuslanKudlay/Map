using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.AppcationDbContext
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<UserLocation> UserLocations { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
