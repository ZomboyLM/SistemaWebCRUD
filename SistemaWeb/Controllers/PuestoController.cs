using Microsoft.AspNetCore.Mvc;
using SistemaWeb.Data;
using SistemaWeb.Models;

namespace SistemaWeb.Controllers
{
    public class PuestoController : Controller
    {
        SP_Puesto _Puesto = new SP_Puesto();

        public ActionResult Index()
        {
            List<PuestoModel> puesto = _Puesto.ObtenerPuesto();

            ViewBag.Puesto = puesto;

            // Redirigir a la acción Index del controlador EmpleadoController
            return RedirectToAction("Index", "Empleado");
        }
    }
}
