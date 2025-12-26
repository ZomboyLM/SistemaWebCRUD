using Microsoft.AspNetCore.Mvc;
using SistemaWeb.Data;
using SistemaWeb.Models;

namespace SistemaWeb.Controllers
{
	public class EmpleadoController : Controller 
	{
		SP_Empleado _Empleado = new SP_Empleado();

        private readonly SP_Opciones _opcionesService;
        private readonly SP_Puesto _puesto;
        private readonly SP_Departamento _departamento;
        private readonly SP_Localidad _localidad;
        private readonly SP_Tipo _tipo;


        public EmpleadoController(SP_Opciones opcionesService, SP_Puesto puesto,SP_Departamento departamento, SP_Localidad localidad,SP_Tipo tipo)
        {
            _opcionesService = opcionesService;
            _puesto = puesto;
            _departamento = departamento;
            _localidad = localidad;
            _tipo = tipo;
        }

        public IActionResult EmpleadoLista() //mostrara una lista de contactos
		{
            Response.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
            Response.Headers.Add("Pragma", "no-cache");
            Response.Headers.Add("Expires", "0");
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

                List<Opciones> opciones = _opcionesService.ObtenerOpciones();
                ViewBag.Opciones = opciones;

                List<PuestoModel> puesto = _puesto.ObtenerPuesto();
                ViewBag.Puesto = puesto;

                List<DepartamentoModel> departamento = _departamento.ObtenerDepartamento();
                ViewBag.Departamento = departamento;

                List<LocalidadModel> localidad = _localidad.ObtenerLocalidad();
                ViewBag.Localidad = localidad;

                List<TipoModel> tipo = _tipo.ObtenerTipo();
                ViewBag.Tipo = tipo;

                var oLista = _Empleado.Listar();
                return View(oLista);
            }
        }
        public IActionResult ObtenerTablaEmpleado()
        {
            var oLista = _Empleado.Listar(); // Obtener los datos actualizados de la base de datos
            return PartialView("_TablaEmpleados", oLista); // Devolver la tabla actualizada como una vista parcial
        }
        public IActionResult EmpleadoView()// solo devuelve la vista
		{
			return View();
		}
        [HttpGet]
        public IActionResult ObtenerEmpleado(int idEmpleado)
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            var empleado = _Empleado.Obtener(idEmpleado);

            if (empleado != null)
            {
                return Json(empleado);
            }
            else
            {
                return Json(new { error = "Empleado no encontrado" });
            }
        }

        [HttpPost]
        public IActionResult Guardar([FromBody] EmpleadoModel oEmpleado)
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0; // Obtener el ID de usuario de la sesión

            // Establecer userId en el modelo de empleado
            oEmpleado.Usuario_Alta = userId;
            try
            {
                var (exito, mensaje) = _Empleado.Insertar(oEmpleado);

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
        [HttpPost]
        public IActionResult ActualizarEmpleado(EmpleadoModel oEmpleado)
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0; // Obtener el ID de usuario de la sesión

            // Establecer userId en el modelo de usuario
            oEmpleado.Usuario_Alta = userId;
            try
            {
                var (exito, mensaje) = _Empleado.Editar(oEmpleado);

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

    }
}