using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeoAgenda.Models
{
    public class ConductorView
    {
        public int IdConductor { get; set; }
        public string Nombre { get; set; }
        public string NroRegistro { get; set; }

        [DataType(DataType.ImageUrl)]
        public HttpPostedFileBase Foto { get; set; }


        public virtual ICollection<Entrega> entrega { get; set; }
    }
}