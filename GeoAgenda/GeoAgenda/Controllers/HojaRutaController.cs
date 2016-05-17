using GeoAgenda.Context;
using GeoAgenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeoAgenda.Controllers
{
    public class HojaRutaController : Controller
    {
        GeoAgendaContext db = new GeoAgendaContext();

        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Clientes.ToList(), "IdCliente", "RazonSocial");
            ViewBag.IdConductor = new SelectList(db.Conductores.ToList(), "IdConductor", "Nombre");

            return View();
        }

        [HttpPost]
        public ActionResult Create(HojaRuta HojaRuta, string operacion = null)
        {

            return View(HojaRuta);
        }
    }
}