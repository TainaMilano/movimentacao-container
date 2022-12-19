using Application.Models;

namespace Application.Infraestructure.Domain
{
    public interface IConteinerRepository
    {
        Task<bool> Salvar();
        Task<bool> Incluir(Conteiner conteiner);
        Task<bool> Alterar(Conteiner conteiner);
        Task<bool> Excluir(int id);
        Task<Conteiner> PesquisarPorId(int id);
        Task<IEnumerable<Conteiner>> BuscarTodos();
    }
}
