using BpRobotics.Core.Extensions;
using DocumentDetails.DTOs;
using DocumentDetails.Entities;
using DocumentDetails.Enums;
using DocumentDetails.Repositories;

namespace DocumentDetails.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private const int UNSUCCESFULLOGINLIMIT = 5;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserView> NewUser(UserCreateLogin newUser)
        {
            var userEntity = newUser.ToUserEntity();
            await _userRepository.Add(userEntity);
            return userEntity.ToUserView();
        }

        public async Task NewUserLog(UserCreateLogin loginRequest, string ipAdress, UserLogType userLogType)
        {
            User? userEntity = await _userRepository.GetByUserName(loginRequest.UserName);


            UserLog userLog = new UserLog()
            {
                UserId = userEntity?.Id,
                HappenedAt = DateTime.Now,
                UsernameAttempt = loginRequest.UserName,
                IPAddress = ipAdress,
                Type = userLogType
            };
            await _userRepository.AddLog(userLog);

            // Deactivate user if limit reached
            await DeactivateIfLimitReach(userEntity, userLog);
        }

        private async Task DeactivateIfLimitReach(User? userEntity, UserLog userLog)
        {
            if (userEntity != null &&
                            userEntity.Logs
                            .Count(l => l.Type == UserLogType.UnsuccessfulLogin) == UNSUCCESFULLOGINLIMIT - 1 &&
                            userLog.Type == UserLogType.UnsuccessfulLogin)
            {
                UserLog newUserLog = new UserLog()
                {
                    UserId = userLog.UserId,
                    HappenedAt = userLog.HappenedAt,
                    UsernameAttempt = userLog.UsernameAttempt,
                    IPAddress = userLog.IPAddress,
                    Type = UserLogType.Deactivation
                };
                await _userRepository.AddLog(newUserLog);
                await DeactivateUser(userEntity);
            };
        }

        private async Task DeactivateUser(User user)
        {
            user.IsActive = false;
            await _userRepository.DeactivateUser(user);
        }

        public async Task<UserView> GetById(int userId) => (await _userRepository.GetById(userId)).ToUserView();
        public async Task<User> GetByUserName(string userName) => (await _userRepository.GetByUserName(userName));



    }
}
