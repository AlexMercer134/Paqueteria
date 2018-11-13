using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Paqueteria.Models;

namespace Paqueteria.Pages.Incidencias
{
    public class EditModel : PageModel
    {
        private readonly Paqueteria.Models.PaqueteriaContext _context;

        public EditModel(Paqueteria.Models.PaqueteriaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Incidencia Incidencia { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Incidencia = await _context.Incidencias
                .Include(i => i.Estados)
                .Include(i => i.Paquete).FirstOrDefaultAsync(m => m.IncidenciaID == id);

            if (Incidencia == null)
            {
                return NotFound();
            }
           ViewData["EstadoID"] = new SelectList(_context.Estados, "EstadoID", "NombreEdo");
           ViewData["PaqueteID"] = new SelectList(_context.Paquetes, "PaqueteID", "NombrePck");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Incidencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncidenciaExists(Incidencia.IncidenciaID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool IncidenciaExists(int id)
        {
            return _context.Incidencias.Any(e => e.IncidenciaID == id);
        }
    }
}
