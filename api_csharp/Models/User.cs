using System.ComponentModel.DataAnnotations.Schema;

namespace api_csharp.Models
{
    [Table("users")]
    public class User
    {
        [Column("id")]
        public int? Id { get; set; }
        [Column("nome")]
        public string? Nome { get; set; }
        [Column("email")]
        public string? Email{ get; set; }
        [Column("password")]
        public string? Password { get; set; }
        [Column("perfil")]
        public string? Perfil { get; set; }
    }
}
