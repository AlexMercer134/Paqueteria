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
    public class EditModel : PageModel
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

            Aplicacion = await _context.Aplicacion.FirstOrDefaultAsync(m => m.AplicacionID == id);

            if (Aplicacion == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Aplicacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AplicacionExists(Aplicacion.AplicacionID))
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

        private bool AplicacionExists(int id)
        {
            return _context.Aplicacion.Any(e => e.AplicacionID == id);
        }
    }
}
