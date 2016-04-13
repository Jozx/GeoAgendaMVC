using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeoAgenda.Models
{
    [Table("Sucursales")]
    public class Sucursal
    {
        [Key]
        public int IdSucursal { get; set; }
        public string Direccion { get; set; }
        public string contactoSucursal { get; set; }
        public string telefonoSucursal { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
    }
}