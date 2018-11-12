using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using Paqueteria.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Paqueteria.Pages.Aplicaciones
{
    public class EstadoNamePageModel: PageModel
    {
        public SelectList EstadoNameSL { get; set; }

        public void PopulateEstadosDropDownList(PaqueteriaContext _context,
            object selectedEstado = null)
        {
            var departmentsQuery = from d in _context.Estados
                                   orderby d.NombreEdo // Sort by name.
                                   select d;

            EstadoNameSL = new SelectList(departmentsQuery.AsNoTracking(),
                        "EstadoID", "NombreEdo", selectedEstado);
        }
    }
}
