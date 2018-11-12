using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Paqueteria.Models;

namespace Paqueteria.Pages.Dependencias
{
    public class EditModel : PageModel
    {
        private readonly Paqueteria.Models.PaqueteriaContext _context;

        public EditModel(Paqueteria.Models.PaqueteriaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dependencia Dependencia { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dependencia = await _context.Dependencias
                .Include(d => d.Estados).FirstOrDefaultAsync(m => m.DependenciaID == id);

            if (Dependencia == null)
            {
                return NotFound();
            }
           ViewData["EstadoID"] = new SelectList(_context.Estados, "EstadoID", "EstadoID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Dependencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DependenciaExists(Dependencia.DependenciaID))
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

        private bool DependenciaExists(int id)
        {
            return _context.Dependencias.Any(e => e.DependenciaID == id);
        }
    }
}
