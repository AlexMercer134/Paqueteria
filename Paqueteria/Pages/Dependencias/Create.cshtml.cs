using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Paqueteria.Models;

namespace Paqueteria.Pages.Dependencias
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
            return Page();
        }

        [BindProperty]
        public Dependencia Dependencia { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Dependencias.Add(Dependencia);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}