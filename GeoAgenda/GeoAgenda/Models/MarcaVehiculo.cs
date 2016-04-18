using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeoAgenda.Models
{
    [Table("Marcas")]
    public class MarcaVehiculo
    {
        [Key]
        public int IdMarca { get; set; }
        public string NombreMarca { get; set; }

        public int IdModelo { get; set; }
        public virtual ModeloVehiculo modelo { get; set; }

        public virtual ICollection<Vehiculo> vehiculo { get; set; }
    }
}