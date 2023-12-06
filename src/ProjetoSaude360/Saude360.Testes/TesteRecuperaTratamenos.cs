using NUnit.Framework;
using ProjetoSaude360.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoSaude360.Models;
namespace SeuProjeto.Testes
{
    [TestFixture]
    public class TratamentosControllerTestes
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
            var controller = new TratamentosController(_context);

            var tratamento = new Tratamento
            {
                Id = 1,
                Dosagem = 10.0,
                DataInicio = DateTime.Now,
                DataTermino = DateTime.Now.AddDays(7),
                Obs = "Observação",
                Administracao = Enums.AdministracaoMed.Oral,
                Tipo = Enums.TipoTratamento.Hormonal
            };
            _context.Tratamentos.Add(tratamento);
            await _context.SaveChangesAsync();

            var result = await controller.Details(1) as ViewResult;

            Assert.NotNull(result);
            Assert.AreEqual("Details", result?.ViewName);
            Assert.NotNull(result.Model);
            Assert.IsInstanceOf<Tratamento>(result.Model);
        }

        [Test]
        public async Task Details_WithInvalidId_ShouldReturnNotFoundResult()
        {
            var controller = new TratamentosController(_context);

            var result = await controller.Details(null) as NotFoundResult;

            Assert.NotNull(result);
        }

        [Test]
        public async Task Details_WithNonExistingId_ShouldReturnNotFoundResult()
        {
            var controller = new TratamentosController(_context);

            var result = await controller.Details(999) as NotFoundResult;

            Assert.NotNull(result);
        }
    }
}
