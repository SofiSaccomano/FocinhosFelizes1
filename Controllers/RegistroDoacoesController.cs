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
    public class RegistroDoacoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistroDoacoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RegistroDoacoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RegistroDoacoes.Include(r => r.Produtos);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RegistroDoacoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.RegistroDoacoes == null)
            {
                return NotFound();
            }

            var registroDoacao = await _context.RegistroDoacoes
                .Include(r => r.Produtos)
                .FirstOrDefaultAsync(m => m.RegistroDoacaoId == id);
            if (registroDoacao == null)
            {
                return NotFound();
            }

            return View(registroDoacao);
        }

        // GET: RegistroDoacoes/Create
        public IActionResult Create()
        {
            ViewData["ProdutosId"] = new SelectList(_context.Produtos, "ProdutosId", "ProdutosId");
            return View();
        }

        // POST: RegistroDoacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegistroDoacaoId,ProdutosId,DoadoresId,ValidadeProduto,DataDoacao")] RegistroDoacao registroDoacao)
        {
            if (ModelState.IsValid)
            {
                registroDoacao.RegistroDoacaoId = Guid.NewGuid();
                _context.Add(registroDoacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutosId"] = new SelectList(_context.Produtos, "ProdutosId", "ProdutosId", registroDoacao.ProdutosId);
            return View(registroDoacao);
        }

        // GET: RegistroDoacoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.RegistroDoacoes == null)
            {
                return NotFound();
            }

            var registroDoacao = await _context.RegistroDoacoes.FindAsync(id);
            if (registroDoacao == null)
            {
                return NotFound();
            }
            ViewData["ProdutosId"] = new SelectList(_context.Produtos, "ProdutosId", "ProdutosId", registroDoacao.ProdutosId);
            return View(registroDoacao);
        }

        // POST: RegistroDoacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("RegistroDoacaoId,ProdutosId,DoadoresId,ValidadeProduto,DataDoacao")] RegistroDoacao registroDoacao)
        {
            if (id != registroDoacao.RegistroDoacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroDoacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroDoacaoExists(registroDoacao.RegistroDoacaoId))
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
            ViewData["ProdutosId"] = new SelectList(_context.Produtos, "ProdutosId", "ProdutosId", registroDoacao.ProdutosId);
            return View(registroDoacao);
        }

        // GET: RegistroDoacoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.RegistroDoacoes == null)
            {
                return NotFound();
            }

            var registroDoacao = await _context.RegistroDoacoes
                .Include(r => r.Produtos)
                .FirstOrDefaultAsync(m => m.RegistroDoacaoId == id);
            if (registroDoacao == null)
            {
                return NotFound();
            }

            return View(registroDoacao);
        }

        // POST: RegistroDoacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.RegistroDoacoes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RegistroDoacoes'  is null.");
            }
            var registroDoacao = await _context.RegistroDoacoes.FindAsync(id);
            if (registroDoacao != null)
            {
                _context.RegistroDoacoes.Remove(registroDoacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroDoacaoExists(Guid id)
        {
          return (_context.RegistroDoacoes?.Any(e => e.RegistroDoacaoId == id)).GetValueOrDefault();
        }
    }
}
