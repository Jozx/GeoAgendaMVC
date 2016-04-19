using GeoAgenda.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeoAgenda.Controllers
{
    public class RolController : Controller
    {
        ApplicationDbContext context;

        public RolController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Rol
        public ActionResult Index()
        {
            var Roles = context.Roles.ToList();

            return View(Roles);
        }

        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        [HttpPost]
        public ActionResult Create(IdentityRole Rol)
        {

            //[Authorize(Users ="jose,mmm")];

            if (User.IsInRole("ADMINISTRADOR"))
            {
                context.Roles.Add(Rol);
                context.SaveChanges();

            }
            else
            {
                ViewBag.Error = "No pose autorizacion";
                return View(Rol);
            }
            return RedirectToAction("Index");
        }

    }
}