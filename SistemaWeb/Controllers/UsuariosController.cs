using Microsoft.AspNetCore.Mvc;
using SistemaWeb.Models;
using SistemaWeb.Data;


namespace SistemaWeb.Controllers
{
	public class UsuariosController : Controller
	{
		SP_Usuarios _Usuarios = new SP_Usuarios();

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Listar() //mostrara una lista de contactos
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
				var oLista = _Usuarios.Listar();
                    return View(oLista);
            }

		}

        public IActionResult ObtenerTablaUsuarios()
        {
            var oLista = _Usuarios.Listar(); // Obtener los datos actualizados de la base de datos
            return PartialView("_TablaUsuarios", oLista); // Devolver la tabla actualizada como una vista parcial
        }

        [HttpPost]
		public IActionResult Guardar(UsuarioModel oUsuario) //recibe el objeto para guardarlo en bd
		{
			var res = _Usuarios.Insertar(oUsuario);

			if (res)
				return RedirectToAction("Listar");
			else
				return View();
		}
        [HttpPost]
        public IActionResult ActualizarUsuario(UsuarioModel oUsuario)
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0; // Obtener el ID de usuario de la sesión

            // Establecer userId en el modelo de usuario
            oUsuario.Usuario_Alta = userId;
            try
            {
                var (exito, mensaje) = _Usuarios.Editar(oUsuario);

                if (exito)
                {
                    
                    return Json(new { success = true, message = mensaje });

                }
                else
                {
                    return Json(new { success = false, message = mensaje });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al procesar la solicitud: " + ex.Message });
            }
        }

        [HttpGet]
        public IActionResult ObtenerUsuario(int idUsuario)
        {
            var usuario = _Usuarios.Obtener(idUsuario);

            if (usuario != null)
            {
                return Json(usuario);
            }
            else
            {
                return Json(new { error = "Usuario no encontrado" });
            }
        }
    }
}