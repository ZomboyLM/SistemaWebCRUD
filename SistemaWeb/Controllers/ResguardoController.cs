using Microsoft.AspNetCore.Mvc;
using SistemaWeb.Data;
using SistemaWeb.Models;

namespace SistemaWeb.Controllers
{
    public class ResguardoController : Controller
    {
        SP_Resguardo _Resguardo = new SP_Resguardo();

        public ActionResult Index()
        {
            List<ResguardoModel> resguardo = _Resguardo.ObtenerResguardo();

            ViewBag.Resguardo = resguardo;

            // Redirigir a la acción Index del controlador EmpleadoController
            return RedirectToAction("Index", "Equipo");
        }
    }
}
