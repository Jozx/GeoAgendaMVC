using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeoAgenda.Models
{
    public class PlanificacionDetalle
    {
        [Key]
        public int IdPlanificacionDetalle { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime hora { get; set; }

        //public int IdCliente { get; set; }
        //public virtual Cliente cliente { get; set; }
    }
}