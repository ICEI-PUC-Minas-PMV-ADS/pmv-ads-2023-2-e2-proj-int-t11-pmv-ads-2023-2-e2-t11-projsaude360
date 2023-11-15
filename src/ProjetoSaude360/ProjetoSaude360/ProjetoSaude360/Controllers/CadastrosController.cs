﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using ProjetoSaude360.Models;

namespace ProjetoSaude360.Controllers
{
    public class CadastrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Enums.Genero Generos { get; set; }

        public Enums.Perfil Perfis { get; set; }

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

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Cadastro cadastro)
        {
            var data = await _context.Cadastros
                .FindAsync(cadastro.Email);

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

            return View();
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cadastros == null)
            {
                return NotFound();
            }

            var cadastro = await _context.Cadastros.FindAsync(id);
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
    }
}
