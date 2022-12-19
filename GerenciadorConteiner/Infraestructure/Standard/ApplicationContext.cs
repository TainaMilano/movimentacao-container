using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Infraestructure.Standard
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
    }
}
