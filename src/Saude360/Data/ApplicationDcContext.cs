using Saude360.Models;

namespace Saude360.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSeet<Cadastro> Cadastros { get; set; }
        public DbSet<Login> Logins { get; set; }


    }
}
