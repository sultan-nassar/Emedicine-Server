using emedicine_api.Models;
using emedicine_api.Repositories;

namespace emedicine_api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Response Register(Users user)
        {
            return _userRepository.Register(user);
        }

        public Response Login(LoginDTO user)
        {
            return _userRepository.Login(user);
        }

        public Response ViewUser(int ID)
        {
            return _userRepository.ViewUser(ID);
        }

        public Response UpdateProfile(Users user)
        {
            return _userRepository.UpdateProfile(user);
        }
    }

}