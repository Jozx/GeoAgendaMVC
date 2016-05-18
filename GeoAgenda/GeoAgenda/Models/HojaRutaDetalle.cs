using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeoAgenda.Models
{
    public class HojaRutaDetalle
    {
        [Key]
        public int IdHojaRutaDetalle { get; set; }

        public int IdHojaRuta { get; set; }

        public string Descripcion { get; set; }

        [DisplayFormat(DataFormatString = @"{0:hh\-mm}", ApplyFormatInEditMode = true)]
        public TimeSpan Hora { get; set; }
    }
}