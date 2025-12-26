using Microsoft.AspNetCore.Mvc;
using SistemaWeb.Data;
using SistemaWeb.Models;

namespace SistemaWeb.Controllers
{
    public class OfficeController : Controller
    {
        SP_Office _Office = new SP_Office();

        public ActionResult Index()
        {
            List<OfficeModel> office = _Office.ObtenerOffice();

            ViewBag.Office = office;

            // Redirigir a la acción Index del controlador EmpleadoController
            return RedirectToAction("Index", "Equipo");
        }
    }
}
