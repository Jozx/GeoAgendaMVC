using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GeoAgenda.Context;
using GeoAgenda.Models;

namespace GeoAgenda.Controllers
{
    public class PlanificacionController : Controller
    {
        private GeoAgendaContext db = new GeoAgendaContext();

        // GET: Planificacion
        public ActionResult Index()
        {
            var planificaciones = db.Planificaciones.Include(p => p.cliente).Include(p => p.conductos).Include(p => p.vehiculo);
            return View(planificaciones.ToList());
        }

        // GET: Planificacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planificacion planificacion = db.Planificaciones.Find(id);
            if (planificacion == null)
            {
                return HttpNotFound();
            }
            return View(planificacion);
        }

        // GET: Planificacion/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "RazonSocial");
            ViewBag.IdConductor = new SelectList(db.Conductores, "IdConductor", "Nombre");
            ViewBag.IdVehiculo = new SelectList(db.Vehiculos, "IdVehiculo", "Kilometraje");
            return View();
        }

        // POST: Planificacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Planificacion planificacion)
        {
            if (ModelState.IsValid)
            {
                db.Planificaciones.Add(planificacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "RazonSocial", planificacion.IdCliente);
            ViewBag.IdConductor = new SelectList(db.Conductores, "IdConductor", "Nombre", planificacion.IdConductor);
            ViewBag.IdVehiculo = new SelectList(db.Vehiculos, "IdVehiculo", "Kilometraje", planificacion.IdVehiculo);
            return View(planificacion);
        }

        // GET: Planificacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planificacion planificacion = db.Planificaciones.Find(id);
            if (planificacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "RazonSocial", planificacion.IdCliente);
            ViewBag.IdConductor = new SelectList(db.Conductores, "IdConductor", "Nombre", planificacion.IdConductor);
            ViewBag.IdVehiculo = new SelectList(db.Vehiculos, "IdVehiculo", "Kilometraje", planificacion.IdVehiculo);
            return View(planificacion);
        }

        // POST: Planificacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Planificacion planificacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planificacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "RazonSocial", planificacion.IdCliente);
            ViewBag.IdConductor = new SelectList(db.Conductores, "IdConductor", "Nombre", planificacion.IdConductor);
            ViewBag.IdVehiculo = new SelectList(db.Vehiculos, "IdVehiculo", "Kilometraje", planificacion.IdVehiculo);
            return View(planificacion);
        }

        // GET: Planificacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planificacion planificacion = db.Planificaciones.Find(id);
            if (planificacion == null)
            {
                return HttpNotFound();
            }
            return View(planificacion);
        }

        // POST: Planificacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Planificacion planificacion = db.Planificaciones.Find(id);
            db.Planificaciones.Remove(planificacion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
