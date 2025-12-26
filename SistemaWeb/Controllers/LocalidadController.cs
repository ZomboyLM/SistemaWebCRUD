using Microsoft.AspNetCore.Mvc;
using SistemaWeb.Data;
using SistemaWeb.Models;

namespace SistemaWeb.Controllers
{
    public class LocalidadController : Controller
    {
        SP_Localidad _Localidad = new SP_Localidad();

        public ActionResult Index()
        {
            List<LocalidadModel> localidad = _Localidad.ObtenerLocalidad();

            ViewBag.Localidad = localidad;

            // Redirigir a la acción Index del controlador EmpleadoController
            return RedirectToAction("Index", "Empleado");
        }
    }
}
