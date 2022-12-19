using Application.Models;
using static Application.Models.Movimentacao;

namespace Application.ViewModel
{
    public class MovimentacaoRequest
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public TipoMovimentacaoEnum Tipo { get; set; }
        public int ConteinerId { get; set; }
    }

    public class MovimentacaoResponse
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public TipoMovimentacaoEnum Tipo { get; set; }
        public Conteiner Conteiner { get; set; }
    }
}
