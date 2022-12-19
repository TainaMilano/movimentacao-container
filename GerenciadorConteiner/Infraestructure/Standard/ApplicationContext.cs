using Microsoft.EntityFrameworkCore;
using Application.Models;

namespace Application.Infraestructure.Standard
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() { }

        public ApplicationContext(DbContextOptions<DbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=conteinerdb;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=true;MultipleActiveResultSets=true");
        }

        public DbSet<Conteiner> Conteiners { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }
    }
}
