using Dapper;
using JWTAplication.Models;
using JWTAplication.Repositories.Interface;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAplication.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<UserModel> GetUser(string nome, string password)
        {
            using (var conn = new SqlConnection(_configuration.GetSection("ConnectionStrings").GetSection("STRING_CONECTION").Value))
            {
                var sql = $@" SELECT [Id],
                                     [Name],
                                     [Password],
                                     [Role]
                              FROM Registro WITH (NOLOCK) 
                              WHERE Name = @nome AND Password = @Password";
                var result = await conn.QueryAsync<UserModel>(sql.ToString(), new { nome, password });
                return result.FirstOrDefault(x => x.Name.ToLower() == nome.ToLower() && x.Password == password);
            }
        }
    }
}
