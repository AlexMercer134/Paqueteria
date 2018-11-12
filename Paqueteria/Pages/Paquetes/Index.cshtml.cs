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
    public class IndexModel : PageModel
    {
        private readonly Paqueteria.Models.PaqueteriaContext _context;

        public IndexModel(Paqueteria.Models.PaqueteriaContext context)
        {
            _context = context;
        }

        public IList<Paquete> Paquete { get;set; }

        public async Task OnGetAsync()
        {
            Paquete = await _context.Paquetes
                .Include(p => p.Estados).ToListAsync();
        }
    }
}
