using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoSaude360.Models
{
    public class Enums
    {
        public enum Genero { 
            Masculino,
            Feminino,
            Outros
        }

        public enum Perfil
        {
            Admin,
            User
        }

        public enum AdministracaoMed
        {
            Oral,
            Retal,
            Sublingual,
            Nasal,    
            Ocular,
            Parental
        }

        public enum TipoTratamento
        {
            [Display(Name = "Tratamento Hormonal")]
            Hormonal,
            [Display(Name = "Tratamento para dor")]
            Dor,
            [Display(Name = "Depressão")]
            Depressao,
            [Display(Name = "Pressão Alta")]
            PressaoAlta,
            [Display(Name = "Controle de Glicemia")]
            Diabetes,
        }
    }
}
