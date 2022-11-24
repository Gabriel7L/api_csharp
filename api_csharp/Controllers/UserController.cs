using api_csharp.Data;
using api_csharp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_csharp.Controllers
{
  [Route("api/users")]
  [ApiController]
  public class UserController : Controller
  {
    private readonly DbContextAPI dbContext;
    public UserController(DbContextAPI dbcontext)
    {
      this.dbContext = dbcontext;
    }
    [HttpPost]
    public async Task<IActionResult> AddUser(User addRequest)
    {
      var user = new User()
      {
        Nome = addRequest.Nome,
        Email = addRequest.Email,
        Password = BCrypt.Net.BCrypt.HashPassword(addRequest.Password),
        Perfil = addRequest.Perfil,
      };
      await dbContext.AddAsync(user);
      await dbContext.SaveChangesAsync();
      return Ok(user.Id);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> UpdateUser(int id, User updateRequest)
    {
      var user = await dbContext.User.FindAsync(id);
      if (user == null)
      {
        return NotFound();
      }
      user.Nome = updateRequest.Nome;
      user.Email = updateRequest.Email;
      var encriptPassword = BCrypt.Net.BCrypt.HashPassword(updateRequest.Password);
      bool checkPassword = false;
      if (updateRequest.Password != null && updateRequest.Password.Length >= 6)
      {
        checkPassword = BCrypt.Net.BCrypt.Verify(updateRequest.Password, user.Password);
      }
      if (!checkPassword && updateRequest.Password != null && updateRequest.Password.Length >= 6)
      {
        user.Password = encriptPassword;
      }
      user.Perfil = updateRequest.Perfil;
      await dbContext.SaveChangesAsync();
      return Ok(user.Id);
    }
  }
}
