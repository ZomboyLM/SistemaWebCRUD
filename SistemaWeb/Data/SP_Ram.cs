using SistemaWeb.Models;
using System.Data.SqlClient;
using System.Data;

namespace SistemaWeb.Data
{
    public class SP_Ram
    {

        public List<RamModel> ObtenerRam()
        {
            List<RamModel> rams = new List<RamModel>();
            var cn = new Conexion();

            try
            {
                using (SqlConnection connection = new SqlConnection(cn.getCon()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Obtener_Ram", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RamModel ram = new RamModel
                            {
                                IdRam = reader["Id_Ram"] != DBNull.Value ? Convert.ToInt32(reader["Id_Ram"]) : 0,
                                Ram = reader["Ram"] != DBNull.Value ? reader["Ram"].ToString() : string.Empty,

                            };
                            rams.Add(ram);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine(ex.Message);
            }

            return rams;
        }

    }
}
