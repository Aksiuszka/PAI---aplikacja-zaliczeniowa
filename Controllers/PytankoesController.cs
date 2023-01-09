using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using info_2022.Data;
using info_2022.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace info_2022.Controllers
{
    public class PytankoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PytankoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pytankoes
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
              return View(await _context.Pytankos.ToListAsync());
        }

        // GET: Pytankoes/Details/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pytankos == null)
            {
                return NotFound();
            }

            var pytanko = await _context.Pytankos
                .FirstOrDefaultAsync(m => m.IdPytanie == id);
            if (pytanko == null)
            {
                return NotFound();
            }

            return View(pytanko);
        }

        // GET: Pytankoes/Create
        public IActionResult Create()
        {

          
                

            
            
            return View();
        }

        // POST: Pytankoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPytanie,Imie,Adres,Tresc,Odpowiedz")] Pytanko pytanko)
        {
            if (ModelState.IsValid)
            {
                pytanko.Odpowiedz = false;
                _context.Add(pytanko);
                await _context.SaveChangesAsync();
                ViewBag.result = "Dziękujemy za zadanie pytania. Odpowiemy wkrótce";
                return View("Create");
            }
            
            return View(pytanko);
        }

        // GET: Pytankoes/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pytankos == null)
            {
                return NotFound();
            }

            var pytanko = await _context.Pytankos.FindAsync(id);
            if (pytanko == null)
            {
                return NotFound();
            }
            return View(pytanko);
        }

        // POST: Pytankoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPytanie,Imie,Adres,Tresc,Odpowiedz")] Pytanko pytanko)
        {
            if (id != pytanko.IdPytanie)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pytanko);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PytankoExists(pytanko.IdPytanie))
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
            return View(pytanko);
        }

        // GET: Pytankoes/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pytankos == null)
            {
                return NotFound();
            }

            var pytanko = await _context.Pytankos
                .FirstOrDefaultAsync(m => m.IdPytanie == id);
            if (pytanko == null)
            {
                return NotFound();
            }

            return View(pytanko);
        }

        // POST: Pytankoes/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pytankos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Pytankos'  is null.");
            }
            var pytanko = await _context.Pytankos.FindAsync(id);
            if (pytanko != null)
            {
                _context.Pytankos.Remove(pytanko);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PytankoExists(int id)
        {
          return _context.Pytankos.Any(e => e.IdPytanie == id);
        }
    }
}
