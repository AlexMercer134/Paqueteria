using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Paqueteria.Models;

namespace Paqueteria.Pages.Paquetes
{
    public class DeleteModel : PageModel
    {
        private readonly Paqueteria.Models.PaqueteriaContext _context;

        public DeleteModel(Paqueteria.Models.PaqueteriaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Paquete Paquete { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Paquete = await _context.Paquetes
                .Include(p => p.Estados).FirstOrDefaultAsync(m => m.PaqueteID == id);

            if (Paquete == null)
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

            Paquete = await _context.Paquetes.FindAsync(id);

            if (Paquete != null)
            {
                _context.Paquetes.Remove(Paquete);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
