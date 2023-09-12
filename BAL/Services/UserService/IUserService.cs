using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services.UserService
{
    public interface IUserService
    {
        Task<bool> CreateUser(User user);
        Task<List<User>> GetAllUsers();
        Task<bool> CompareUserByLoginAndPassword(User user);
    }
}
