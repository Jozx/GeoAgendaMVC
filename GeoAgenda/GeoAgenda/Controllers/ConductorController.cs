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
using System.IO;

namespace GeoAgenda.Controllers
{
    public class ConductorController : Controller
    {
        private GeoAgendaContext db = new GeoAgendaContext();

        // GET: Conductor
        public ActionResult Index()
        {
            return View(db.Conductores.ToList());
        }

        // GET: Conductor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conductor conductor = db.Conductores.Find(id);
            if (conductor == null)
            {
                return HttpNotFound();
            }
            return View(conductor);
        }

        // GET: Conductor/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConductorView conductorview)
        {
            if (ModelState.IsValid)
            {
                string path = string.Empty;
                string imag = string.Empty;

                if (conductorview.Foto != null)
                {
                    imag = Path.GetFileName(conductorview.Foto.FileName);
                    path = Path.Combine(Server.MapPath("~/Content/Fotos"), imag);
                    conductorview.Foto.SaveAs(path);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        conductorview.Foto.InputStream.CopyTo(ms);
                        byte[] array = ms.GetBuffer();
                    }

                }

                var conductor = new Conductor
                {
                    Nombre = conductorview.Nombre,
                    NroRegistro = conductorview.NroRegistro,
                    entrega = conductorview.entrega,

                    Foto = imag == string.Empty ? string.Empty : string.Format("~/Content/Fotos/{0}", imag),

                };

                try
                {
                    db.Conductores.Add(conductor);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {


                }
            }

            return View(conductorview);
        }

        // GET: Conductor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conductor conductor = db.Conductores.Find(id);
            if (conductor == null)
            {
                return HttpNotFound();
            }
            return View(conductor);
        }

        // POST: Conductor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Conductor conductor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conductor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(conductor);
        }

        // GET: Conductor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conductor conductor = db.Conductores.Find(id);
            if (conductor == null)
            {
                return HttpNotFound();
            }
            return View(conductor);
        }

        // POST: Conductor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Conductor conductor = db.Conductores.Find(id);
            db.Conductores.Remove(conductor);
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
