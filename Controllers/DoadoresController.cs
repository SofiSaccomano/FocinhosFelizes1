using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FocinhosFelizes1.Data;
using FocinhosFelizes1.Models;

namespace FocinhosFelizes1.Controllers
{
    public class DoadoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoadoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Doadores
        public async Task<IActionResult> Index()
        {
            return _context.Doadores != null ?
                        View(await _context.Doadores.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Doadores'  is null.");
        }

        // GET: Doadores/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Doadores == null)
            {
                return NotFound();
            }

            var doador = await _context.Doadores
                .FirstOrDefaultAsync(m => m.DoadorId == id);
            if (doador == null)
            {
                return NotFound();
            }

            return View(doador);
        }

        // GET: Doadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoadorId,NomeDoador,CPF,Celular")] Doador doador)
        {
            if (ModelState.IsValid)
            {
                doador.DoadorId = Guid.NewGuid();
                _context.Add(doador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doador);
        }

        // GET: Doadores/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Doadores == null)
            {
                return NotFound();
            }

            var doador = await _context.Doadores.FindAsync(id);
            if (doador == null)
            {
                return NotFound();
            }
            return View(doador);
        }

        // POST: Doadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DoadorId,NomeDoador,CPF,Celular")] Doador doador)
        {
            if (id != doador.DoadorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoadorExists(doador.DoadorId))
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
            return View(doador);
        }

        // GET: Doadores/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Doadores == null)
            {
                return NotFound();
            }

            var doador = await _context.Doadores
                .FirstOrDefaultAsync(m => m.DoadorId == id);
            if (doador == null)
            {
                return NotFound();
            }

            return View(doador);
        }

        // POST: Doadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Doadores == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Doadores'  is null.");
            }
            var doador = await _context.Doadores.FindAsync(id);
            if (doador != null)
            {
                _context.Doadores.Remove(doador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoadorExists(Guid id)
        {
            return (_context.Doadores?.Any(e => e.DoadorId == id)).GetValueOrDefault();
        }

        // GET: Doadores/Search
        public async Task<IActionResult> Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return View("Index", await _context.Doadores.ToListAsync());
            }

            var doadores = await _context.Doadores
                .Where(a => a.NomeDoador.Contains(searchTerm) || a.CPF.Contains(searchTerm))
                .ToListAsync();

            return View("Index", doadores);
        }
    }
}
