using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSaude360.Models
{
    [Table("Medicamentos")]
    public class Medicamento
    {
        public Medicamento(string nome, string dosagem, string obs, string info)
        {
            Nome = nome;
            Dosagem = dosagem;
            Obs = obs;
            Info = info;
        }

        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Dosagem { get; set; }

        public string Obs { get; set; }


        public string Info{ get; set; }

        //TRATAMENTOs
        public Tratamento Tratamento { get; set; }
    }
}
