using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paqueteria.Models
{
    public class Dependencia
    {
        public int DependenciaID { get; set; }
        [Display(Name = "Nombre")]
        [Required]
        public string NombreDpd { get; set; }
        [Display(Name = "Descripción")]
        [StringLength(100)]
        public string DescripcionDpd { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Registro")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Esperada")]
        [Required]
        public DateTime FinaltDate { get; set; }
        [ForeignKey("FKEstatusDependencia")]
        [Display(Name = "Estatus")]
        [Required]
        public int EstadoID { get; set; }
        
        public Estado Estados { get; set; }
        public ICollection<Relacion> Relacions { get; set; }
    }
}
