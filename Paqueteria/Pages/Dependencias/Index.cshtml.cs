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
    public class IndexModel : PageModel
    {
        private readonly Paqueteria.Models.PaqueteriaContext _context;

        public IndexModel(Paqueteria.Models.PaqueteriaContext context)
        {
            _context = context;
        }

        public IList<Dependencia> Dependencia { get;set; }

        public async Task OnGetAsync()
        {
            Dependencia = await _context.Dependencias
                .Include(d => d.Estados).ToListAsync();
        }
    }
}
