using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Paqueteria.Models;

namespace Paqueteria.Pages.Aplicaciones
{
    public class EditModel : EstadoNamePageModel
    {
        private readonly Paqueteria.Models.PaqueteriaContext _context;

        public EditModel(Paqueteria.Models.PaqueteriaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Aplicacion Aplicacion { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Aplicacion = await _context.Aplicacion.Include(c=> c.Estados).FirstOrDefaultAsync(m => m.AplicacionID == id);

            if (Aplicacion == null)
            {
                return NotFound();
            }
            PopulateEstadosDropDownList(_context, Aplicacion.EstadoID);
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var estadoToUpdate = await _context.Aplicacion.FindAsync(id);
            if (await TryUpdateModelAsync<Aplicacion>(estadoToUpdate, "aplicacion", s => s.AplicacionID, s => s.NombreApp, s => s.DescripcionApp, s => s.DetalleApp, s => s.StartDate, s => s.FinalDate))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateEstadosDropDownList(_context, estadoToUpdate.EstadoID);
            return Page();
        }

        private bool AplicacionExists(int id)
        {
            return _context.Aplicacion.Any(e => e.AplicacionID == id);
        }
    }
}
