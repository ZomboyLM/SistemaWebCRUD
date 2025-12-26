using SistemaWeb.Models;
using System.Data.SqlClient;
using System.Data;

namespace SistemaWeb.Data
{
    public class SP_Localidad
    {

        public List<LocalidadModel> ObtenerLocalidad()
        {
            List<LocalidadModel> localidades = new List<LocalidadModel>();
            var cn = new Conexion();

            try
            {
                using (SqlConnection connection = new SqlConnection(cn.getCon()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Obtener_Localidades", connection); // Supongamos que tienes un procedimiento almacenado llamado "Obtener_Departamento" para obtener las opciones desde la tabla
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LocalidadModel localidad = new LocalidadModel
                            {
                                IdLocalidad = reader["Id_Localidad"] != DBNull.Value ? Convert.ToInt32(reader["Id_Localidad"]) : 0,
                                Localidad = reader["Localidad"] != DBNull.Value ? reader["Localidad"].ToString() : string.Empty,

                            };
                            localidades.Add(localidad);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine(ex.Message);
            }

            return localidades;
        }
    }
}
