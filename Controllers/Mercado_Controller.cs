using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mercado.Data;
using Mercado.Models;

namespace Mercado.Controllers
{
    public class Mercado_Controller : Controller
    {
        private readonly MercadoContext _context;

        public Mercado_Controller(MercadoContext context)
        {
            _context = context;
        }

        // GET: Mercado_
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mercado.ToListAsync());
        }

        // GET: Mercado_/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mercado_ = await _context.Mercado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mercado_ == null)
            {
                return NotFound();
            }

            return View(mercado_);
        }

        // GET: Mercado_/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mercado_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha_creacion,Estado")] Mercado_ mercado_)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mercado_);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mercado_);
        }

        // GET: Mercado_/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mercado_ = await _context.Mercado.FindAsync(id);
            if (mercado_ == null)
            {
                return NotFound();
            }
            return View(mercado_);
        }

        // POST: Mercado_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha_creacion,Estado")] Mercado_ mercado_)
        {
            if (id != mercado_.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mercado_);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Mercado_Exists(mercado_.Id))
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
            return View(mercado_);
        }

        // GET: Mercado_/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mercado_ = await _context.Mercado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mercado_ == null)
            {
                return NotFound();
            }

            return View(mercado_);
        }

        // POST: Mercado_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mercado_ = await _context.Mercado.FindAsync(id);
            _context.Mercado.Remove(mercado_);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Mercado_Exists(int id)
        {
            return _context.Mercado.Any(e => e.Id == id);
        }
    }
}
