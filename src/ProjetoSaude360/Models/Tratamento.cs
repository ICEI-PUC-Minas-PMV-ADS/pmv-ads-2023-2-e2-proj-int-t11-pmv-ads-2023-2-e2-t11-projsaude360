using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSaude360.Models
{
    [Table("Tratamentos")]
    public class Tratamento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public double? Dosagem { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DataInicio { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DataTermino { get; set; }

        public string? Obs { get; set; }

        public Enums.AdministracaoMed? Administracao { get; set; }                           

        public Enums.TipoTratamento? Tipo { get; set; }                                           

        //Cadastro
        public Cadastro? Cadastro { get; set; }
        public int IdUsuario { get; set; }
        
        // Medicamentos
        public ICollection<Medicamento>? Medicamentos { get; set; }
    }
}
