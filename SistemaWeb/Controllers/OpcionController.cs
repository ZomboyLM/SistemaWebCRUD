using Microsoft.AspNetCore.Mvc;
using SistemaWeb.Data;
using SistemaWeb.Models;

namespace SistemaWeb.Controllers
{
    public class OpcionController : Controller
    {
        SP_Opciones _Opciones = new SP_Opciones();

        public ActionResult Index()
        {
            List<Opciones> opciones = _Opciones.ObtenerOpciones();

            ViewBag.Opciones = opciones;

            // Redirigir a la acción Index del controlador EmpleadoController
            return RedirectToAction("Index", "Empleado");
        }
    }

}
