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
    public class ModeloVehiculoController : Controller
    {
        private GeoAgendaContext db = new GeoAgendaContext();

        // GET: ModeloVehiculo
        public ActionResult Index()
        {
            return View(db.Modelos.ToList());
        }

        // GET: ModeloVehiculo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModeloVehiculo modeloVehiculo = db.Modelos.Find(id);
            if (modeloVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(modeloVehiculo);
        }

        // GET: ModeloVehiculo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModeloVehiculo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( ModeloVehiculo modeloVehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Modelos.Add(modeloVehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modeloVehiculo);
        }

        // GET: ModeloVehiculo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModeloVehiculo modeloVehiculo = db.Modelos.Find(id);
            if (modeloVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(modeloVehiculo);
        }

        // POST: ModeloVehiculo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ModeloVehiculo modeloVehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modeloVehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modeloVehiculo);
        }

        // GET: ModeloVehiculo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModeloVehiculo modeloVehiculo = db.Modelos.Find(id);
            if (modeloVehiculo == null)
            {
                return HttpNotFound();
            }
            return View(modeloVehiculo);
        }

        // POST: ModeloVehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModeloVehiculo modeloVehiculo = db.Modelos.Find(id);
            db.Modelos.Remove(modeloVehiculo);
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
