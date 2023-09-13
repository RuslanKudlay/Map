﻿using DAL.Entities;
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

        public static UserLocation Map(LocationPoint locationPoint)
        {
            var userLocation = new UserLocation
            {
                Latitude = locationPoint.Latitude,
                Longitude = locationPoint.Longitude,
            };
            return userLocation;
        }

        public static UserInfoShort Map(User user)
        {
            List<UserLocation> userLocations = new List<UserLocation>();
            foreach (var item in user.UserLocations)
            {
                var userInfo = new UserInfoShort
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Latitute = item.Latitude,
                    Longitude = item.Longitude,
                    LastModified = item.TimeStamp
                };
                return userInfo;
            }
            return null;
        }
    }
}
