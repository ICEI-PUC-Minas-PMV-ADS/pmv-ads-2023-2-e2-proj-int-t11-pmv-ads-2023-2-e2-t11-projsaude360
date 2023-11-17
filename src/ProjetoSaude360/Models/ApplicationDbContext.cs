using Microsoft.EntityFrameworkCore;

namespace ProjetoSaude360.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        
        }

        public DbSet<Cadastro> Cadastros { get; set; }
    }


}
