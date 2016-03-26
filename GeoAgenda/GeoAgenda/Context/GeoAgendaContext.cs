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

    }
}