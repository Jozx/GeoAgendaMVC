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

            var planificacion = db.Planificaciones.Include(v => v.vehiculo).Include(c => c.cliente);

            return View(planificacion.ToList());
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
            var vehiculo = db.Vehiculos.ToList();
            vehiculo.Add(new Vehiculo { IdVehiculo = 0, Conductor = "Seleccione Conductor" });

            vehiculo = vehiculo.OrderBy(v => v.IdVehiculo).ToList();

            ViewBag.IdVehiculo = new SelectList(vehiculo, "IdVehiculo", "Conductor");

            var cliente = db.Clientes.ToList();
            cliente.Add(new Cliente { IdCliente = 0, RazonSocial = "Seleccione Cliente" });

            cliente = cliente.OrderBy(c => c.IdCliente).ToList();

            ViewBag.IdCliente = new SelectList(cliente, "IdCliente", "RazonSocial");

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
            return View(planificacion);
        }

        // POST: Planificacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPlanificacion,fechaEnvio,horaEnvio")] Planificacion planificacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planificacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
