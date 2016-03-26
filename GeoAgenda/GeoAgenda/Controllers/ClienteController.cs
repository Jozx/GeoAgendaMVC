using GeoAgenda.Context;
using GeoAgenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeoAgenda.Controllers
{
    public class ClienteController : Controller
    {

        GeoAgendaContext db = new GeoAgendaContext();

        // GET: Cliente
        public ActionResult Index()
        {
            return View(db.Clientes.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        public ActionResult Details(int? Id)
        {
            //if (Id == null)
            //{
            //    return HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            var cliente = db.Clientes.Find(Id);

            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }

        public ActionResult Edit(int? Id)
        {
            //if (Id == null)
            //{
            //    return HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            var cliente = db.Clientes.Find(Id);

            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        public ActionResult Delete(int? Id)
        {
            //if (Id == null)
            //{
            //    return HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            var cliente = db.Clientes.Find(Id);

            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        public ActionResult Delete(int Id, Cliente cliente)
        {

            cliente = db.Clientes.Find(Id);

            if (ModelState.IsValid)
            {
                db.Clientes.Remove(cliente);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db.Clientes != null)
                {
                    db.Dispose();
                    db.Clientes = null;
                }


            }

            base.Dispose(disposing);
        }
    }
}