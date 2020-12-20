using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using T2S.Test.Data;
using T2S.Test.Models;

namespace T2S.Test.Controllers
{
    public class ConteinerMovimentacaoController : Controller
    {
        private readonly ConteinerContext _context;

        public ConteinerMovimentacaoController(ConteinerContext context)
        {
            _context = context;
        }

        // GET: ConteinerMovimentacao
        public async Task<IActionResult> Index()
        {
            var conteinerContext = _context.ConteinerMovimentacao.Include(c => c.Conteiner).Include(c => c.Movimentacao);
            return View(await conteinerContext.ToListAsync());
        }

        // GET: ConteinerMovimentacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conteinerMovimentacao = await _context.ConteinerMovimentacao
                .Include(c => c.Conteiner)
                .Include(c => c.Movimentacao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conteinerMovimentacao == null)
            {
                return NotFound();
            }

            return View(conteinerMovimentacao);
        }

        // GET: ConteinerMovimentacao/Create
        public IActionResult Create()
        {
            ViewData["ConteinerId"] = new SelectList(_context.Conteiner, "Id", "Cliente");
            ViewData["MovimentacaoId"] = new SelectList(_context.Movimentacao, "Id", "Navio");
            return View();
        }

        // POST: ConteinerMovimentacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ConteinerId,MovimentacaoId")] ConteinerMovimentacao conteinerMovimentacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conteinerMovimentacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConteinerId"] = new SelectList(_context.Conteiner, "Id", "Cliente", conteinerMovimentacao.ConteinerId);
            ViewData["MovimentacaoId"] = new SelectList(_context.Movimentacao, "Id", "Navio", conteinerMovimentacao.MovimentacaoId);
            return View(conteinerMovimentacao);
        }

        // GET: ConteinerMovimentacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conteinerMovimentacao = await _context.ConteinerMovimentacao.FindAsync(id);
            if (conteinerMovimentacao == null)
            {
                return NotFound();
            }
            ViewData["ConteinerId"] = new SelectList(_context.Conteiner, "Id", "Cliente", conteinerMovimentacao.ConteinerId);
            ViewData["MovimentacaoId"] = new SelectList(_context.Movimentacao, "Id", "Navio", conteinerMovimentacao.MovimentacaoId);
            return View(conteinerMovimentacao);
        }

        // POST: ConteinerMovimentacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ConteinerId,MovimentacaoId")] ConteinerMovimentacao conteinerMovimentacao)
        {
            if (id != conteinerMovimentacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conteinerMovimentacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConteinerMovimentacaoExists(conteinerMovimentacao.Id))
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
            ViewData["ConteinerId"] = new SelectList(_context.Conteiner, "Id", "Cliente", conteinerMovimentacao.ConteinerId);
            ViewData["MovimentacaoId"] = new SelectList(_context.Movimentacao, "Id", "Navio", conteinerMovimentacao.MovimentacaoId);
            return View(conteinerMovimentacao);
        }

        // GET: ConteinerMovimentacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conteinerMovimentacao = await _context.ConteinerMovimentacao
                .Include(c => c.Conteiner)
                .Include(c => c.Movimentacao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conteinerMovimentacao == null)
            {
                return NotFound();
            }

            return View(conteinerMovimentacao);
        }

        // POST: ConteinerMovimentacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conteinerMovimentacao = await _context.ConteinerMovimentacao.FindAsync(id);
            _context.ConteinerMovimentacao.Remove(conteinerMovimentacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConteinerMovimentacaoExists(int id)
        {
            return _context.ConteinerMovimentacao.Any(e => e.Id == id);
        }
    }
}
