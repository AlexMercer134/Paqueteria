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
    public class DetailsModel : PageModel
    {
        private readonly Paqueteria.Models.PaqueteriaContext _context;

        public DetailsModel(Paqueteria.Models.PaqueteriaContext context)
        {
            _context = context;
        }

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
    }
}
