using Microsoft.AspNetCore.Mvc;
using SistemaWeb.Data;
using SistemaWeb.Models;

namespace SistemaWeb.Controllers
{
    public class TipoController : Controller
    {
        SP_Tipo _Tipo = new SP_Tipo();

        public ActionResult Index()
        {
            List<TipoModel> tipo = _Tipo.ObtenerTipo();

            ViewBag.Tipo = tipo;

            // Redirigir a la acción Index del controlador EmpleadoController
            return RedirectToAction("Index", "Empleado");
        }
    }
}
