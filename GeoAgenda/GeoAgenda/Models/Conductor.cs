using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeoAgenda.Models
{
    [Table("Conductores")]
    public class Conductor
    {
        [Key]
        public int IdConductor { get; set; }
        public string Nombre { get; set; }
        public string NroRegistro { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Foto { get; set; }

        public virtual ICollection<Entrega> entrega { get; set; }


    }
}