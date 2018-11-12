using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paqueteria.Models
{
    public class AplicacionPaquete
    {
        public int PaqueteID { get; set; }
        public int AplicacionID { get; set; }
        public Paquete Paquete { get; set; }
        public Aplicacion Aplicacion{ get; set; }
    }
}

