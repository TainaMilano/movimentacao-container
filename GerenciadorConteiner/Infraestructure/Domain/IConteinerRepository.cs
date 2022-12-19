using WebApplication1.Models;

namespace WebApplication1.Infraestructure.Domain
{
    public interface IConteinerRepository
    {
        Task<IEnumerable<Conteiner>> BuscarTodos();
        Task<Conteiner> PesquisarPorId(int id);
        Task<bool> Salvar();
        Task<bool> Incluir(Conteiner conteiner);
        Task<bool> Alterar(Conteiner conteiner);
        Task<bool> Excluir(int id);
    }
}
