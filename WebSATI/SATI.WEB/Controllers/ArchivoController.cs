using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SATI.Services.Services.Excel;
using SATI.Services.Helper;
using SATI.Services.Services.Pershing;
using SATI.Common.Entities;
namespace WebSATI.Controllers
{
    public class ArchivoController : Controller
    {
        private ExcelPershingService serviceExcel = new ExcelPershingService();
        private ReportesServices serviceInforme = new ReportesServices();

        [HttpPost]
        public PartialViewResult ModalActivity(HttpPostedFileBase files)
        {
            string path = GuardarArchivoExcelTemporal(files);
            ActivityPershing activityResult = serviceExcel.ObtenerDatosExcel(path);           
            TempData["activityPershing"] = activityResult;
            return PartialView(activityResult);
        }


        #region Metodo Encargado De Dejar el Archivo en la Carpeta Correspondiente
        private string GuardarArchivoExcelTemporal(HttpPostedFileBase files)
        {
            string path = "";           
            if (files != null)
            {
               path = ExcelHelper.PathUploadExcel() + files.FileName;
               files.SaveAs(path);
            }          
            return path;
        }
        #endregion

        #region Reportes
        [HttpPost]
        public JsonResult ExportarLibroOperacionesByFecha(string desde,string hasta)
        {
            string urlArchivo = serviceInforme.GenerarPDFLibroOperaciones(desde, hasta);
            return Json(urlArchivo);
        }

        [HttpPost]
        public JsonResult ExportarRegistroRecepcionesByFecha(string desde, string hasta)
        {
            string urlArchivo = serviceInforme.GenerarPDFRegistroRecepciones(desde, hasta);
            return Json(urlArchivo);
        }

        [HttpPost]
        public JsonResult ExportarContratosPershing(string fecha)
        {
            string urlArchivo = serviceInforme.GenerarContratos(fecha);
            return Json(urlArchivo);
        }
        #endregion
    }
}
