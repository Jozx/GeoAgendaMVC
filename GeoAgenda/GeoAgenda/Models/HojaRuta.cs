using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeoAgenda.Models
{
    public class HojaRuta
    {
        [Key]
        public int IdHojaRuta { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        public int IdConductor { get; set; }
        public virtual Conductor conductos { get; set; }

        public virtual ICollection<HojaRutaDetalle> Detalle { get; set; }

        public HojaRuta()
        {
            this.Detalle = new HashSet<HojaRutaDetalle>();
        }
    }
}