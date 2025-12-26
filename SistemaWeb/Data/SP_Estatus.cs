using SistemaWeb.Models;
using System.Data.SqlClient;
using System.Data;

namespace SistemaWeb.Data
{
    public class SP_Estatus
    {

        public List<EstatusModel> ObtenerEstatus()
        {
            List<EstatusModel> estatus = new List<EstatusModel>();
            var cn = new Conexion();

            try
            {
                using (SqlConnection connection = new SqlConnection(cn.getCon()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Obtener_Estatus", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EstatusModel estatu = new EstatusModel
                            {
                                IdEstatus = reader["Id_Estatus"] != DBNull.Value ? Convert.ToInt32(reader["Id_Estatus"]) : 0,
                                Estatus = reader["Estatus"] != DBNull.Value ? reader["Estatus"].ToString() : string.Empty,

                            };
                            estatus.Add(estatu);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine(ex.Message);
            }

            return estatus;
        }
    }
}
