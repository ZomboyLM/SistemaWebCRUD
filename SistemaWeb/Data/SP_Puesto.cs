using SistemaWeb.Models;
using System.Data.SqlClient;
using System.Data;

namespace SistemaWeb.Data
{
    public class SP_Puesto
    {
        public List<PuestoModel> ObtenerPuesto()
        {
            List<PuestoModel> puestos = new List<PuestoModel>();
            var cn = new Conexion();

            try
            {
                using (SqlConnection connection = new SqlConnection(cn.getCon()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Obtener_Puesto", connection); // Supongamos que tienes un procedimiento almacenado llamado "Obtener_Opciones" para obtener las opciones desde la tabla
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PuestoModel puesto = new PuestoModel
                            {
                                IdPuesto = reader["Id_Puesto"] != DBNull.Value ? Convert.ToInt32(reader["Id_Puesto"]) : 0,
                                Puesto = reader["Puesto"] != DBNull.Value ? reader["Puesto"].ToString() : string.Empty,
                                IdDepartamento = reader["Id_Departamento"] != DBNull.Value ? Convert.ToInt32(reader["Id_Departamento"]) : 0
                            };
                            puestos.Add(puesto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine(ex.Message);
            }

            return puestos;
        }

    }
}

