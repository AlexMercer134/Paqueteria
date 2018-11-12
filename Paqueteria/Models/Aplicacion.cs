using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;

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
        [ForeignKey("FKEstatusApp")]
        [Required]
        [Display(Name = "Estatus")]
        public int EstadoID { get; set; }

        public ICollection<AplicacionPaquete> AplicacionPaquetes { get; set; }
        public Estado Estados { get; set; }
    }
}
