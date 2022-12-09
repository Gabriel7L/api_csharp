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
            return Ok(await dbContext.Worklist.ToListAsync());

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
            
            return Ok(worklist.Id);
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> updateWorklist([FromRoute] int id, AddWorklistRequest updateWorklist)
        {
            var worklist = await dbContext.Worklist.FindAsync(id);
            if (worklist != null)
            {
                worklist.Sala = updateWorklist.Sala;
                worklist.Exame = updateWorklist.Exame;
                await dbContext.SaveChangesAsync();
                return Ok(worklist.Id);

            }
            return NotFound();
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> deleteWorklist([FromRoute] int id){
            var worklist = await dbContext.Worklist.FindAsync(id);
            if(worklist != null){
                dbContext.Remove(worklist);
                await dbContext.SaveChangesAsync();
                return Ok("Deletado com sucesso");
            }
            return NotFound();
        }
    }
}
