using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSaude360.Models
{
    [Table("Tratamentos")]
    public class Tratamento
    {
        [Key]
        public int Id { get; set; }

        public double Dosagem { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataTermino { get; set; }

        public string TratamentoObs { get; set; }

        public Enums.AdministracaoMed Administracao { get; set; }                   

        public Enums.TipoTratamento Tipo { get; set; }                                           

        public Medicamento NomeMedicamento { get; set; }

        //Cadastro
        public Cadastro Cadastro { get; set; }


        // Medicamentos
        public ICollection<Medicamento> Medicamentos { get; set; }

    }
}
