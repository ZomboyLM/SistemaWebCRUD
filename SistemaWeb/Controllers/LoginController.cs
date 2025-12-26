using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using SistemaWeb.Models;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.NetworkInformation;

namespace SistemaWeb.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		static string cadena = "Server=(local);Database=SistemaWeb;Integrated Security=True;";



		// GET: Acceso
		public ActionResult Login()
		{
            Response.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
            Response.Headers.Add("Pragma", "no-cache");
            Response.Headers.Add("Expires", "0");
            return View();
		}


		public ActionResult Registrar()
		{
			return View();
		}


		//[HttpPost]
		//public ActionResult Registrar(UsuarioModel oUsuario)
		//{
		//	bool registrado;
		//	string mensaje;


		//	if (oUsuario.Contrasena == oUsuario.ConfirmarContrasena)
		//	{

		//		oUsuario.Contrasena = ConvertirSha256(oUsuario.Contrasena);
		//	}
		//	else
		//	{
		//		ViewData["Mensaje"] = "Las contraseñas no coinciden";
		//		return View();
		//	}

		//	using (SqlConnection cn = new SqlConnection(cadena))
		//	{

		//		SqlCommand cmd = new SqlCommand("Insertar_Usuario", cn);
		//		cmd.Parameters.AddWithValue("Correo", oUsuario.Correo);
		//		cmd.Parameters.AddWithValue("Contrasena", oUsuario.Contrasena);
		//              cmd.Parameters.AddWithValue("Estatus", oUsuario.Estatus);
		//              cmd.Parameters.Add("Registrado", SqlDbType.Bit).Direction = ParameterDirection.Output;
		//		cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
		//		cmd.CommandType = CommandType.StoredProcedure;

		//		cn.Open();

		//		cmd.ExecuteNonQuery();

		//		registrado = Convert.ToBoolean(cmd.Parameters["Registrado"].Value);
		//		mensaje = cmd.Parameters["Mensaje"].Value.ToString();


		//	}

		//	ViewData["Mensaje"] = mensaje;

		//	if (registrado)
		//	{
		//		return RedirectToAction("Login", "Acceso");
		//	}
		//	else
		//	{
		//		return View();
		//	}

		//}
		
		[HttpPost]
        public ActionResult Login(UsuarioModel oUsuario)
        {
            if (string.IsNullOrWhiteSpace(oUsuario.Correo) || string.IsNullOrWhiteSpace(oUsuario.Contrasena))
            {
                ViewData["Mensaje"] = "Por favor, ingresa tu correo y contraseña.";
                return View();
            }

            oUsuario.Contrasena = oUsuario.Contrasena;

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("Validar_Usuario", cn);
                cmd.Parameters.AddWithValue("Correo", oUsuario.Correo);
                cmd.Parameters.AddWithValue("Contrasena", oUsuario.Contrasena);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                oUsuario.Id_Usuario = Convert.ToInt32(cmd.ExecuteScalar()?.ToString() ?? "0");

                // Verificar el estado del usuario solo si se encontró un Id_Usuario válido
                if (oUsuario.Id_Usuario != 0)
                {
                    cmd.CommandText = "SELECT Estatus, Acceso FROM Usuario WHERE Id_Usuario = @IdUsuario";
                    cmd.CommandType = CommandType.Text; // Cambiar a CommandType.Text para una consulta directa
                    cmd.Parameters.Clear(); // Limpiar parámetros anteriores
                    cmd.Parameters.AddWithValue("@IdUsuario", oUsuario.Id_Usuario);
                    var reader = cmd.ExecuteReader();
                    int estatus = 0;
                    int acceso = 0;

                    if (reader.Read())
                    {
                        estatus = Convert.ToInt32(reader["Estatus"]);
                        acceso = Convert.ToInt32(reader["Acceso"]);
                    }
                    reader.Close();

                    if (estatus == 1 && acceso == 1) // Si el usuario está activo
                    {
                        HttpContext.Session.SetString("Usuario", JsonConvert.SerializeObject(oUsuario));
                        HttpContext.Session.SetString("User", oUsuario.Correo);
                        HttpContext.Session.SetInt32("UserId", oUsuario.Id_Usuario);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewData["Mensaje"] = "Usuario sin acceso";
                        return View();
                    }
                }
                else
                {
                    ViewData["Mensaje"] = "Usuario no encontrado";
                    return View();
                }
            } // La conexión se cierra automáticamente al salir de este bloque 'using'
        }






        public static string ConvertirSha256(string texto)
		{
			//using System.Text;
			//USAR LA REFERENCIA DE "System.Security.Cryptography"

			StringBuilder Sb = new StringBuilder();
			using (SHA256 hash = SHA256Managed.Create())
			{
				Encoding enc = Encoding.UTF8;
				byte[] result = hash.ComputeHash(enc.GetBytes(texto));

				foreach (byte b in result)
					Sb.Append(b.ToString("x2"));
			}

			return Sb.ToString();
		}


        public ActionResult CerrarSesion()
        {
            HttpContext.Session.Remove("Usuario");
            return RedirectToAction("Login", "Login");
        }
    }
}
