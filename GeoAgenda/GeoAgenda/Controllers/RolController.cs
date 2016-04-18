using GeoAgenda.Models;
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
    }
}