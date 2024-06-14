using emedicine_api.Models;

namespace emedicine_api.Services
{
    public interface IUserService
    {
        Response Register(Users user);
        Response Login(LoginDTO user);
        Response ViewUser(int ID);
        Response UpdateProfile(Users user);
    }
}
