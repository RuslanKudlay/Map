using DAL.Entities;
using Map.Models;

namespace Map.Helper
{
    public static class UserHelper
    {
        public static User Map(LoginUserView loginUserView)
        {
            var user = new User
            {
                Login = loginUserView.Login,
                Password = loginUserView.Password
            };
            return user;
        }

        public static User Map(RegisterUserView loginUserView)
        {
            var user = new User
            {
                FirstName = loginUserView.FirstName,
                LastName = loginUserView.LastName,
                FatherName = loginUserView.FatherName,
                Position = loginUserView.Position,
                Login = loginUserView.Login,
                Password = loginUserView.Password
            };
            return user;
        }
    }
}
