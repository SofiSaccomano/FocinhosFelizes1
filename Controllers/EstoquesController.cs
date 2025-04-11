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
    public class EstoquesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstoquesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Estoques
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Estoques.Include(e => e.Produtos);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Estoques/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Estoques == null)
            {
                return NotFound();
            }

            var estoque = await _context.Estoques
                .Include(e => e.Produtos)
                .FirstOrDefaultAsync(m => m.EstoqueId == id);
            if (estoque == null)
            {
                return NotFound();
            }

            return View(estoque);
        }

        // GET: Estoques/Create
        public IActionResult Create()
        {
            ViewData["ProdutosId"] = new SelectList(_context.Produtos, "ProdutosId", "ProdutosId");
            return View();
        }

        // POST: Estoques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstoqueId,ProdutosId,QtdEstoque")] Estoque estoque)
        {
            if (ModelState.IsValid)
            {
                estoque.EstoqueId = Guid.NewGuid();
                _context.Add(estoque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutosId"] = new SelectList(_context.Produtos, "ProdutosId", "ProdutosId", estoque.ProdutosId);
            return View(estoque);
        }

        // GET: Estoques/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Estoques == null)
            {
                return NotFound();
            }

            var estoque = await _context.Estoques.FindAsync(id);
            if (estoque == null)
            {
                return NotFound();
            }
            ViewData["ProdutosId"] = new SelectList(_context.Produtos, "ProdutosId", "ProdutosId", estoque.ProdutosId);
            return View(estoque);
        }

        // POST: Estoques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("EstoqueId,ProdutosId,QtdEstoque")] Estoque estoque)
        {
            if (id != estoque.EstoqueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estoque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstoqueExists(estoque.EstoqueId))
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
            ViewData["ProdutosId"] = new SelectList(_context.Produtos, "ProdutosId", "ProdutosId", estoque.ProdutosId);
            return View(estoque);
        }

        // GET: Estoques/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Estoques == null)
            {
                return NotFound();
            }

            var estoque = await _context.Estoques
                .Include(e => e.Produtos)
                .FirstOrDefaultAsync(m => m.EstoqueId == id);
            if (estoque == null)
            {
                return NotFound();
            }

            return View(estoque);
        }

        // POST: Estoques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Estoques == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Estoques'  is null.");
            }
            var estoque = await _context.Estoques.FindAsync(id);
            if (estoque != null)
            {
                _context.Estoques.Remove(estoque);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstoqueExists(Guid id)
        {
          return (_context.Estoques?.Any(e => e.EstoqueId == id)).GetValueOrDefault();
        }
    }
}
