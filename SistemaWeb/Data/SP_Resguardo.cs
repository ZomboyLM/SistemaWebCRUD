using SistemaWeb.Models;
using System.Data.SqlClient;
using System.Data;

namespace SistemaWeb.Data
{
    public class SP_Resguardo
    {

        public List<ResguardoModel> ObtenerResguardo()
        {
            List<ResguardoModel> resguardos = new List<ResguardoModel>();
            var cn = new Conexion();

            try
            {
                using (SqlConnection connection = new SqlConnection(cn.getCon()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Obtener_Resguardo", connection); // Supongamos que tienes un procedimiento almacenado llamado "Obtener_Opciones" para obtener las opciones desde la tabla
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ResguardoModel resguardo = new ResguardoModel
                            {
                                IdResguardo = reader["Id_Resguardo"] != DBNull.Value ? Convert.ToInt32(reader["Id_Resguardo"]) : 0,
                                Resguardo = reader["Resguardo"] != DBNull.Value ? reader["Resguardo"].ToString() : string.Empty,
                              
                            };
                            resguardos.Add(resguardo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine(ex.Message);
            }

            return resguardos;
        }
    }
}
