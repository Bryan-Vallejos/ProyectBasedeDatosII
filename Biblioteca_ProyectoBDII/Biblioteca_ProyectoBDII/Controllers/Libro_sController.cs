using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca_ProyectoBDII.Models;

namespace Biblioteca_ProyectoBDII.Controllers
{
    public class Libro_sController : Controller
    {
        private readonly BibliotecaProyect_BDIIContext _context;

        public Libro_sController(BibliotecaProyect_BDIIContext context)
        {
            _context = context;
        }

        // GET: Libro_s
        public async Task<IActionResult> Index()
        {
            var bibliotecaProyect_BDIIContext = _context.Libros.Include(l => l.IdAutorNavigation).Include(l => l.IdCategoriaNavigation).Include(l => l.IdEditorialNavigation);
            return View(await bibliotecaProyect_BDIIContext.ToListAsync());
        }

        // GET: Libro_s/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Libros == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.IdAutorNavigation)
                .Include(l => l.IdCategoriaNavigation)
                .Include(l => l.IdEditorialNavigation)
                .FirstOrDefaultAsync(m => m.IdLibro == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libro_s/Create
        public IActionResult Create()
        {
            ViewData["IdAutor"] = new SelectList(_context.Autors, "IdAutor", "IdAutor");
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "IdCategoria");
            ViewData["IdEditorial"] = new SelectList(_context.Editorials, "IdEditorial", "IdEditorial");
            return View();
        }

        // POST: Libro_s/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLibro,Titulo,IdAutor,IdCategoria,IdEditorial,Ubicacion,Ejemplares,Estado,FechaCreacion")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAutor"] = new SelectList(_context.Autors, "IdAutor", "IdAutor", libro.IdAutor);
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "IdCategoria", libro.IdCategoria);
            ViewData["IdEditorial"] = new SelectList(_context.Editorials, "IdEditorial", "IdEditorial", libro.IdEditorial);
            return View(libro);
        }

        // GET: Libro_s/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Libros == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            ViewData["IdAutor"] = new SelectList(_context.Autors, "IdAutor", "IdAutor", libro.IdAutor);
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "IdCategoria", libro.IdCategoria);
            ViewData["IdEditorial"] = new SelectList(_context.Editorials, "IdEditorial", "IdEditorial", libro.IdEditorial);
            return View(libro);
        }

        // POST: Libro_s/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLibro,Titulo,IdAutor,IdCategoria,IdEditorial,Ubicacion,Ejemplares,Estado,FechaCreacion")] Libro libro)
        {
            if (id != libro.IdLibro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.IdLibro))
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
            ViewData["IdAutor"] = new SelectList(_context.Autors, "IdAutor", "IdAutor", libro.IdAutor);
            ViewData["IdCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "IdCategoria", libro.IdCategoria);
            ViewData["IdEditorial"] = new SelectList(_context.Editorials, "IdEditorial", "IdEditorial", libro.IdEditorial);
            return View(libro);
        }

        // GET: Libro_s/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Libros == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.IdAutorNavigation)
                .Include(l => l.IdCategoriaNavigation)
                .Include(l => l.IdEditorialNavigation)
                .FirstOrDefaultAsync(m => m.IdLibro == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libro_s/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Libros == null)
            {
                return Problem("Entity set 'BibliotecaProyect_BDIIContext.Libros'  is null.");
            }
            var libro = await _context.Libros.FindAsync(id);
            if (libro != null)
            {
                _context.Libros.Remove(libro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
          return _context.Libros.Any(e => e.IdLibro == id);
        }
    }
}
