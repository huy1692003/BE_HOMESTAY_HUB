using API_HomeStay_HUB.DTOs;
using API_HomeStay_HUB.Model;
using API_HomeStay_HUB.Repositories.Intefaces;
using API_HomeStay_HUB.Services.Interface;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_HomeStay_HUB.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IConfiguration _configuration;
        public UserService(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }
        public Task<bool> addUser(User user, int typeUser)
        {
            return _userRepository.addUser(user, typeUser);
        }
        public Task<bool> changePassWord(string userID, string passOld, string passNew)
        {
            return _userRepository.changePassWord(userID, passOld, passNew);
        }
        public Task<bool> updateProfile(User user)
        {
            return _userRepository.updateProfile(user);
        }
        public Task<bool> lockUser(User user)
        {
            return _userRepository.lockUser(user);
        }
        public async Task<LoginResponseDTO?> loginUser(string username, string password)
        {
            var userLogin = await _userRepository.loginUser(username, password);
            if (userLogin != null)
            {
                var tokenString = GenerateJwtToken(userLogin);
                return new LoginResponseDTO { UserName = userLogin.Username, FullName = userLogin.FullName, Token = tokenString };

            }
            return null;

        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
