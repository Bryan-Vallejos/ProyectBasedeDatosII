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
    public class PersonasController : Controller
    {
        private readonly BibliotecaProyect_BDIIContext _context;

        public PersonasController(BibliotecaProyect_BDIIContext context)
        {
            _context = context;
        }

        // GET: Personas
        public async Task<IActionResult> Index()
        {
            var bibliotecaProyect_BDIIContext = _context.Personas.Include(p => p.IdTipoPersonaNavigation).Include(p => p.IdUsuarioNavigation);
            return View(await bibliotecaProyect_BDIIContext.ToListAsync());
        }

        // GET: Personas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Personas == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas
                .Include(p => p.IdTipoPersonaNavigation)
                .Include(p => p.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdPersona == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // GET: Personas/Create
        public IActionResult Create()
        {
            ViewData["IdTipoPersona"] = new SelectList(_context.TipoPersonas, "IdTipoPersona", "IdTipoPersona");
            ViewData["IdUsuario"] = new SelectList(_context.Registros, "IdUsuario", "IdUsuario");
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPersona,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Correo,Codigo,IdTipoPersona,Estado,IdUsuario,FechaCreacion")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoPersona"] = new SelectList(_context.TipoPersonas, "IdTipoPersona", "IdTipoPersona", persona.IdTipoPersona);
            ViewData["IdUsuario"] = new SelectList(_context.Registros, "IdUsuario", "IdUsuario", persona.IdUsuario);
            return View(persona);
        }

        // GET: Personas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Personas == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            ViewData["IdTipoPersona"] = new SelectList(_context.TipoPersonas, "IdTipoPersona", "IdTipoPersona", persona.IdTipoPersona);
            ViewData["IdUsuario"] = new SelectList(_context.Registros, "IdUsuario", "IdUsuario", persona.IdUsuario);
            return View(persona);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPersona,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,Correo,Codigo,IdTipoPersona,Estado,IdUsuario,FechaCreacion")] Persona persona)
        {
            if (id != persona.IdPersona)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaExists(persona.IdPersona))
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
            ViewData["IdTipoPersona"] = new SelectList(_context.TipoPersonas, "IdTipoPersona", "IdTipoPersona", persona.IdTipoPersona);
            ViewData["IdUsuario"] = new SelectList(_context.Registros, "IdUsuario", "IdUsuario", persona.IdUsuario);
            return View(persona);
        }

        // GET: Personas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Personas == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas
                .Include(p => p.IdTipoPersonaNavigation)
                .Include(p => p.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdPersona == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Personas == null)
            {
                return Problem("Entity set 'BibliotecaProyect_BDIIContext.Personas'  is null.");
            }
            var persona = await _context.Personas.FindAsync(id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaExists(int id)
        {
          return _context.Personas.Any(e => e.IdPersona == id);
        }
    }
}
