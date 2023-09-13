using BAL.Models;
using DAL.AppcationDbContext;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BAL.Services.UserLocationService
{
    public class UserLocationService : IUserLocationService
    {
        private readonly IApplicationDbContext _dbContext;
        public UserLocationService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreatePoints(UserLocation userLocation, Guid userId)
        {
            var locationUser = new UserLocation
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Latitude = userLocation.Latitude,
                Longitude = userLocation.Longitude,
                TimeStamp = DateTime.UtcNow
            };
            _dbContext.UserLocations.Add(locationUser);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Point>> GetAllPoints()
        {
            var users = await _dbContext.Users.AsNoTracking().Include(loc => loc.UserLocations).ToListAsync();

            var points = users.Select(p => new Point
            {
                FirstName = p.FirstName,
                LastName = p.LastName,
                LastModified = p.UserLocations?.OrderByDescending(d => d.TimeStamp).FirstOrDefault()?.TimeStamp != null
                    ? p.UserLocations?.OrderByDescending(d => d.TimeStamp).FirstOrDefault()?.TimeStamp.ToString("dd.MM.yy HH:mm:ss") : string.Empty,
                Latitute = p.UserLocations?.OrderByDescending(d => d.TimeStamp).FirstOrDefault()?.Latitude,
                Longitude = p.UserLocations?.OrderByDescending(d => d.TimeStamp).FirstOrDefault()?.Longitude
            }).ToList();

            return points;
        }
    }
}
