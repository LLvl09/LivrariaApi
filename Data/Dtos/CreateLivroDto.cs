using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivrariaApi.Data.Dtos
{
    public class CreateLivroDto
    {
        [Required]
        public string NomeLivro { get; set; }
        [Required]
        public string Categoria { get; set; }
        [Required]
        public string Resumo { get; set; }
        [Required]
        [Column(TypeName = "decimal(4,2)")]
        public decimal Preco { get; set; }
    }
}
