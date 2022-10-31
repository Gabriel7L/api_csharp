using api_csharp.Data;
using api_csharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Text.Json.Nodes;
using DbContextAPI = api_csharp.Data.DbContextAPI;

namespace api_csharp.Controllers
{
        [ApiController]
        [Route("api/contatos")]
    public class ContatosController : Controller
    {
        private readonly DbContextAPI dbContext;
        public ContatosController(DbContextAPI dbcontext)
        {
            this.dbContext = dbcontext;
        }
        [HttpGet]
        public async Task<IActionResult> GetContatos()
        {
           return Ok(await dbContext.Contatos.ToListAsync());
           
        }
        [HttpPost]
        public async Task<IActionResult> AddContato(AddContatoRequest addRequest)
        {
            var contato = new Contato()
            {
                Endereco = addRequest.Endereco,
                Nome = addRequest.Nome,
                Telefone = addRequest.Telefone,
            };
            await dbContext.Contatos.AddAsync(contato);
            await dbContext.SaveChangesAsync();
            return Ok(contato);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> updateContato([FromRoute] int id, AddContatoRequest updateContato)
        {
            var contato = await dbContext.Contatos.FindAsync(id);
            if(contato != null)
            {
                contato.Endereco = updateContato.Endereco;
                contato.Nome = updateContato.Nome;
                contato.Telefone = updateContato.Telefone;
                await dbContext.SaveChangesAsync();
                return Ok("Contato atualizado com sucesso!");

            }
            return NotFound();
        }

        [HttpPost]
        [Route("{id:int}")]
        public async Task<IActionResult> GetContato([FromRoute] int id)
        {
            var result = await dbContext.Contatos.FindAsync(id);
            return Ok(result);

        }

    }
}
