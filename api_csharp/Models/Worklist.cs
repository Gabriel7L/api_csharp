using System.ComponentModel.DataAnnotations.Schema;

namespace api_csharp.Models
{
    [Table("worklist")]
    public class Worklist
    {
        [Column("id")]
        public int? Id { get; set; }
        [Column("exame")]
        public string? Exame { get; set; }
        [Column("sala")]
        public string? Sala { get; set; }
    }
}
