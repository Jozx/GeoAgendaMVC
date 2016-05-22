using GeoAgenda.Context;
using GeoAgenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Transactions;
using System.Web.Mvc;


namespace GeoAgenda.Controllers
{
    public class HojaRutaController : Controller
    {
        GeoAgendaContext db = new GeoAgendaContext();

        public ActionResult Create()
        {
            //ViewBag.IdCliente = new SelectList(db.Clientes.ToList(), "IdCliente", "RazonSocial");
            ViewBag.IdConductor = new SelectList(db.Conductores.ToList(), "IdConductor", "Nombre");
          
            var hrd = new HojaRuta();

            hrd.Detalle.Add(new HojaRutaDetalle());
            return View(hrd);
        }

        [HttpPost]
        public ActionResult Create(HojaRuta HojaRuta, string operacion = null)
        {
            ViewBag.IdCliente = new SelectList(db.Clientes.ToList(), "IdCliente", "RazonSocial");

            if (HojaRuta == null)
            {
                HojaRuta = new HojaRuta();
            }

            if (operacion == null)
            {
                if (CrearHojaRuta(HojaRuta))
                {
                    return RedirectToAction("Index");
                }
            }
            else if (operacion =="agregar-detalle")
            {
                HojaRuta.Detalle.Add(new HojaRutaDetalle());
            }


            return View(HojaRuta);
        }

        private bool CrearHojaRuta(HojaRuta HojaRuta)
        {

            if(ModelState.IsValid)
            {
                if(HojaRuta.Detalle != null && HojaRuta.Detalle.Count >0) {

                    using (TransactionScope scope = new TransactionScope())
                    {

                        HojaRuta hr = new HojaRuta();

                        HojaRutaDetalle hrd = new HojaRutaDetalle();

                        hr.IdHojaRuta = 0;
                        
                        hr.IdConductor = HojaRuta.IdConductor;
                        hr.Fecha = HojaRuta.Fecha;
                        db.HojaRuta.Add(hr);

                        db.SaveChanges();

                        foreach(var item in HojaRuta.Detalle)
                        {
                            hrd.IdHojaRuta = hr.IdHojaRuta;
                            hrd.Hora = item.Hora;
                            hrd.Descripcion = item.Descripcion;
                            hrd.IdCliente = item.IdCliente;

                            db.HojaRutaDetalle.Add(hrd);

                            db.SaveChanges();
                        }
                        scope.Complete();
                    }
                    return true;
                }
                else
                {
                    ModelState.AddModelError("", "No se puede guardar la hoja de ruta sin el detalle");
                }
            }
            return false;
        }
    }
}