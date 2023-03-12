using JWTAplication.Models;
using System.Threading.Tasks;

namespace JWTAplication.Services.Interface
{
    public interface ITokenService
    {
        Task<string> GenerateToken(UserModel user);
    }
}
