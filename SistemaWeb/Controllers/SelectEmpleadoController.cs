using Microsoft.AspNetCore.Mvc;
using SistemaWeb.Data;
using SistemaWeb.Models;

namespace SistemaWeb.Controllers
{
    public class SelectEmpleadoController : Controller
    {
        SP_Select_Empleado _Tipo = new SP_Select_Empleado();

        public ActionResult Index()
        {
            List<SelectEmpleadoModel> tipo = _Tipo.ObtenerEmpleado();

            ViewBag.Tipo = tipo;

            // Redirigir a la acción Index del controlador EmpleadoController
            return RedirectToAction("Index", "Equipo");
        }
    }
}
