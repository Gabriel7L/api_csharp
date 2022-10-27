using api_csharp.Data;
using api_csharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Npgsql;
using System.Reflection.PortableExecutable;

namespace api_csharp.Controllers
{
    [ApiController]
    [Route("api/worklist")]
    public class WorklistController : Controller
    {
        private readonly DbContextAPI dbContext;
        public WorklistController(DbContextAPI dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetWorklist()
        {
            var conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;Database=teste;User Id=postgres;Password=mg#c0d3@Dsv;");
            conn.Open();
            var teste1 = new NpgsqlCommand("SELECT id,modelo,placa,nome_veiculo FROM huayteste", conn);
            var result = await teste1.ExecuteReaderAsync();

      
            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> AddWorklist(AddWorklistRequest addRequest)
        {
            var worklist = new Worklist()
            {
               Exame = addRequest.Exame,
               Sala = addRequest.Sala,                
            };
            await dbContext.Worklist.AddAsync(worklist);
            await dbContext.SaveChangesAsync();
            
            return Ok(worklist);
        }
    }
}
