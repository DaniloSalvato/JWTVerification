using JWTAplication.Models;
using System.Threading.Tasks;

namespace JWTAplication.Services.Interface
{
    public interface IUserService
    {
        Task<UserModel> GetUser(string nome, string password);
    }
}
