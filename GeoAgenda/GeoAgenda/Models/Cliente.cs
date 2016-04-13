using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeoAgenda.Models
{
    [Table("Clientes")]

    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public string RazonSocial { get; set; }
        
        public string NombreContacto { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int RUC  { get; set; }
        public int DV { get; set; }

        public Boolean Estado { get; set; }

        public virtual ICollection<Planificacion> planificacion { get; set; }

        public int IdSucursal { get; set; }
        public virtual Sucursal sucursal { get; set; }
    }
}