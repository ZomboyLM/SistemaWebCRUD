using Microsoft.AspNetCore.Mvc;
using SistemaWeb.Data;
using SistemaWeb.Models;

namespace SistemaWeb.Controllers
{
    public class RamController : Controller
    {
        SP_Ram _ram = new SP_Ram();

        public ActionResult Index()
        {
            List<RamModel> ram = _ram.ObtenerRam();

            ViewBag.Ram = ram;

            // Redirigir a la acción Index del controlador EmpleadoController
            return RedirectToAction("Index", "Equipo");
        }
    }
}
