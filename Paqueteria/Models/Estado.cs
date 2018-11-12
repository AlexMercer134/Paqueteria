using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Paqueteria.Models
{
    public class Estado
    {
        [Key]
        public int EstadoID { get; set; }
        public string NombreEdo { get; set; }
        public string DescripcionEdo { get; set; }

        public ICollection<Aplicacion> Aplicaciones { get; set; }
        public ICollection<Paquete> Paquetes { get; set; }
        public ICollection<Dependencia> Dependencias { get; set; }
        public ICollection<Incidencia> Incidencias { get; set; }
    }
}
