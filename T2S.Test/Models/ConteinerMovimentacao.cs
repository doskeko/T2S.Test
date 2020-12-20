namespace T2S.Test.Models
{
    public class ConteinerMovimentacao
    {
        public int Id { get; set; }
        public int ConteinerId { get; set; }
        public Conteiner Conteiner { get; set; }
        public int MovimentacaoId { get; set; }
        public Movimentacao Movimentacao { get; set; }
    }
}
