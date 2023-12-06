using NUnit.Framework;
using ProjetoSaude360.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoSaude360.Models;

namespace ProjetoSaude360.Testes
{
    [TestFixture]
    public class MedicamentoAdicionaControllerTestes
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
        public async Task Create_ComModelValida_DeveCriarNovoMedicamentoERedirecionarParaIndex()
        {
            var controller = new MedicamentosController(_context);
            var novoMedicamento = new Medicamento
            {
                Nome = "NovoMedicamento",
                Dosagem = "10mg",
                Obs = "Observação",
                Info = "Informação adicional"
            };

            var result = await controller.Create(novoMedicamento) as RedirectToActionResult;

            Assert.NotNull(result);
            Assert.AreEqual("Index", result?.ActionName);

            if (_context != null)
            {
                var medicamentoAdicionado = await _context.Medicamentos.FirstOrDefaultAsync(m => m.Nome == "NovoMedicamento");
                Assert.NotNull(medicamentoAdicionado);
            }
            else
            {
                Assert.Fail("O contexto é nulo. Certifique-se de que foi inicializado corretamente.");
            }
        }
    }
}
