using System.ComponentModel.DataAnnotations.Schema;

namespace api_csharp.Models
{
    [Table("contato")]
    public class Contato
    {
        [Column("id")]
        public int? Id { get; set; }
        [Column("nome")]
        public string? Nome { get; set; }
        [Column("telefone")]
        public string? Telefone { get; set; }
        [Column("endereco")]
        public string? Endereco { get; set; }

    }
}
