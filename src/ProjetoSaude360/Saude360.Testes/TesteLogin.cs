using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ProjetoSaude360.Controllers;
using ProjetoSaude360.Models;
using System.Threading.Tasks;

namespace ProjetoSaude360.Testes
{
    [TestFixture]
    public class CadastrosControllerTesteLogin
    {
        private ApplicationDbContext _context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;

            _context = new ApplicationDbContext(options);
        }

        [Test]
        public async Task Login_ComCredenciaisCorretas_DeveRedirecionarParaIndex()
        {
            var controller = new CadastrosController(_context);

            var cadastro = new Cadastro
            {
                Id = 1,
                Senha = "Senha123",
                Nome = "UsuarioExemplo",
                Email = "test@example.com"
            };

            await _context.Cadastros.AddAsync(cadastro);
            await _context.SaveChangesAsync();

            var result = await controller.Login(cadastro) as RedirectToActionResult;

            Assert.NotNull(result);
            Assert.AreEqual("Index", result?.ActionName);
        }
    }
}
