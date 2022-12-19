using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Models
{
    [Table("MOVIMENTACOES")]
    public class Movimentacao
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public TipoMovimentacaoEnum Tipo { get; set; }
        public enum TipoMovimentacaoEnum { EMBARQUE, DESCARGA, GATE_IN, GATE_OUT, REPOSICIONAMENTO, PESAGEM, SCANNER }


        [ForeignKey("Conteiner")]
        public int ConteinerId { get; set; }
        public Conteiner Conteiner { get; set; }
    }
}
