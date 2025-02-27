using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Filmes_senai.Domains
{

    [Table("Gênero")]
    public class Genero
    {
        [Key]
        public Guid IdGereno { get; set; }

        [Column(TypeName = "VARCHAR(30)")]
        [Required(ErrorMessage = "Nome do Gênero é obrigatório!")]
        public string? Nome { get; set; }


    }
}
