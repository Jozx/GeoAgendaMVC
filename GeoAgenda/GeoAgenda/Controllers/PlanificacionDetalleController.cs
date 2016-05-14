using GeoAgenda.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeoAgenda.Controllers
{
    public class PlanificacionDetalleController : Controller
    {
        private GeoAgendaContext db = new GeoAgendaContext();
        // GET: PlanificacionDetalle
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Clientes.ToList(), "IdCliente", "RazonSocial");
            return View();
        }
    }
}