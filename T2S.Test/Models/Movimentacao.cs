using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace T2S.Test.Models
{
    public class Movimentacao
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o Nome do Navio")]
        [StringLength(50, MinimumLength = 5)]
        public string Navio { get; set; }
        [Required(ErrorMessage = "Escolha um Tipo")]
        public string TipoMovimentacao { get; set; }
        [Required(ErrorMessage = "Informe uma data inicial.")]
        public DateTime DataInicio { get; set; }
        [Required(ErrorMessage = "Informe uma data final.")]
        public DateTime DataFim { get; set; }
        public List<ConteinerMovimentacao> ConteinerMovimentacao { get; set; }

    }
}
