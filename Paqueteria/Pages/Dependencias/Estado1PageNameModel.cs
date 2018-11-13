using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Paqueteria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paqueteria.Pages.Dependencias
{
    public class Estado1NamePageModel : PageModel
    {
        public SelectList Estado1NameSL { get; set; }

        public void PopulateEstadosDropDownList(PaqueteriaContext _context,
            object selectedEstado = null)
        {
            var dependenciasQuery = from d in _context.Estados
                                   orderby d.NombreEdo // Sort by name.
                                   select d;

            Estado1NameSL = new SelectList(dependenciasQuery.AsNoTracking(),
                        "EstadoID", "NombreEdo", selectedEstado);
        }
    }
}
