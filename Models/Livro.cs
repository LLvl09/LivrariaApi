using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivrariaApi.Models
{
    public class Livro
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string NomeLivro { get; set; }
        [Required]
        public string Categoria { get; set; }
        [Required]
        public string Resumo { get; set; }
        [Required]
        [Column(TypeName = "decimal(2,3)")]
        public decimal Preco { get; set; }
    }
}
