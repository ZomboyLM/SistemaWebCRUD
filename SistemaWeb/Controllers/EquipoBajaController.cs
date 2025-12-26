using Microsoft.AspNetCore.Mvc;
using SistemaWeb.Data;
using SistemaWeb.Models;

namespace SistemaWeb.Controllers
{
    public class EquipoBajaController : Controller
    {
        SP_BajaEquipo _Equipo = new SP_BajaEquipo();
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult EquipoBaja()
        {

            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                String user = HttpContext.Session.GetString("User") ?? string.Empty;
                int userId = HttpContext.Session.GetInt32("UserId") ?? 0;

                // Puedes hacer lo que necesites con el ID del usuario, por ejemplo, pasarlo a la vista
                ViewBag.UserId = userId;
                ViewBag.Usuario = user;



                var oLista = _Equipo.Listar();
                return View(oLista);
            }

        }

        [HttpGet]
        public IActionResult ObtenerEquipo(int idEquipo)
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            var equipo = _Equipo.Obtener(idEquipo);

            if (equipo != null)
            {
                return Json(equipo);
            }
            else
            {
                return Json(new { error = "Equipo no encontrado" });
            }
        }
    }
}
