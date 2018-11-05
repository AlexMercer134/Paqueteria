using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Paqueteria.Models
{
    public class Aplicacion
    {
        public int AplicacionID { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        [StringLength(50)]
        public string NombreApp { get; set; }
        [StringLength(100)]
        [Display(Name = "Descripción")]
        public string DescripcionApp { get; set; }
        [StringLength(100)]
        [Display(Name = "Detalle")]
        public string DetalleApp { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Registro")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Publicación")]
        public DateTime FinalDate { get; set; }
        [Display(Name = "Estatus")]
        public int EstatusID { get; set; }

        public ICollection<AplicacionPaquete> AplicacionPaquetes { get; set; }
        public Estatus Estatus { get; set; }
    }
}
