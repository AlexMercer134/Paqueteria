using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paqueteria.Models
{
    public class Estatus
    {
        public int EstatusID { get; set; }
        public string NombreSts { get; set; }
        public string DescripcionSts { get; set; }

        public ICollection<Aplicacion> Aplicaciones { get; set; }
    }
}
