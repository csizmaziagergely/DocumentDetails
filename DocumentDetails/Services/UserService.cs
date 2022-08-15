using BpRobotics.Core.Extensions;
using DocumentDetails.DTOs;
using DocumentDetails.Repositories;

namespace DocumentDetails.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserView> NewUser(UserCreate newUser)
        {
            var userEntity = newUser.ToUserEntity();
            await _userRepository.Add(userEntity);
            return userEntity.ToUserView();
        }

        public async Task<UserView> GetById(int userId) => (await _userRepository.GetById(userId)).ToUserView();

    }
}
