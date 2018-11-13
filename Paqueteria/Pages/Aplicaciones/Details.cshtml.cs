using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Paqueteria.Models;

namespace Paqueteria.Pages.Aplicaciones
{
    public class DetailsModel : PageModel
    {
        private readonly Paqueteria.Models.PaqueteriaContext _context;

        public DetailsModel(Paqueteria.Models.PaqueteriaContext context)
        {
            _context = context;
        }

        public Aplicacion Aplicacion { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Aplicacion = await _context.Aplicacion.AsNoTracking().Include(c => c.Estados).FirstOrDefaultAsync(m => m.AplicacionID == id);

            if (Aplicacion == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
