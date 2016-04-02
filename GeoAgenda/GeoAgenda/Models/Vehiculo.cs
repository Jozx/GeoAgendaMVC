using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeoAgenda.Models
{
    [Table("Vehiculos")]
    public class Vehiculo
    {
        [Key]
        public int IdVehiculo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string FechaFabricacion { get; set; }
        public string Kilometraje { get; set; }
        public string Conductor { get; set; }

        public string latitudBase { get; set; }

        public string longitudBase { get; set; }
    }
}