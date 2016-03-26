using GeoAgenda.Context;
using GeoAgenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeoAgenda.Controllers
{
    public class VehiculoController : Controller
    {
        GeoAgendaContext db = new GeoAgendaContext();

        // GET: Vehiculo
        public ActionResult Index()
        {
            return View(db.Vehiculos.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Vehiculos.Add(vehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehiculo);
        }
    }
}