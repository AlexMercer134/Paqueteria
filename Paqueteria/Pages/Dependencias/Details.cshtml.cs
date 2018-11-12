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
    public class DetailsModel : PageModel
    {
        private readonly Paqueteria.Models.PaqueteriaContext _context;

        public DetailsModel(Paqueteria.Models.PaqueteriaContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
