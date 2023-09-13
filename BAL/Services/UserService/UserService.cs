using BAL.Models;
using DAL.AppcationDbContext;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IApplicationDbContext _dbContext;
        public UserService(IApplicationDbContext dbContext)
        {
                _dbContext = dbContext;
        }

        public async Task<bool> CompareUserByLoginAndPassword(User user)
        {
            var userCheck = await _dbContext.Users.AnyAsync(us => us.Login == user.Login && us.Password == user.Password);

            if (userCheck == true)
            {
                return true;
            }
            return false;

        }

        public async Task<bool> CreateUser(User user)
        {
            var isExicts = await CheckLoginUser(user);
            if (user != null && isExicts == false)
            {
                var userToDb = new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    FatherName = user.FatherName,
                    Position = user.Position,
                    Login = user.Login,
                    Password = user.Password,
                    LastLocationUpdate = DateTime.UtcNow 
                };
                _dbContext.Users.Add(userToDb);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Guid> GetUserByLoginAndPassword(string login, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(us => us.Login == login && us.Password == password);
            return user.Id;
        }

        private async Task<bool> CheckLoginUser(User user)
        {
            return await _dbContext.Users.AnyAsync(us => us.Login == user.Login);
        }
    }
}
