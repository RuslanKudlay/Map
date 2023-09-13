using BAL.Models;
using DAL.Entities;

namespace BAL.Services.UserLocationService
{
    public interface IUserLocationService
    {
        Task CreatePoints(UserLocation userLocation, Guid userId);
        Task<List<Point>> GetAllPoints();
    }
}
