using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSaude360.Models
{
    [Table ("Usuarios")]
    public class Cadastro
    {
        [Key]
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
        public int Telefone { get; set; }

        public Enums.Perfil Perfil { get; set; }
    }

    
}
