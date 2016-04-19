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
    public class EntregaController : Controller
    {
        private GeoAgendaContext db = new GeoAgendaContext();

        // GET: Entrega
        public ActionResult Index()
        {
            var entregas = db.Entregas.Include(e => e.cliente).Include(e => e.conductor);
            return View(entregas.ToList());
        }

        // GET: Entrega/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrega entrega = db.Entregas.Find(id);
            if (entrega == null)
            {
                return HttpNotFound();
            }
            return View(entrega);
        }

        // GET: Entrega/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "RazonSocial");
            ViewBag.IdConductor = new SelectList(db.Conductores, "IdConductor", "Nombre");
            return View();
        }

        // POST: Entrega/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Entrega entrega)
        {
            if (ModelState.IsValid)
            {
                db.Entregas.Add(entrega);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "RazonSocial", entrega.IdCliente);
            ViewBag.IdConductor = new SelectList(db.Conductores, "IdConductor", "Nombre", entrega.IdConductor);
            return View(entrega);
        }

        // GET: Entrega/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrega entrega = db.Entregas.Find(id);
            if (entrega == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "RazonSocial", entrega.IdCliente);
            ViewBag.IdConductor = new SelectList(db.Conductores, "IdConductor", "Nombre", entrega.IdConductor);
            return View(entrega);
        }

        // POST: Entrega/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Entrega entrega)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entrega).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "RazonSocial", entrega.IdCliente);
            ViewBag.IdConductor = new SelectList(db.Conductores, "IdConductor", "Nombre", entrega.IdConductor);
            return View(entrega);
        }

        // GET: Entrega/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrega entrega = db.Entregas.Find(id);
            if (entrega == null)
            {
                return HttpNotFound();
            }
            return View(entrega);
        }

        // POST: Entrega/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entrega entrega = db.Entregas.Find(id);
            db.Entregas.Remove(entrega);
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
