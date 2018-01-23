using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SATI.Services.Services;
namespace WebSATI.Controllers
{
    public class HomeController : Controller
    {
        private ModuloService _moduloServices = new ModuloService();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Menu()
        {
            ViewData["ListModulos"] = _moduloServices.ListadoModulosUsuarios("4","");
            return PartialView();
        }

    }
}