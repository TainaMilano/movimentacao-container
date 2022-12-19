using Application.Models;
using static Application.Models.Movimentacao;

namespace Application.Infraestructure.Domain
{
    public interface IMovimentacaoRepository
    {
        Task<IEnumerable<Movimentacao>> BuscarTodosComCliente();
        Task<IEnumerable<Movimentacao>> BuscarTodos();
        Task<Movimentacao> PesquisarPorId(int id);
        Task<bool> Salvar();
        Task<bool> Incluir(Movimentacao movimentacao);
        Task<bool> Alterar(Movimentacao movimentacao);
        Task<bool> Excluir(int id);
    }
}
