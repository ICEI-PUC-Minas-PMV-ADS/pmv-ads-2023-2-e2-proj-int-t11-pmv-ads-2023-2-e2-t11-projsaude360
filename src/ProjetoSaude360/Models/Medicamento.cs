using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSaude360.Models
{
    [Table("Medicamentos")]
    public class Medicamento
    {
        [Key]
        public int Id { get; set; }

        public string NomeMedicamento { get; set; }

        public string Dosagem { get; set; }

        public string MedicamentoObs { get; set; }

        public string InfoMedicamento { get; set; }

        //TRATAMENTOs
        public Tratamento Tratamentos { get; set; }
    }
}
