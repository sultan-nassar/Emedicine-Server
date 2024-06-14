using emedicine_api.Models;

namespace emedicine_api.Repositories
{
    public interface IUserRepository
    {
        Response Register(Users user);
        Response Login(LoginDTO user);
        Response ViewUser(int ID);
        Response UpdateProfile(Users user);
    }

}
