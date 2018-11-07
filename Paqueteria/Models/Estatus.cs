using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Paqueteria.Models
{
    public class Estatus
    {
        [Key]
        public int EstatusID { get; set; }
        public string NombreSts { get; set; }
        public string DescripcionSts { get; set; }

        public ICollection<Aplicacion> Aplicaciones { get; set; }
        public ICollection<Paquete> Paquetes { get; set; }
        public ICollection<Dependencia> Dependencias { get; set; }
        public ICollection<Incidencia> Incidencias { get; set; }
    }
}
