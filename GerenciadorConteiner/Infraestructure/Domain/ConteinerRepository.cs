using Microsoft.EntityFrameworkCore;
using WebApplication1.Infraestructure.Standard;
using WebApplication1.Models;

namespace WebApplication1.Infraestructure.Domain
{
    public class ConteinerRepository : IConteinerRepository
    {
        private readonly ApplicationContext _context;

        public ConteinerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> Incluir(Conteiner conteiner)
        {
            _context.Conteiners.Add(conteiner);
            return await Salvar();
        }

        public async Task<bool> Alterar(Conteiner conteiner)
        {
            _context.Entry(conteiner).State = EntityState.Modified;
            return await Salvar();
        }

        public async Task<bool> Excluir(int id)
        {
            var conteiner = await _context.Conteiners.FindAsync(id);

            if(conteiner != null && conteiner.Id > 0)
            {
                _context.Conteiners.Remove(conteiner);
                return await Salvar();
            }

            return false;
        }

        public async Task<IEnumerable<Conteiner>> BuscarTodos()
        {
            return await _context.Conteiners.ToListAsync();
        }

        public async Task<Conteiner> PesquisarPorId(int id)
        {
            return await _context.Conteiners.FindAsync(id);
        }

        public async Task<bool> Salvar()
        {
            var response = await _context.SaveChangesAsync();

            return response > 0;
        }
    }
}
