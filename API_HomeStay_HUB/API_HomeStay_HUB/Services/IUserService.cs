using API_HomeStay_HUB.DTOs;
using API_HomeStay_HUB.Model;

namespace API_HomeStay_HUB.Services
{
    public interface IUserService
    {
        Task<bool> addUser(User user, int typeUser);
        Task<bool> changePassWord(string userID, string passOld, string passNew);
        Task<bool> updateProfile(User user);
        Task<bool> lockUser(User user);
        Task<LoginResponseDTO?> loginUser(string username, string password);
        //private string GenerateJwtToken(User user);
    }
}
