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
        //public string emailSucursal { get; set; }
     
        public double latitudSucursal { get; set; }

        public double longitudSucursal { get; set; }

        public virtual ICollection<Cliente> cliente { get; set; }

    }
}