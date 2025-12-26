using SistemaWeb.Models;
using System.Data.SqlClient;
using System.Data;

namespace SistemaWeb.Data
{
	public class SP_Empleado
	{
		public List<EmpleadoModel> Listar()
		{
			var oLista = new List<EmpleadoModel>();
			var cn = new Conexion();

			using (var conexion = new SqlConnection(cn.getCon()))
			{
				conexion.Open();
				SqlCommand cmd = new SqlCommand("Consulta_Empleado", conexion);
				cmd.CommandType = CommandType.StoredProcedure;


				using (var dr = cmd.ExecuteReader())
				{

					while (dr.Read())
					{

						oLista.Add(new EmpleadoModel()
						{

                            Id_Empleado = dr["Id_Empleado"] != DBNull.Value ? Convert.ToInt32(dr["Id_Empleado"]) : 0,
                            Nombre = dr["Nombre"] != DBNull.Value ? dr["Nombre"].ToString() : string.Empty,
                            Apepaterno = dr["ApePaterno"] != DBNull.Value ? dr["ApePaterno"].ToString() : string.Empty,
                            Apematerno = dr["ApeMaterno"] != DBNull.Value ? dr["ApeMaterno"].ToString() : string.Empty,
                            Tipo= dr["Tipo"] != DBNull.Value ? dr["Tipo"].ToString() : string.Empty,
                            Division = dr["Division"].ToString(),
                            Puesto = dr["Puesto"].ToString(),
                            Departamento = dr["Departamento"].ToString(),
                            Localidad = dr["Localidad"].ToString(),
                            Usuario = dr["Usuario"].ToString(),
                            Estatus = dr["Estatus"] != DBNull.Value ? Convert.ToInt32(dr["Estatus"]) : 0,
                            Fecha_Alta = dr["Fecha_Alta"] != DBNull.Value ? dr["Fecha_Alta"].ToString() : string.Empty,
                            UsuarioAlta = dr["UsuarioAlta"] != DBNull.Value ? dr["UsuarioAlta"].ToString() : string.Empty,
                            Fecha_Modifica = dr["Fecha_Modifica"] != DBNull.Value ? dr["Fecha_Modifica"].ToString() : string.Empty,
                            Usuario_Modifica = dr["Usuario_Modifica"] != DBNull.Value ? dr["Usuario_Modifica"].ToString() : string.Empty,
                            Fecha_Baja = dr["Fecha_Baja"] != DBNull.Value ? dr["Fecha_Baja"].ToString() : string.Empty,
                            Usuario_Baja = dr["Usuario_Baja"] != DBNull.Value ? dr["Usuario_Baja"].ToString() : string.Empty,
                            Acceso= dr["Acceso"] != DBNull.Value ? Convert.ToInt32(dr["Acceso"]) : 0,
                        });

					}
				}
			}
			return oLista;
		}

        public EmpleadoModel Obtener(int IdEmpleado)
        {
            var oEmpleado = new EmpleadoModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCon()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Obten_Empleado", conexion);
                cmd.Parameters.AddWithValue("Id_Empleado", IdEmpleado);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oEmpleado.Nombre = dr["Nombre"].ToString();
                        oEmpleado.Apepaterno = Convert.ToString(dr["ApePaterno"]) ?? string.Empty;
                        oEmpleado.Apematerno = Convert.ToString(dr["ApeMaterno"]) ?? string.Empty;
                        oEmpleado.Tipo= Convert.ToString(dr["Tipo"]) ?? string.Empty;
                        oEmpleado.Division = dr["Division"].ToString();
                        oEmpleado.Puesto = dr["Puesto"].ToString();
                        oEmpleado.Departamento = dr["Departamento"].ToString();
                        oEmpleado.Localidad = dr["Localidad"].ToString();
                        oEmpleado.Usuario = dr["Id_Usuario"].ToString();
                        oEmpleado.Estatus = dr["Estatus"] != DBNull.Value ? Convert.ToInt32(dr["Estatus"]) : 0;
                        oEmpleado.Acceso = dr["Acceso"] != DBNull.Value ? Convert.ToInt32(dr["Acceso"]) : 0;
                        oEmpleado.Correo = dr["Correo"].ToString();
                    }
                }
            }
            return oEmpleado;
        }



        public (bool success, string message) Insertar(EmpleadoModel oEmpleado)
        {
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCon()))
                {
                    conexion.Open();

                    // Si el nombre de empleado no existe, proceder con la inserción
                    SqlCommand insertCmd = new SqlCommand("Insertar_Empleado", conexion);
                    insertCmd.Parameters.AddWithValue("@Nombre", oEmpleado.Nombre);
                    insertCmd.Parameters.AddWithValue("@ApeMaterno", oEmpleado.Apematerno);
                    insertCmd.Parameters.AddWithValue("@ApePaterno", oEmpleado.Apepaterno);
                    insertCmd.Parameters.AddWithValue("@Tipo", oEmpleado.Tipo);
                    insertCmd.Parameters.AddWithValue("@Division", oEmpleado.Division);
                    insertCmd.Parameters.AddWithValue("@Puesto", oEmpleado.Puesto);
                    insertCmd.Parameters.AddWithValue("@Departamento", oEmpleado.Departamento);
                    insertCmd.Parameters.AddWithValue("@Localidad", oEmpleado.Localidad);
                    insertCmd.Parameters.AddWithValue("@Usuario_Alta", oEmpleado.Usuario_Alta);
                    insertCmd.Parameters.AddWithValue("@Estatus", oEmpleado.Estatus);
                    insertCmd.Parameters.AddWithValue("@Acceso", oEmpleado.Acceso);
                    insertCmd.CommandType = CommandType.StoredProcedure;
                    insertCmd.ExecuteNonQuery();

                    return (true, "Empleado insertado correctamente");
                }
            }
            catch (Exception ex)
            {
                return (false, "Error al insertar empleado: " + ex.Message);
            }
        }


        public (bool success, string message) Editar(EmpleadoModel oEmpleado)
        {
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCon()))
                {
                    conexion.Open();

                    // Verificar si el correo electrónico ya está siendo utilizado por otro usuario
                    SqlCommand checkEmailCmd = new SqlCommand("SELECT COUNT(*) FROM Usuario WHERE Correo = @Correo AND Id_Usuario != @Id_Empleado;", conexion);
                    checkEmailCmd.Parameters.AddWithValue("@Correo", oEmpleado.Correo);
                    checkEmailCmd.Parameters.AddWithValue("@Id_Empleado", oEmpleado.Id_Empleado);
                    int emailCount = (int)checkEmailCmd.ExecuteScalar();

                    if (emailCount > 0)
                    {
                        return (false, "Error al actualizar usuario: El correo electrónico ya está siendo utilizado por otro usuario");
                    }

                    SqlCommand updateCmd = new SqlCommand("Editar_Empleados", conexion);
                    updateCmd.Parameters.AddWithValue("@Id_Empleado", oEmpleado.Id_Empleado);
                    updateCmd.Parameters.AddWithValue("@Nombre", oEmpleado.Nombre);
                    updateCmd.Parameters.AddWithValue("@Ap_Paterno", oEmpleado.Apepaterno);
                    updateCmd.Parameters.AddWithValue("@Ap_Materno", oEmpleado.Apematerno);
                    updateCmd.Parameters.AddWithValue("@Division", oEmpleado.Division);
                    updateCmd.Parameters.AddWithValue("@Puesto", oEmpleado.Puesto);
                    updateCmd.Parameters.AddWithValue("@Departamento", oEmpleado.Departamento);
                    updateCmd.Parameters.AddWithValue("@Localidad", oEmpleado.Localidad);
                    updateCmd.Parameters.AddWithValue("@Estatus", oEmpleado.Estatus);
                    updateCmd.Parameters.AddWithValue("@Usuario_Alta", oEmpleado.Usuario_Alta);
                    updateCmd.Parameters.AddWithValue("@Acceso", oEmpleado.Acceso);
                    updateCmd.Parameters.AddWithValue("@Correo", oEmpleado.Correo);
                    updateCmd.CommandType = CommandType.StoredProcedure;
                    updateCmd.ExecuteNonQuery();

                    return (true, "Empleado actualizado correctamente");
                }
            }
            catch (Exception ex)
            {
                return (false, "Error al actualizar empleado: " + ex.Message);
            }
        }

        //public bool Editar(EmpleadoModel oEmpleado)
        //{
        //	bool res;
        //	try
        //	{

        //		var cn = new Conexion();

        //		using (var conexion = new SqlConnection(cn.getCon()))
        //		{
        //			conexion.Open();
        //			SqlCommand cmd = new SqlCommand("Editar_Usuarios", conexion);
        //			cmd.Parameters.AddWithValue("Id_Usuario", oEmpleado.Id_Usuario);
        //			cmd.Parameters.AddWithValue("Nomina", oEmpleado.Nomina);
        //			cmd.Parameters.AddWithValue("Nombre", oEmpleado.Nombre);
        //			cmd.Parameters.AddWithValue("Ap_Materno", oEmpleado.Ap_Materno);
        //			cmd.Parameters.AddWithValue("Ap_Paterno", oEmpleado.Ap_Paterno);
        //			cmd.Parameters.AddWithValue("Division", oEmpleado.Division);
        //			cmd.Parameters.AddWithValue("Puesto", oEmpleado.Puesto);
        //			cmd.Parameters.AddWithValue("Departaqmento", oEmpleado.Departamento);
        //			cmd.Parameters.AddWithValue("Localidad", oEmpleado.Localidad);
        //			cmd.Parameters.AddWithValue("Id_Location", oEmpleado.Id_Location);
        //			cmd.Parameters.AddWithValue("Id_Departamento", oEmpleado.Id_Departamento);
        //			cmd.Parameters.AddWithValue("Id_Rol", oEmpleado.Id_Rol);

        //			cmd.CommandType = CommandType.StoredProcedure;
        //			cmd.ExecuteNonQuery();
        //		}
        //		res = true;
        //	}
        //	catch (Exception e)
        //	{
        //		string error = e.Message;
        //		res = false;
        //	}
        //	return res;
        //}

    }
}