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
    public class ConteinerController : Controller
    {
        private readonly ConteinerContext _context;

        public ConteinerController(ConteinerContext context)
        {
            _context = context;
        }

        // GET: Conteiner
        public async Task<IActionResult> Index()
        {
            return View(await _context.Conteiner.ToListAsync());
        }

        // GET: Conteiner/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conteiner = await _context.Conteiner
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conteiner == null)
            {
                return NotFound();
            }

            return View(conteiner);
        }

        // GET: Conteiner/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conteiner/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cliente,NumCntr,Tipo,Status,Categoria")] Conteiner conteiner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conteiner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conteiner);
        }

        // GET: Conteiner/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conteiner = await _context.Conteiner.FindAsync(id);
            if (conteiner == null)
            {
                return NotFound();
            }
            return View(conteiner);
        }

        // POST: Conteiner/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cliente,NumCntr,Tipo,Status,Categoria")] Conteiner conteiner)
        {
            if (id != conteiner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conteiner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConteinerExists(conteiner.Id))
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
            return View(conteiner);
        }

        // GET: Conteiner/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conteiner = await _context.Conteiner
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conteiner == null)
            {
                return NotFound();
            }

            return View(conteiner);
        }

        // POST: Conteiner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conteiner = await _context.Conteiner.FindAsync(id);
            _context.Conteiner.Remove(conteiner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConteinerExists(int id)
        {
            return _context.Conteiner.Any(e => e.Id == id);
        }
    }
}
