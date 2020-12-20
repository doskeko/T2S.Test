using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace T2S.Test.Models
{
    public class Conteiner
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o Nome do Cliente")]
        [StringLength(50, MinimumLength =5)]
        public string Cliente { get; set; }
        [Required(ErrorMessage = "Informe o Número do Contêiner")]
        [StringLength(11, MinimumLength = 11)]
        [RegularExpression(@"^[a-z]{4}[0-9]{7}$", ErrorMessage ="O número deve conter 4 letras e 7 números") ]
        public string NumCntr { get; set; }
        [Required(ErrorMessage = "Informe o Tipo")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "Informe o Status")]        
        public string Status { get; set; }
        [Required(ErrorMessage = "Informe a Categoria")]        
        public string Categoria { get; set; }
        public List<ConteinerMovimentacao> ConteinerMovimentacao { get; set; }
    }
}

