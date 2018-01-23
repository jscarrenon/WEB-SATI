using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SATI.Services.Services;
using SATI.Services.Services.Pershing;
using SATI.Common.Entities;
using SATI.Common.Entities.Pershing;

namespace WebSATI.Controllers
{
    public class PershingController : Controller
    {
        // GET: Pershing
        private MenuServices _menuServices = new MenuServices();
        private PershingService _pershingService = new PershingService();
        private GeneracionContratosServices _ContratosService = new GeneracionContratosServices();

        public PartialViewResult Menu()
        {
            ViewData["ListMenuAplicacion"] = _menuServices.ListadoMenuAplicacionUsuarios("4", "PERSHING");
            return PartialView("Menu/menu");
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CargaActivity()
        {
            return View();
        }
        public ActionResult InformesNormativos()
        {
            return View();
        }
        public ActionResult GeneracionContratos()
        {
            List<DateTime> ListadoFechasContratos = _ContratosService.ListadoFechaContratos();
            ViewData["Fechas"] = ListadoFechasContratos;
            return View();
        }

        [HttpPost]
        public PartialViewResult BodyTablaContratos(string fecha)
        {
            List<Contrato> Contratos = _ContratosService.ListadoContratos(DateTime.Parse(fecha));
            ViewData["Contratos"] = Contratos;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult ProcesarPershing()
        {
           ActivityPershing activityResult = (ActivityPershing)TempData["activityPershing"];
           activityResult = _pershingService.ProcesarActivityPershing(activityResult);
           return  PartialView(activityResult);                    
        }

        [HttpPost]
        public PartialViewResult ChangeInstrumentoPershing(string numFolio,string instrumento)
        {
            ActivityPershing activityResult = _pershingService.ObtenerActivity(numFolio, instrumento);           
            return PartialView("ProcesarPershing", activityResult);
        }

        public PartialViewResult ConfirmarCargaPershing(string numFolio, string instrumento,string[] pershingCod)
        {
            ActivityPershing Activity = _pershingService.ObtenerActivity(numFolio, instrumento);   
            ActivityPershing ActivityDetalle = _pershingService.CargarPershingSeleccionados(Activity, pershingCod,User.Identity.Name);
            TempData["activityPershing"] = ActivityDetalle;
            return PartialView("Modal/ConfirmarCargaPershing", ActivityDetalle);
        }

        public PartialViewResult CargarPershing()
        {
            ActivityPershing activityResult = (ActivityPershing)TempData["activityPershing"];          
            CargaPershingResult cargaPershing = _pershingService.CargarLibroOperaciones(activityResult,"Rodrigocarmona.ext");
            return PartialView("Modal/CargarPershing", cargaPershing);
        }
    }
}