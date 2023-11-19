using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSaude360.Models
{
    [Table("Tratamentos")]
    public class Tratamento
    {
        public Tratamento(double dosagem, DateTime dataInicio, DateTime dataTermino, string obs, Enums.AdministracaoMed administracao, Enums.TipoTratamento tipo)
        {
            Dosagem = dosagem;
            DataInicio = dataInicio;
            DataTermino = dataTermino;
            Obs = obs;
            Administracao = administracao;
            Tipo = tipo;
        }

        [Key]
        public int Id { get; set; }

        public double Dosagem { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataTermino { get; set; }

        public string Obs { get; set; }

        public Enums.AdministracaoMed Administracao { get; set; }                           

        public Enums.TipoTratamento Tipo { get; set; }                                           

        //Cadastro
        public Cadastro Cadastro { get; set; }

        // Medicamentos
        public ICollection<Medicamento> Medicamentos { get; set; }

    }
}
