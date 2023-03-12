using JWTAplication.Models;
using JWTAplication.Repositories.Interface;
using JWTAplication.Services.Interface;
using System.Threading.Tasks;

namespace JWTAplication.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserModel> GetUser(string nome, string password) => await _userRepository.GetUser(nome, password);
    }
}
