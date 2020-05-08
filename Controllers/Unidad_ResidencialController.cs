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
    public class Unidad_ResidencialController : Controller
    {
        private readonly MercadoContext _context;

        public Unidad_ResidencialController(MercadoContext context)
        {
            _context = context;
        }

        // GET: Unidad_Residencial
        public async Task<IActionResult> Index()
        {
            return View(await _context.Unidad_Residencial.ToListAsync());
        }

        // GET: Unidad_Residencial/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidad_Residencial = await _context.Unidad_Residencial
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unidad_Residencial == null)
            {
                return NotFound();
            }

            return View(unidad_Residencial);
        }

        // GET: Unidad_Residencial/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Unidad_Residencial/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Direccion,telefono,Estado")] Unidad_Residencial unidad_Residencial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidad_Residencial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unidad_Residencial);
        }

        // GET: Unidad_Residencial/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidad_Residencial = await _context.Unidad_Residencial.FindAsync(id);
            if (unidad_Residencial == null)
            {
                return NotFound();
            }
            return View(unidad_Residencial);
        }

        // POST: Unidad_Residencial/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Direccion,telefono,Estado")] Unidad_Residencial unidad_Residencial)
        {
            if (id != unidad_Residencial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidad_Residencial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Unidad_ResidencialExists(unidad_Residencial.Id))
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
            return View(unidad_Residencial);
        }

        // GET: Unidad_Residencial/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidad_Residencial = await _context.Unidad_Residencial
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unidad_Residencial == null)
            {
                return NotFound();
            }

            return View(unidad_Residencial);
        }

        // POST: Unidad_Residencial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unidad_Residencial = await _context.Unidad_Residencial.FindAsync(id);
            _context.Unidad_Residencial.Remove(unidad_Residencial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Unidad_ResidencialExists(int id)
        {
            return _context.Unidad_Residencial.Any(e => e.Id == id);
        }
    }
}
