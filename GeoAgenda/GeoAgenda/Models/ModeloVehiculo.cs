using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeoAgenda.Models
{
    [Table("Modelos")]
    public class ModeloVehiculo
    {
        [Key]
        public int IdModelo { get; set; }
        public string NombreModelo { get; set; }

        public virtual ICollection<MarcaVehiculo> marca { get; set; }
    }
}