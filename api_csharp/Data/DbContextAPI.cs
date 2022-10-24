using api_csharp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace api_csharp.Data
{
    public class DbContextAPI : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContextAPI(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Contato> Contatos { get; set; }
    }
}
