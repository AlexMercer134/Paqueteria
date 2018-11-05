using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Paqueteria.Models
{
    public class PaqueteriaContext : DbContext
    {
        public PaqueteriaContext (DbContextOptions<PaqueteriaContext> options)
            : base(options)
        {
        }

        public DbSet<Paqueteria.Models.Aplicacion> Aplicacion { get; set; }
    }
}
