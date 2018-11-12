using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Paqueteria.Models;

namespace Paqueteria.Pages.Incidencias
{
    public class CreateModel : PageModel
    {
        private readonly Paqueteria.Models.PaqueteriaContext _context;

        public CreateModel(Paqueteria.Models.PaqueteriaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["EstadoID"] = new SelectList(_context.Estados, "EstadoID", "EstadoID");
        ViewData["PaqueteID"] = new SelectList(_context.Paquetes, "PaqueteID", "NombrePck");
            return Page();
        }

        [BindProperty]
        public Incidencia Incidencia { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Incidencias.Add(Incidencia);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}