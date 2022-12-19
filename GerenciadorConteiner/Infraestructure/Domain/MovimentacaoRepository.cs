using Application.Infraestructure.Standard;
using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Infraestructure.Domain
{
    public class MovimentacaoRepository : IMovimentacaoRepository
    {
        private readonly ApplicationContext _context;

        public MovimentacaoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> Excluir(int id)
        {
            var movimentacao = await _context.Movimentacoes.FindAsync(id);

            if (movimentacao != null && movimentacao.Id > 0)
            {
                _context.Movimentacoes.Remove(movimentacao);
                return await Salvar();
            }

            return false;
        }

        public async Task<bool> Incluir(Movimentacao movimentacao)
        {
            _context.Movimentacoes.Add(movimentacao);
            return await Salvar();
        }

        public async Task<bool> Alterar(Movimentacao movimentacao)
        {
            _context.Entry(movimentacao).State = EntityState.Modified;
            return await Salvar();
        }

        public async Task<bool> Salvar()
        {
            var response = await _context.SaveChangesAsync();

            return response > 0;
        }

        public async Task<Movimentacao> PesquisarPorId(int id)
        {
            return await _context.Movimentacoes.FindAsync(id);
        }

        public async Task<IEnumerable<Movimentacao>> BuscarTodos()
        {
            return await _context.Movimentacoes.ToListAsync();
        }

        public async Task<IEnumerable<Movimentacao>> BuscarTodosComCliente()
        {
            return await _context.Movimentacoes.Include(m => m.Conteiner).ToListAsync();
        }
    }
}
