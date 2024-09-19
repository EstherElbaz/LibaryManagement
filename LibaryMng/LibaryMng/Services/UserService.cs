using LibaryMng.Entities;
using LibaryMng.Repositories;

namespace LibaryMng.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository UserRepository)
        {
            _userRepository = UserRepository;
        }
        public async Task<User> getUser(string userName, string password)
        { 
            return await _userRepository.getUser(userName, password);
        }
   
    }
}

