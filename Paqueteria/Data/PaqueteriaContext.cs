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
        public DbSet<AplicacionPaquete> AplicacionPaquetes { get; set; }
        public DbSet<Dependencia> Dependencias { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Incidencia> Incidencias { get; set; }
        public DbSet<Paquete> Paquetes { get; set; }
        public DbSet<Relacion> Relacions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aplicacion>().ToTable("Aplicacion");
            modelBuilder.Entity<AplicacionPaquete>().ToTable("AplicacionPaquete");
            modelBuilder.Entity<Dependencia>().ToTable("Dependencia");
            modelBuilder.Entity<Estado>().ToTable("Estados");
            modelBuilder.Entity<Incidencia>().ToTable("Incidecia");
            modelBuilder.Entity<Paquete>().ToTable("Paquete");
            modelBuilder.Entity<Relacion>().ToTable("Relacion");

            modelBuilder.Entity<Relacion>().HasKey(r => new { r.PaqueteID, r.DependenciaID });
            modelBuilder.Entity<AplicacionPaquete>().HasKey(a => new { a.AplicacionID, a.PaqueteID });
        }
    }
}
