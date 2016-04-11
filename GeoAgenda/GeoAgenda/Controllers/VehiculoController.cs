﻿using System;
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
    public class VehiculoController : Controller
    {
        private GeoAgendaContext db = new GeoAgendaContext();

        // GET: Vehiculo
        public ActionResult Index()
        {
            var vehiculos = db.Vehiculos.Include(v => v.conductor);
            return View(vehiculos.ToList());
        }

        // GET: Vehiculo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.Vehiculos.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // GET: Vehiculo/Create
        public ActionResult Create()
        {
            ViewBag.IdConductor = new SelectList(db.Conductors, "IdConductor", "Nombre");
            return View();
        }

        // POST: Vehiculo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVehiculo,Marca,Modelo,FechaFabricacion,Kilometraje,latitudBase,longitudBase,IdConductor")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Vehiculos.Add(vehiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdConductor = new SelectList(db.Conductors, "IdConductor", "Nombre", vehiculo.IdConductor);
            return View(vehiculo);
        }

        // GET: Vehiculo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.Vehiculos.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdConductor = new SelectList(db.Conductors, "IdConductor", "Nombre", vehiculo.IdConductor);
            return View(vehiculo);
        }

        // POST: Vehiculo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVehiculo,Marca,Modelo,FechaFabricacion,Kilometraje,latitudBase,longitudBase,IdConductor")] Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdConductor = new SelectList(db.Conductors, "IdConductor", "Nombre", vehiculo.IdConductor);
            return View(vehiculo);
        }

        // GET: Vehiculo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehiculo vehiculo = db.Vehiculos.Find(id);
            if (vehiculo == null)
            {
                return HttpNotFound();
            }
            return View(vehiculo);
        }

        // POST: Vehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehiculo vehiculo = db.Vehiculos.Find(id);
            db.Vehiculos.Remove(vehiculo);
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
