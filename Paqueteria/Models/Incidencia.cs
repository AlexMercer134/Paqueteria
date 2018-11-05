using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Paqueteria.Models
{
    public class Incidencia
    {
        public int IncidenciaID { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        [StringLength(50)]
        public string NombreIc { get; set; }
        [Display(Name = "Descripción")]
        [Required]
        public string DescripcionIc { get; set; }
        [Display(Name = "Dependencia")]
        [Required]
        public int PaqueteID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Registro")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Esperada")]
        public DateTime FinaltDate { get; set; }
        public int EstatusID { get; set; }
        
        public Paquete Paquete { get; set; }
    }
}
