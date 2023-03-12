using JWTAplication.Models;
using System.Threading.Tasks;

namespace JWTAplication.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<UserModel> GetUser(string nome, string password);
    }
}
