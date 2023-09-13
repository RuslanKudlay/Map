using BAL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services.UserLocationService
{
    public interface IUserLocationService
    {
        Task CreatePoints(UserLocation userLocation, Guid userId);
        Task<List<Point>> GetAllPoints();
    }
}
