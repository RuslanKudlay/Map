using DAL.Entities;

namespace BAL.Services.UserService
{
    public interface IUserService
    {
        Task<bool> CreateUser(User user);
        Task<bool> CompareUserByLoginAndPassword(User user);
        Task<Guid> GetUserByLoginAndPassword(string login, string password);
    }
}
