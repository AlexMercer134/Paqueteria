using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Paqueteria.Models
{
    public class Paquete
    {
        public int PaqueteID { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        [StringLength(50)]
        public string NombrePck { get; set; }
        [StringLength(100)]
        [Display(Name = "Descripción")]
        public string DescripcionPck { get; set; }
        [StringLength(100)]
        [Display(Name = "Detalle")]
        public string DetallePck { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Registro")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Esperada")]
        [Required]
        public DateTime FinalDate { get; set; }
        [Display(Name = "Estatus")]
        [Required]
        [ForeignKey("FKEstatusPaquete")]
        public int EstadoID { get; set; }

        public Estado Estados { get; set; }
        public ICollection<Relacion> Relacions { get; set; }
        public ICollection<AplicacionPaquete> AplicacionPaquetes { get; set; }
        public ICollection<Incidencia> Incidencias { get; set; }
    }
}
