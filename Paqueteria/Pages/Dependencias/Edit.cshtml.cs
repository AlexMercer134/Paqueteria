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
    public class EditModel : Estado1NamePageModel
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
            //ViewData["EstadoID"] = new SelectList(_context.Estados, "EstadoID", "EstadoID");
            PopulateEstadosDropDownList(_context, Dependencia.EstadoID);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var dependenciaToUpdate = await _context.Dependencias.FindAsync(id);
            if(await TryUpdateModelAsync<Dependencia>(dependenciaToUpdate, "dependencias", s => s.NombreDpd, s => s.DescripcionDpd, s => s.StartDate, s => s.FinaltDate, s => s.EstadoID))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateEstadosDropDownList(_context, dependenciaToUpdate.EstadoID);
            return Page();
        }

        private bool DependenciaExists(int id)
        {
            return _context.Dependencias.Any(e => e.DependenciaID == id);
        }
    }
}
