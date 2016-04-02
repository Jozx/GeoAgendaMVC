﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeoAgenda.Models
{
    [Table("Planificaciones")]
    public class Planificacion
    {
        [Key]
        public int IdPlanificacion { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime fechaEnvio { get; set; }

        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime horaEnvio { get; set; }

        //Foraneas
        public int IdVehiculo { get; set; }
        public virtual Vehiculo vehiculo { get; set; }

        public int IdCliente { get; set; }
        public virtual Cliente cliente { get; set; }
    }
}