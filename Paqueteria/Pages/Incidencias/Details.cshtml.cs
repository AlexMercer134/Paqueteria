using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Paqueteria.Models;

namespace Paqueteria.Pages.Incidencias
{
    public class DetailsModel : PageModel
    {
        private readonly Paqueteria.Models.PaqueteriaContext _context;

        public DetailsModel(Paqueteria.Models.PaqueteriaContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
