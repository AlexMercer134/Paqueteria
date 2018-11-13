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
    public class CreateModel : Estado1NamePageModel
    {
        private readonly Paqueteria.Models.PaqueteriaContext _context;

        public CreateModel(Paqueteria.Models.PaqueteriaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateEstadosDropDownList(_context);
            //ViewData["EstadoID"] = new SelectList(_context.Estados, "EstadoID", "EstadoID");
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
            var emptyDependencia = new Dependencia();

            if (await TryUpdateModelAsync<Dependencia>(emptyDependencia, "dependencias", s=>s.NombreDpd,s=>s.DescripcionDpd,s => s.StartDate, s => s.FinaltDate, s => s.EstadoID))
            {
                _context.Dependencias.Add(emptyDependencia);//
                await _context.SaveChangesAsync();//
                return RedirectToPage("./Index");//
            }
            PopulateEstadosDropDownList(_context, emptyDependencia.EstadoID);
            return Page();
        }
    }
}