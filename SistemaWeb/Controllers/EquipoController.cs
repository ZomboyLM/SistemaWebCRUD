using Microsoft.AspNetCore.Mvc;
using SistemaWeb.Data;
using SistemaWeb.Models;

namespace SistemaWeb.Controllers
{
	public class EquipoController : Controller
	{
			SP_Equipo _Equipo = new SP_Equipo();
            private readonly SP_Estatus _estatus;
            private readonly SP_Resguardo _resguardo;
            private readonly SP_Select_Empleado _empleado;
            private readonly SP_Office _office;
            private readonly SP_Procesador _procesador;
            private readonly SP_Ram _ram;

        public EquipoController(SP_Estatus estatus, SP_Resguardo resguardo, SP_Select_Empleado empleado, SP_Office office, SP_Procesador procesador, SP_Ram ram)
        {
            _estatus = estatus;
            _resguardo = resguardo;
            _empleado = empleado;
            _office = office;
            _procesador = procesador;
            _ram = ram;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult EquipoLista() 
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

                List<EstatusModel> estatus = _estatus.ObtenerEstatus();
                ViewBag.Estatus = estatus;
                List<ResguardoModel> resguardo = _resguardo.ObtenerResguardo();
                ViewBag.Resguardo = resguardo;
                List<SelectEmpleadoModel> empleado = _empleado.ObtenerEmpleado();
                ViewBag.Empleado = empleado;
                List<OfficeModel> office = _office.ObtenerOffice();
                ViewBag.Office = office;
                List<ProcesadorModel> procesador = _procesador.ObtenerProcesador();
                ViewBag.Procesador = procesador;
                List<RamModel> ram = _ram.ObtenerRam();
                ViewBag.Ram = ram;

                var oLista = _Equipo.Listar();
                return View(oLista);
            }

        }

        public IActionResult UsuarioView()// solo devuelve la vista
			{
				return View();
			}

        [HttpPost]
        public IActionResult Guardar([FromBody] EquipoModel oEquipo)
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0; // Obtener el ID de usuario de la sesión

            // Establecer userId en el modelo de empleado
        
            try
            {
                var (exito, mensaje) = _Equipo.Insertar(oEquipo);

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

        [HttpGet]
        public IActionResult ObtenerEquipo2(int idEquipo)
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            var empleado = _Equipo.Obtener2(idEquipo);

            if (empleado != null)
            {
                return Json(empleado);
            }
            else
            {
                return Json(new { error = "Equipo no encontrado" });
            }
        }
        [HttpPost]
        public IActionResult ActualizarEquipo(EquipoModel oEquipo)
        {
            //int userId = HttpContext.Session.GetInt32("UserId") ?? 0; // Obtener el ID de usuario de la sesión

            // Establecer userId en el modelo de usuario
            //oEmpleado.Usuario_Alta = userId;
            try
            {
                var (exito, mensaje) = _Equipo.Editar(oEquipo);

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