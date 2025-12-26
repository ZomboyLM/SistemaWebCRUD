using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemaWeb.Models;
using SistemaWeb.Permisos;
using System.Diagnostics;

namespace SistemaWeb.Controllers
{
    [ValidarSession]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Response.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
            Response.Headers.Add("Pragma", "no-cache");
            Response.Headers.Add("Expires", "0");
			String user = HttpContext.Session.GetString("User") ?? string.Empty;
			int userId = HttpContext.Session.GetInt32("UserId") ?? 0;

			// Pasar el Id_Usuario a la vista
			ViewBag.IdUsuario = userId;
            ViewBag.Usuario = user; ;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}