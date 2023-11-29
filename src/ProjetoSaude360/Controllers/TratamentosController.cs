using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoSaude360.Models;

namespace ProjetoSaude360.Controllers
{
    [Authorize]
    public class TratamentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TratamentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tratamentos
        public async Task<IActionResult> Index()
        {
              return _context.Tratamentos != null ? 
                          View(await _context.Tratamentos.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Tratamentos'  is null.");
        }

        // GET: Tratamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tratamentos == null)
            {
                return NotFound();
            }

            var tratamento = await _context.Tratamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tratamento == null)
            {
                return NotFound();
            }

            return View(tratamento);
        }

        // GET: Tratamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tratamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Dosagem,DataInicio,DataTermino,Obs,Administracao,Tipo")] Tratamento tratamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tratamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tratamento);
        }

        // GET: Tratamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tratamentos == null)
            {
                return NotFound();
            }

            var tratamento = await _context.Tratamentos.FindAsync(id);
            if (tratamento == null)
            {
                return NotFound();
            }
            return View(tratamento);
        }

        // POST: Tratamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Dosagem,DataInicio,DataTermino,Obs,Administracao,Tipo")] Tratamento tratamento)
        {
            if (id != tratamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tratamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TratamentoExists(tratamento.Id))
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
            return View(tratamento);
        }

        // GET: Tratamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tratamentos == null)
            {
                return NotFound();
            }

            var tratamento = await _context.Tratamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tratamento == null)
            {
                return NotFound();
            }

            return View(tratamento);
        }

        // POST: Tratamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tratamentos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Tratamentos'  is null.");
            }
            var tratamento = await _context.Tratamentos.FindAsync(id);
            if (tratamento != null)
            {
                _context.Tratamentos.Remove(tratamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TratamentoExists(int id)
        {
          return (_context.Tratamentos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
