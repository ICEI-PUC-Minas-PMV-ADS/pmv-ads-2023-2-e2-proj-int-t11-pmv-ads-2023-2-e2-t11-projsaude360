using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoSaude360.Models;
using Microsoft.AspNetCore.Authorization;

namespace ProjetoSaude360.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CadastrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Enums.Genero Generos { get; set; }

        public Enums.Perfil Perfis { get; set; }

         public Cadastro Cadastros { get; set; }

        public CadastrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.Cadastros != null ?
                        View(await _context.Cadastros.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Cadastros'  is null.");
        }

        [AllowAnonymous]
        public IActionResult PerfilUsuario()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> PerfilUsuario(Cadastro cadastro)
        {

            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Cadastro cadastro)
        {
            var data = await _context.Cadastros
                .FindAsync(cadastro.Id);

            if (data == null)
            {
                ViewBag.Message = "Usuário ou senha inválidos";
            }

            bool senhaOk = BCrypt.Net.BCrypt.Verify(cadastro.Senha, data.Senha);

            if (senhaOk)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, data.Nome),
                    new Claim(ClaimTypes.NameIdentifier, data.Id.ToString()),
                    new Claim(ClaimTypes.Role, data.Perfil.ToString())
                };

                var usuarioIdentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(usuarioIdentity);

                var props = new AuthenticationProperties
                {
                    //Permite atualização das credenciais
                    AllowRefresh = true,

                    //Expira após 8horas de trabalho
                    ExpiresUtc = DateTime.UtcNow.ToLocalTime().AddHours(8),

                    //persiste nos cookies do navegador do usuário
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(principal, props);

                Redirect("/");
            }
            else
            {
                ViewBag.Message = "Usuário ou senha inválidos";
            }

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Cadastros");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cadastros == null)
            {
                return NotFound();
            }

            var cadastro = await _context.Cadastros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastro == null)
            {
                return NotFound();
            }

            return View(cadastro);
        }

        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Create([Bind("Id,Nome,Senha,Genero,DataDeNascimento,Email,Telefone,Perfil")] Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                cadastro.Senha = BCrypt.Net.BCrypt.HashPassword(cadastro.Senha);
                _context.Add(cadastro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastro);
        }

        public async Task<IActionResult> Edit()
        {
            var idUsuario = ObterUsuarioId();

            if (idUsuario == 0 || _context.Cadastros == null)
            {
                return NotFound();
            }

            var cadastro = await _context.Cadastros.FindAsync(idUsuario);
            if (cadastro == null)
            {
                return NotFound();
            }

            return View(cadastro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Senha,Genero,DataDeNascimento,Email,Telefone,Perfil")] Cadastro cadastro)
        {
            if (id != cadastro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    cadastro.Senha = BCrypt.Net.BCrypt.HashPassword(cadastro.Senha);
                    _context.Update(cadastro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroExists(cadastro.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cadastro);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cadastros == null)
            {
                return NotFound();
            }

            var cadastro = await _context.Cadastros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastro == null)
            {
                return NotFound();
            }

            return View(cadastro);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cadastros == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cadastros'  is null.");
            }
            var cadastro = await _context.Cadastros.FindAsync(id);
            if (cadastro != null)
            {
                _context.Cadastros.Remove(cadastro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroExists(int id)
        {
            return (_context.Cadastros?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private int ObterUsuarioId()
        {
            return Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value?.ToString());
        }
    }
}
