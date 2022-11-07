using api_csharp.Data;
using api_csharp.Models;
using api_csharp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_csharp.Controllers
{
    [ApiController]
    [Route("api")]
    public class LoginController : ControllerBase
    {
        private readonly DbContextAPI dbContext;
        public LoginController(DbContextAPI dbcontext)
        {
            this.dbContext = dbcontext;
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
            var user = await dbContext.User.FirstOrDefaultAsync(x =>
                x.Email == model.Email &&
                x.Password == model.Password
            );

            if (user == null)
                return BadRequest(new { message = "Usuário ou senha inválidos" });
            var token = TokenService.GenerateToken(user);

            user.Password = "";
            return new
            {
                user = user,
                token = token,
            };
        }
    }
}
