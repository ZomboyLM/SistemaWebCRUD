using Microsoft.AspNetCore.Mvc;
using SistemaWeb.Data;
using SistemaWeb.Models;

namespace SistemaWeb.Controllers
{
    public class DepartamentoController : Controller
    {
        SP_Departamento _Departamento = new SP_Departamento();

        public ActionResult Index()
        {
            List<DepartamentoModel> departamento = _Departamento.ObtenerDepartamento();
            ViewBag.Departamento = departamento;

            // Redirigir a la acción Index del controlador EmpleadoController
            return RedirectToAction("Index", "Empleado");
        }
    }
}
