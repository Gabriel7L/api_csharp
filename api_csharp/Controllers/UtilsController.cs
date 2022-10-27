using api_csharp.Data;
using api_csharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.OpenApi.Any;
using Npgsql;
using System.Data;
using System.Net;
using System.Numerics;
using System.Text.Json;

namespace api_csharp.Controllers
{
    [ApiController]
    [Route("api/utils")]
    public class UtilsController : Controller
    {
        public class Combos
        {
            public string? id { get; set; }
            public string? desc { get; set; }
            public Combos(string id, string desc)
            {
                this.id = id;
                this.desc = desc;
            }
        }

        [HttpPost]
        public async Task<IActionResult> getCombos(getCombos comb)
        {
            var sql = "SELECT " + comb.id + "::text as id, " + comb.desc + "::text as desc FROM "+ comb.table + (comb.where != "" ? " WHERE" +comb.where : "");
            var conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;Database=teste;User Id=postgres;Password=mg#c0d3@Dsv;");
            conn.Open();
            var teste1 = new NpgsqlCommand(sql, conn);
            var result = await teste1.ExecuteReaderAsync();
            var b = new List<Combos>();
             
            while (result.Read())
            {              
                b.Add(new Combos(result.GetString(0), result.GetString(1)));
            }

            return Ok(b);
        }
     }
}
