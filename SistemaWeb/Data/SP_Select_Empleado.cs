using SistemaWeb.Models;
using System.Data.SqlClient;
using System.Data;

namespace SistemaWeb.Data
{
    public class SP_Select_Empleado
    {
        public List<SelectEmpleadoModel> ObtenerEmpleado()
        {
            List<SelectEmpleadoModel> empleados = new List<SelectEmpleadoModel>();
            var cn = new Conexion();

            try
            {
                using (SqlConnection connection = new SqlConnection(cn.getCon()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Obtener_Empleado_Select", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SelectEmpleadoModel empleado = new SelectEmpleadoModel
                            {
                                IdEmpleado = reader["Id_Empleado"] != DBNull.Value ? Convert.ToInt32(reader["Id_Empleado"]) : 0,
                                Empleado = reader["Empleado"] != DBNull.Value ? reader["Empleado"].ToString() : string.Empty,

                            };
                            empleados.Add(empleado);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine(ex.Message);
            }

            return empleados;
        }
    }
}
