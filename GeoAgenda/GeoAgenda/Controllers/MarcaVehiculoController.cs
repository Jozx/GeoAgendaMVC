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
    public class MarcaVehiculoController : Controller
    {
        private GeoAgendaContext db = new GeoAgendaContext();

        // GET: MarcaVehiculo
        public ActionResult Index()
        {
            var marcas = db.Marcas.Include(m => m.modelo);
            return View(marcas.ToList());
        }

        // GET: MarcaVehiculo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarcaVehiculo marcaVehiculo = db.Marcas.Find(id);
            if (marcaVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(marcaVehiculo);
        }

        // GET: MarcaVehiculo/Create
        public ActionResult Create()
        {
            ViewBag.IdModelo = new SelectList(db.Modelos, "IdModelo", "NombreModelo");
            return View();
        }

        // POST: MarcaVehiculo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MarcaVehiculo marcaVehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Marcas.Add(marcaVehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdModelo = new SelectList(db.Modelos, "IdModelo", "NombreModelo", marcaVehiculo.IdModelo);
            return View(marcaVehiculo);
        }

        // GET: MarcaVehiculo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarcaVehiculo marcaVehiculo = db.Marcas.Find(id);
            if (marcaVehiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdModelo = new SelectList(db.Modelos, "IdModelo", "NombreModelo", marcaVehiculo.IdModelo);
            return View(marcaVehiculo);
        }

        // POST: MarcaVehiculo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MarcaVehiculo marcaVehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marcaVehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdModelo = new SelectList(db.Modelos, "IdModelo", "NombreModelo", marcaVehiculo.IdModelo);
            return View(marcaVehiculo);
        }

        // GET: MarcaVehiculo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarcaVehiculo marcaVehiculo = db.Marcas.Find(id);
            if (marcaVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(marcaVehiculo);
        }

        // POST: MarcaVehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MarcaVehiculo marcaVehiculo = db.Marcas.Find(id);
            db.Marcas.Remove(marcaVehiculo);
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
