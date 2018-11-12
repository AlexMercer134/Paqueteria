using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Paqueteria.Models;

namespace Paqueteria.Pages.Aplicaciones
{
    public class CreateModel : EstadoNamePageModel
    {
        private readonly Paqueteria.Models.PaqueteriaContext _context;

        public CreateModel(Paqueteria.Models.PaqueteriaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateEstadosDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Aplicacion Aplicacion { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyAplicacion = new Aplicacion();

            if (await TryUpdateModelAsync<Aplicacion>(emptyAplicacion, "aplicacion", s => s.AplicacionID, s => s.NombreApp, s => s.DescripcionApp, s => s.DetalleApp, s => s.StartDate, s => s.FinalDate))
            {
                _context.Aplicacion.Add(emptyAplicacion);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateEstadosDropDownList(_context, emptyAplicacion.EstadoID);
            return Page();
        }
    }
}