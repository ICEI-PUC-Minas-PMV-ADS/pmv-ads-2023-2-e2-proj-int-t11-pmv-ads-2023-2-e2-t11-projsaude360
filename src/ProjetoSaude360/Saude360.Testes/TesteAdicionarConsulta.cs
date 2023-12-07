using NUnit.Framework;
using ProjetoSaude360.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoSaude360.Models;
namespace ProjetoSaude360.Testes
{
    [TestFixture]
    public class ConsultaControllerTestes
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
        public async Task Create_WithValidModel_ShouldCreateNewConsultAndRedirectToIndex()
        {
            var controller = new ConsultasController(_context);
            var novaConsulta = new Consulta
            {
                Id = 1,
                NomeMedico = "Dr. Exemplo",
                MotivoConsulta = "Dor de cabeça",
                DataConsulta = DateTime.Now,
                Recomendacoes = "Repouso e medicamentos"
            };

            var result = await controller.Create(novaConsulta) as RedirectToActionResult;

            Assert.NotNull(result);
            Assert.AreEqual("Index", result?.ActionName);

            if (_context != null)
            {
                var consultaAdicionada = await _context.Consultas.FirstOrDefaultAsync(c => c.Id == 1);
                Assert.NotNull(consultaAdicionada);
            }
            else
            {
                Assert.Fail("O contexto é nulo. Certifique-se de que foi inicializado corretamente.");
            }
        }

        [Test]
        public async Task Create_WithInvalidModel_ShouldReturnViewResult()
        {
            var controller = new ConsultasController(_context);
            var consultaInvalida = new Consulta
            {
            };

            controller.ModelState.AddModelError("NomeMedico", "O campo Nome do Médico é obrigatório");

            var result = await controller.Create(consultaInvalida) as ViewResult;

            Assert.NotNull(result);
            Assert.AreEqual(consultaInvalida, result.Model);
        }
    }
}
