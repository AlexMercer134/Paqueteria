using System;
using System.Collections.Generic;
using System.Linq;
using Paqueteria.Models;
using System.Threading.Tasks;

namespace Paqueteria.Data
{
    public class DbInitializer
    {
        public static void Initialize(PaqueteriaContext context)
        {
            if (context.Aplicacion.Any())
            {
                return;
            }
            var estatus = new Estatus[]
            {
                new Estatus{NombreSts = "Completado",DescripcionSts="Se termino el trabajo"},
                new Estatus{NombreSts="Reciente", DescripcionSts="Se acaba de subir"},
                new Estatus{NombreSts = "Cancelado", DescripcionSts ="Se cancela el proceso"},
                new Estatus{NombreSts = "Detenido", DescripcionSts= "Se encuentra en alto la instalación"},
                new Estatus{NombreSts = "En revisión", DescripcionSts="Se ha completado y esta por valorarse"},
                new Estatus{NombreSts="Liberado", DescripcionSts="Se ha finalizado el proceso con exito"},
                new Estatus {NombreSts="En Pruebas", DescripcionSts="Se ejecutan pruebas de la funcionalidad"}
            };
            var aplicacion = new Aplicacion[]
            {
                new Aplicacion{ NombreApp ="CrediSys", DescripcionApp="Sistema de Gestión de Clientes", DetalleApp="Sistema que permite el CRUD de los clientes",StartDate=DateTime.Parse("01-10-1993"),FinalDate=DateTime.Parse("19-10-1994"),EstatusID = 2},
                new Aplicacion{ NombreApp ="Xportal", DescripcionApp="Movimientos del cliente", DetalleApp="Gestor de movimientos del cliente",StartDate=DateTime.Parse("01-10-2000"),FinalDate=DateTime.Parse("19-10-2018"),EstatusID = 1}
            };
            foreach (Aplicacion a in aplicacion)
            {
                context.Aplicacion.Add(a);
            }
            context.SaveChanges();

            var paquete = new Paquete[]
            {
                new Paquete {NombrePck="DirectX",DescripcionPck="Manejo de Graficos",DetallePck="Apoyo a graficos visuales",StartDate= DateTime.Parse("20-02-2018"),FinalDate = DateTime.Parse("22-02-2018"),EstatusID = 4 },
                new Paquete {NombrePck="Cmd",DescripcionPck="Comandos Modificatorios",DetallePck="Ventana de comandos en línea",StartDate= DateTime.Parse("10-04-2018"),FinalDate = DateTime.Parse("12-04-2018"),EstatusID =5 }
            };
            foreach (Paquete p in paquete)
            {
                context.Paquete.Add(p);
            }
            context.SaveChanges();

            var dependencia = new Dependencia[]
            {
                new Dependencia {NombreDpd = "VisualBasic6.0",DescripcionDpd="Compilador",StartDate=DateTime.Parse("20-05-2017"),FinaltDate=DateTime.Parse("25-06-2017"),EstatusID=3},
                new Dependencia { NombreDpd= "AvtiveControl",DescripcionDpd="Manejador de Eventos", StartDate=DateTime.Parse("30-04-2016"),FinaltDate=DateTime.Parse("13-05-2016"),EstatusID=2 }
            };
            foreach (Dependencia d in dependencia)
            {
                context.Dependencia.Add(d);
            }
            context.SaveChanges();
            var incidencia = new Incidencia[]
            {
                new Incidencia {NombreIc= "Error Actualizando",DescripcionIc="Se genero error al actualizara la ultima versión",PaqueteID=1,StartDate=DateTime.Parse("11-09-2011"),FinaltDate=DateTime.Parse("13-09-2011"),EstatusID=1},
                new Incidencia {NombreIc= "Versión no compatible", DescripcionIc = "Se requiere actualizar librerias", PaqueteID = 2,StartDate=DateTime.Parse("14-04-2001"),FinaltDate=DateTime.Parse("15-04-2001"),EstatusID=3}
            };
            foreach (Incidencia i in incidencia)
            {
                context.Incidencia.Add(i);
            }
            context.SaveChanges();
            var appPaquete = new AplicacionPaquete[]
            {
                new AplicacionPaquete{AplicacionID=1,PaqueteID=2},
                new AplicacionPaquete{AplicacionID=2,PaqueteID=1}
            };
            foreach (AplicacionPaquete ap in appPaquete)
            {
                context.AplicacionPaquete.Add(ap);
            }
            context.SaveChanges();
            var relacion = new Relacion[]
            {
                new Relacion {PaqueteID = 1,DependenciaID=2},
                new Relacion {PaqueteID = 2,DependenciaID=1}
            };
            foreach (Relacion r in relacion)
            {
                context.Relacion.Add(r);
            }
            context.SaveChanges();

        }
    }
}
