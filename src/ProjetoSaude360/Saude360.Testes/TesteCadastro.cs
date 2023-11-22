using NUnit.Framework;
using ProjetoSaude360.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoSaude360.Models;
using System.Threading.Tasks;

namespace ProjetoSaude360.Testes
{
    [TestFixture]
    public class CadastrosControllerTestes
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
        public async Task Create_ComModelValida_DeveCriarNovoCadastroERedirecionarParaIndex()
        {
            var controller = new CadastrosController(_context);
            var novoCadastro = new Cadastro
            {
                Nome = "NovoUsuario",
                Senha = "Senha123",
                DataDeNascimento = new DateTime(1990, 1, 1),
                Email = "novo@usuario.com",
                
            };

            var result = await controller.Create(novoCadastro) as RedirectToActionResult;

            Assert.NotNull(result);
            Assert.AreEqual("Index", result?.ActionName);

            if (_context != null)
            {
                var cadastroAdicionado = await _context.Cadastros.FirstOrDefaultAsync(c => c.Nome == "NovoUsuario");
                Assert.NotNull(cadastroAdicionado);
            }
            else
            {
                Assert.Fail("O contexto é nulo. Certifique-se de que foi inicializado corretamente.");
            }
        }
    }
}
