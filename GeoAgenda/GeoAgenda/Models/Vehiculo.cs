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
        public string Kilometraje { get; set; }
        public string latitudBase { get; set; }
        public string longitudBase { get; set; }

        public int IdMarca { get; set; }
        public virtual MarcaVehiculo marca { get; set; }

        public virtual ICollection<Planificacion> planificacion { get; set; }
    }
}