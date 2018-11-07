using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Paqueteria.Models
{
    public class Relacion
    {
        public int PaqueteID { get; set; }
        public int DependenciaID { get; set; }
        public Paquete Paquete { get; set; }
        public Dependencia Dependencia { get; set; }
    }
}
