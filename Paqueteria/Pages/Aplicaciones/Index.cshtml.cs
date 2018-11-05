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
    public class IndexModel : PageModel
    {
        private readonly Paqueteria.Models.PaqueteriaContext _context;

        public IndexModel(Paqueteria.Models.PaqueteriaContext context)
        {
            _context = context;
        }

        public IList<Aplicacion> Aplicacion { get;set; }

        public async Task OnGetAsync()
        {
            Aplicacion = await _context.Aplicacion.ToListAsync();
        }
    }
}
