using JWTAplication.Models;
using JWTAplication.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JWTAplication.Controllers
{
    public class TokenController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public TokenController(IUserService userService,ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("api/login")]
        [AllowAnonymous]

        public async Task<ActionResult<dynamic>> Autenticar([FromBody] LoginModel model) 
        {
            var user = await _userService.GetUser(model.Nome, model.Password);

            if (user == null)
            {
                return NotFound(new { message = "Usuário ou senha inválidos" });
            }

            var token = await _tokenService.GenerateToken(user);

            user.Password = "";

            return new
            {
                user = user,
                token = token,  
            };
        }
    }
}
