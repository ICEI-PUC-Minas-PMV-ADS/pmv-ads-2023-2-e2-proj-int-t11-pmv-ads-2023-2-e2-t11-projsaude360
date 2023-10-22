using Microsoft.AspNetCore.Mvc;
using Saude360.Data;
using Saude360.Models;

namespace Saude360.Controllers
{
    public class CadastroController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Cadastro Cadastros { get; set; }

        public CadastroController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post(Cadastro cadastro)
        {
            _context.Cadastros.Add(cadastro);
            _context.SaveChanges();

            return Ok("Usuário criado com sucesso.");
        }
    }

}
