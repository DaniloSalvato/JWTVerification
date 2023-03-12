using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JWTAplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("api/anonimo")]
        [AllowAnonymous]
        public async Task<string> Anonimous() => "Anonimo";

        [HttpPost]
        [Route("api/funcionario")]
        [Authorize(Roles = "funcionario, gerente")]
        public async Task<string> Employee() => "funcionario";

        [HttpPost]
        [Route("api/gerente")]
        [Authorize(Roles = "gerente")]
        public async Task<string> Manager() => "gerente";

    }
}
