using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeoAgenda.Models
{
    [Table("Entregas")]
    public class Entrega
    {
        [Key]
        public int IdEntrega { get; set; }

        public string Carga { get; set; }
        public DateTime fechaEntrega { get; set; }
        public DateTime horaEntrega { get; set; }
        public string latitudEntrega { get; set; }
        public string longitudEntrega { get; set; }

        public virtual ICollection<Conductor> conductor { get; set; }
    }
}