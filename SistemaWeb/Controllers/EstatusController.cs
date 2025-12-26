using Microsoft.AspNetCore.Mvc;
using SistemaWeb.Data;
using SistemaWeb.Models;

namespace SistemaWeb.Controllers
{
    public class EstatusController : Controller
    {
        SP_Estatus _Estatus = new SP_Estatus();

        public ActionResult Index()
        {
            List<EstatusModel> estatus = _Estatus.ObtenerEstatus();

            ViewBag.Estatus = estatus;

            // Redirigir a la acción Index del controlador EmpleadoController
            return RedirectToAction("Index", "Equipo");
        }
    }
}
