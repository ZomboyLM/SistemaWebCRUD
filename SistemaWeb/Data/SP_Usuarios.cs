using SistemaWeb.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Routing.Patterns;

namespace SistemaWeb.Data
{
	public class SP_Usuarios
	{
		public List<UsuarioModel> Listar()
		{
			var oLista = new List<UsuarioModel>();
			var cn = new Conexion();

			using (var conexion = new SqlConnection(cn.getCon()))
			{
				conexion.Open();
				SqlCommand cmd = new SqlCommand("Consulta_Usuarios", conexion);
				cmd.CommandType = CommandType.StoredProcedure;


				using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {

                        oLista.Add(new UsuarioModel() {
                        
                            Id_Usuario = Convert.ToInt32(dr["Id_Usuario"]),
                            Correo = dr["Correo"].ToString(),
                            Fecha_Creacion= dr["Fecha_Creacion"].ToString(),
                            Estatus = Convert.ToInt32(dr["Estatus"]),
                            Fecha_Baja = dr["Fecha_Baja"].ToString(),
                            UsuarioAlta = dr["UsuarioAlta"] != DBNull.Value ? dr["UsuarioAlta"].ToString() : string.Empty,
                            Fecha_Modifica = dr["Fecha_Modifica"].ToString(),
                            Usuario_Modifica= dr["Usuario_Modifica"].ToString(),
                            Usuario_Baja= dr["Usuario_Baja"].ToString()
                        });

                    }
                }
            }
            return oLista;
        }

        public UsuarioModel Obtener( int IdUsuario)
        {
            var oUsuario = new UsuarioModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCon()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Obten_Usuarios", conexion);
                cmd.Parameters.AddWithValue("Id_Usuario", IdUsuario);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oUsuario.Correo = dr["Correo"].ToString();
                        oUsuario.Contrasena = dr["Contrasena"].ToString();
                        oUsuario.Fecha_Creacion = dr["Fecha_Creacion"].ToString();
                        oUsuario.Estatus = Convert.ToInt32(dr["Estatus"]);
						//oUsuario.Fecha_Baja = dr["Fecha_Baja"].ToString();

                       
                    }
                }
            }
            return oUsuario;
        }

        public bool Insertar(UsuarioModel oUsuario)
        {
            bool res;
            try
            {

                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCon()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Insertar_Usuario", conexion);
                    cmd.Parameters.AddWithValue("Correo", oUsuario.Correo);
                    cmd.Parameters.AddWithValue("Contrasena", oUsuario.Contrasena);
                    cmd.Parameters.AddWithValue("Estatus", oUsuario.Estatus);


                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                res = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                res = false;
            }
            return res;
        }

        public (bool success, string message) Editar(UsuarioModel oUsuario)
        {
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCon()))
                {
                    conexion.Open();

                    // Verificar si el correo electrónico ya está siendo utilizado por otro usuario
                    SqlCommand checkEmailCmd = new SqlCommand("SELECT COUNT(*) FROM Usuario WHERE Correo = @Correo AND Id_Usuario != @Id_Usuario;", conexion);
                    checkEmailCmd.Parameters.AddWithValue("@Correo", oUsuario.Correo);
                    checkEmailCmd.Parameters.AddWithValue("@Id_Usuario", oUsuario.Id_Usuario);
                    int emailCount = (int)checkEmailCmd.ExecuteScalar();

                    if (emailCount > 0)
                    {
                        return (false, "Error al actualizar usuario: El correo electrónico ya está siendo utilizado por otro usuario");
                    }

                    // Si el correo electrónico no está en uso, proceder con la actualización
                    SqlCommand updateCmd = new SqlCommand("Editar_Usuarios", conexion);
                    updateCmd.Parameters.AddWithValue("@Id_Usuario", oUsuario.Id_Usuario);
                    updateCmd.Parameters.AddWithValue("@Correo", oUsuario.Correo);
                    updateCmd.Parameters.AddWithValue("@Contrasena", oUsuario.Contrasena);
                    updateCmd.Parameters.AddWithValue("@Estatus", oUsuario.Estatus);
                    updateCmd.Parameters.AddWithValue("@Usuario_Alta", oUsuario.Usuario_Alta);
                    updateCmd.CommandType = CommandType.StoredProcedure;
                    updateCmd.ExecuteNonQuery();

                    return (true, "Usuario actualizado correctamente");
                }
            }
            catch (Exception ex)
            {
                return (false, "Error al actualizar usuario: " + ex.Message);
            }
        }



    }
}