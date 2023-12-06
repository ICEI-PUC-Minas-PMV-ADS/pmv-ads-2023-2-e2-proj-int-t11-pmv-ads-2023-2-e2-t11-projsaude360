using NUnit.Framework;
using ProjetoSaude360.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoSaude360.Models;
namespace SeuProjeto.Testes
{
    [TestFixture]
    public class TratamentoControllerTestes
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
        public async Task Create_WithValidModel_ShouldCreateNewTreatmentAndRedirectToIndex()
        {
            var controller = new TratamentosController(_context);
            var novoTratamento = new Tratamento
            {
                Id = 1,
                Dosagem = 10.0,
                DataInicio = DateTime.Now,
                DataTermino = DateTime.Now.AddDays(7),
                Obs = "Observação",
                Administracao = Enums.AdministracaoMed.Oral,
                Tipo = Enums.TipoTratamento.Hormonal
            };

            var result = await controller.Create(novoTratamento) as RedirectToActionResult;

            Assert.NotNull(result);
            Assert.AreEqual("Index", result?.ActionName);

            if (_context != null)
            {
                var tratamentoAdicionado = await _context.Tratamentos.FirstOrDefaultAsync(t => t.Id == 1);
                Assert.NotNull(tratamentoAdicionado);
            }
            else
            {
                Assert.Fail("O contexto é nulo. Certifique-se de que foi inicializado corretamente.");
            }
        }

        [Test]
        public async Task Create_WithInvalidModel_ShouldReturnViewResult()
        {
            var controller = new TratamentosController(_context);
            var tratamentoInvalido = new Tratamento
            {

            };

            controller.ModelState.AddModelError("Dosagem", "O campo Dosagem é obrigatório");

            var result = await controller.Create(tratamentoInvalido) as ViewResult;

            Assert.NotNull(result);
            Assert.AreEqual(tratamentoInvalido, result.Model);
        }
    }
}
