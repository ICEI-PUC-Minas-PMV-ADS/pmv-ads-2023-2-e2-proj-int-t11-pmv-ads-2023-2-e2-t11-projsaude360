﻿using NuGet.Protocol.Core.Types;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSaude360.Models
{
    [Table("Consultas")]
    public class Consulta
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome do Médico")]
        public string? NomeMedico { get; set; }

        [Display(Name = "Motivo da Consulta")]
        public string? MotivoConsulta { get; set; }

        [Display(Name = "Data da Consulta")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DataConsulta { get; set; }

        [Display(Name = "Recomendações")]
        public string? Recomendacoes { get; set; }

        //Cadastros
        public Cadastro? Cadastros { get; set; }
        public int IdUsuario { get; set; }
            
    }
}
