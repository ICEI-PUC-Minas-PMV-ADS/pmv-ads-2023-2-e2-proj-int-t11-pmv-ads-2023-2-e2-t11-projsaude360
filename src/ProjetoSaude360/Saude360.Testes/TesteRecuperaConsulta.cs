using NUnit.Framework;
using ProjetoSaude360.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoSaude360.Models;
namespace ProjetoSaude360.Testes
{
    [TestFixture]
    public class ConsultasControllerTestes
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
        public async Task Details_WithValidId_ShouldReturnViewResult()
        {
            var controller = new ConsultasController(_context);

            var consulta = new Consulta
            {
                Id = 1,
                NomeMedico = "Dr. Exemplo",
                MotivoConsulta = "Dor de cabeça",
                DataConsulta = DateTime.Now,
                Recomendacoes = "Repouso e medicamentos"
            };
            _context.Consultas.Add(consulta);
            await _context.SaveChangesAsync();

            var result = await controller.Details(1) as ViewResult;

            Assert.NotNull(result);
            Assert.AreEqual("Details", result?.ViewName);
            Assert.NotNull(result.Model);
            Assert.IsInstanceOf<Consulta>(result.Model);
        }

        [Test]
        public async Task Details_WithInvalidId_ShouldReturnNotFoundResult()
        {
            var controller = new ConsultasController(_context);

            var result = await controller.Details(null) as NotFoundResult;

            Assert.NotNull(result);
        }

        [Test]
        public async Task Details_WithNonExistingId_ShouldReturnNotFoundResult()
        {
            var controller = new ConsultasController(_context);

            var consulta = new Consulta
            {
                Id = 2,
                NomeMedico = "Dr. Exemplo",
                MotivoConsulta = "Dor de cabeça",
                DataConsulta = DateTime.Now,
                Recomendacoes = "Repouso e medicamentos"
            };
            _context.Consultas.Add(consulta);
            await _context.SaveChangesAsync();

            var result = await controller.Details(1) as NotFoundResult;

            Assert.NotNull(result);
        }

        [Test]
        public async Task Details_WithNullContext_ShouldReturnNotFoundResult()
        {
            var controller = new ConsultasController(null);

            var result = await controller.Details(1) as NotFoundResult;

            Assert.NotNull(result);
        }
    }
}
