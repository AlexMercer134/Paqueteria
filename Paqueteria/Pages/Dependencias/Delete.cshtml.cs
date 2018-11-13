using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Paqueteria.Models;

namespace Paqueteria.Pages.Dependencias
{
    public class DeleteModel : PageModel
    {
        private readonly Paqueteria.Models.PaqueteriaContext _context;

        public DeleteModel(Paqueteria.Models.PaqueteriaContext context)
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

            Dependencia = await _context.Dependencias.AsNoTracking()
                .Include(d => d.Estados).FirstOrDefaultAsync(m => m.DependenciaID == id);

            if (Dependencia == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dependencia = await _context.Dependencias.AsNoTracking().FirstOrDefaultAsync(m => m.DependenciaID == id);

            if (Dependencia != null)
            {
                _context.Dependencias.Remove(Dependencia);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
