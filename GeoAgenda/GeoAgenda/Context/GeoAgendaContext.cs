using GeoAgenda.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GeoAgenda.Context
{
    public class GeoAgendaContext : DbContext
    {
        public GeoAgendaContext()
            : base("DefaultConnection")
        {
        }

        public DbSet <Cliente> Clientes { get; set; }
        public DbSet <Vehiculo> Vehiculos { get; set; }
        public DbSet <Planificacion> Planificaciones { get; set; }
        public DbSet <Conductor> Conductores { get; set; }
        public DbSet <Entrega> Entregas { get; set; }
        public DbSet <Sucursal> Sucursales { get; set; }
        public DbSet <MarcaVehiculo> Marcas { get; set; }
        public DbSet <ModeloVehiculo> Modelos { get; set; }
        public DbSet<PlanificacionDetalle> PlanificacionDetalle { get; set; }
    }
}