
using DocumentDetails.DTOs;
using DocumentDetails.Entities;

namespace BpRobotics.Core.Extensions
{
    public static class UserExtensions
    {
        public static User ToUserEntity(this UserCreate userCreateData)
        {
            return new User
            {
                UserName = userCreateData.UserName,
                HashedPassword = userCreateData.Password,
                IsActive = true
            };
        }

        public static UserView ToUserView(this User user)
        {
            return new UserView
            {
                Id = user.Id,
                UserName = user.UserName,
            };
        }
    }
}

