using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSaude360.Models
{
    [Table ("Cadastros")]
    public class Cadastro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required]
        public Enums.Genero Genero { get; set; }

        [Required]
        public DateTime DataDeNascimento { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public long Telefone { get; set; }

        public Enums.Perfil Perfil { get; set; }

        //TRATAMENTOS
        public ICollection<Tratamento> Tratamentos {  get; set; }
    
        //CONSULTAS
        public ICollection<Consulta> Consultas { get; set; }
    }
}
