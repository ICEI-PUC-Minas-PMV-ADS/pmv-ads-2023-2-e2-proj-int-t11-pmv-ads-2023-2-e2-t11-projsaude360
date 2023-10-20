using Microsoft.EntityFrameworkCore;
using Saude360.Models;
using System.Collections.Generic;


namespace Saude360.Data
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Cadastro> Cadastros { get; set; }
        public DbSet<Login> Logins { get; set; }

    }
}
