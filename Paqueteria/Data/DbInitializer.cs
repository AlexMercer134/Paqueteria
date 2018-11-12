using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paqueteria.Models
{
    public class DbInitializer
    {
        public static void Initialize(PaqueteriaContext context)
        {
            if (context.Estados.Any())
            {
                return;
            }
            var estado = new Estado[]
            {
                new Estado{NombreEdo = "Completado",DescripcionEdo="Se termino el trabajo"},
                new Estado{NombreEdo="Reciente", DescripcionEdo="Se acaba de subir"},
                new Estado{NombreEdo = "Cancelado", DescripcionEdo ="Se cancela el proceso"},
                new Estado{NombreEdo = "Detenido", DescripcionEdo= "Se encuentra en alto la instalación"},
                new Estado{NombreEdo = "En revisión", DescripcionEdo="Se ha completado y esta por valorarse"},
                new Estado{NombreEdo="Liberado", DescripcionEdo="Se ha finalizado el proceso con exito"},
                new Estado{NombreEdo="En Pruebas", DescripcionEdo="Se ejecutan pruebas de la funcionalidad"}
            };
            foreach (Estado a in estado)
            {
                context.Estados.Add(a);
            }
            context.SaveChanges();
            var aplicacion = new Aplicacion[]
            {
                new Aplicacion{ NombreApp ="CrediSys", DescripcionApp="Sistema de Gestión de Clientes", DetalleApp="Sistema que permite el CRUD de los clientes",StartDate=DateTime.Parse("01-10-1993"),FinalDate=DateTime.Parse("19-10-1994"),EstadoID = estado.Single(s => s.NombreEdo == "Reciente").EstadoID},
                new Aplicacion{ NombreApp ="Xportal", DescripcionApp="Movimientos del cliente", DetalleApp="Gestor de movimientos del cliente",StartDate=DateTime.Parse("01-10-2000"),FinalDate=DateTime.Parse("19-10-2018"),EstadoID = estado.Single(s => s.NombreEdo == "Completado").EstadoID}
            };
            foreach (Aplicacion a in aplicacion)
            {
                context.Aplicacion.Add(a);
            }
            context.SaveChanges();

            var paquete = new Paquete[]
            {
                new Paquete {NombrePck="DirectX",DescripcionPck="Manejo de Graficos",DetallePck="Apoyo a graficos visuales",StartDate= DateTime.Parse("20-02-2018"),FinalDate = DateTime.Parse("22-02-2018"),EstadoID = estado.Single(s => s.NombreEdo == "Detenido").EstadoID },
                new Paquete {NombrePck="Cmd",DescripcionPck="Comandos Modificatorios",DetallePck="Ventana de comandos en línea",StartDate= DateTime.Parse("10-04-2018"),FinalDate = DateTime.Parse("12-04-2018"),EstadoID = estado.Single(s => s.NombreEdo == "En revisión").EstadoID }
            };
            foreach (Paquete p in paquete)
            {
                context.Paquetes.Add(p);
            }
            context.SaveChanges();

            var dependencia = new Dependencia[]
            {
                new Dependencia {NombreDpd = "VisualBasic6.0",DescripcionDpd="Compilador",StartDate=DateTime.Parse("20-05-2017"),FinaltDate=DateTime.Parse("25-06-2017"),EstadoID= estado.Single(s => s.NombreEdo == "Cancelado").EstadoID},
                new Dependencia { NombreDpd= "AcvtiveControl",DescripcionDpd="Manejador de Eventos", StartDate=DateTime.Parse("30-04-2016"),FinaltDate=DateTime.Parse("13-05-2016"),EstadoID= estado.Single(s => s.NombreEdo == "Reciente").EstadoID }
            };
            foreach (Dependencia d in dependencia)
            {
                context.Dependencias.Add(d);
            }
            context.SaveChanges();
            var incidencia = new Incidencia[]
            {
                new Incidencia {NombreIc= "Error Actualizando",DescripcionIc="Se genero error al actualizara la ultima versión",PaqueteID= paquete.Single(s=>s.NombrePck=="DirectX").PaqueteID,StartDate=DateTime.Parse("11-09-2011"),FinaltDate=DateTime.Parse("13-09-2011"),EstadoID= estado.Single(s => s.NombreEdo == "Completado").EstadoID},
                new Incidencia {NombreIc= "Versión no compatible", DescripcionIc = "Se requiere actualizar librerias", PaqueteID = paquete.Single(s=>s.NombrePck=="Cmd").PaqueteID,StartDate=DateTime.Parse("14-04-2001"),FinaltDate=DateTime.Parse("15-04-2001"),EstadoID= estado.Single(s => s.NombreEdo == "Cancelado").EstadoID}
            };
            foreach (Incidencia i in incidencia)
            {
                context.Incidencias.Add(i);
            }
            context.SaveChanges();
            var appPaquete = new AplicacionPaquete[]
            {
                new AplicacionPaquete{AplicacionID= aplicacion.Single(s => s.NombreApp == "CrediSys").AplicacionID ,PaqueteID= paquete.Single(s=> s.NombrePck == "Cmd").PaqueteID},
                new AplicacionPaquete{AplicacionID=aplicacion.Single(s => s.NombreApp == "Xportal").AplicacionID ,PaqueteID= paquete.Single(s=> s.NombrePck == "DirectX").PaqueteID}
            };
            foreach (AplicacionPaquete ap in appPaquete)
            {
                context.AplicacionPaquetes.Add(ap);
            }
            context.SaveChanges();
            var relacion = new Relacion[]
            {
                new Relacion {PaqueteID = paquete.Single(s=>s.NombrePck=="DirectX").PaqueteID,DependenciaID= dependencia.Single(s=>s.NombreDpd =="ActiveControl").DependenciaID},
                new Relacion {PaqueteID = paquete.Single(s=>s.NombrePck=="Cmd").PaqueteID,DependenciaID= dependencia.Single(s=>s.NombreDpd =="VisualBasic6.0").DependenciaID}
            };
            foreach (Relacion r in relacion)
            {
                context.Relacions.Add(r);
            }
            context.SaveChanges();

        }
    }
}
