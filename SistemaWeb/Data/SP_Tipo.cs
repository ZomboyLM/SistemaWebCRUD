using SistemaWeb.Models;
using System.Data.SqlClient;
using System.Data;

namespace SistemaWeb.Data
{
    public class SP_Tipo
    {
        public List<TipoModel> ObtenerTipo()
        {
            List<TipoModel> tipos = new List<TipoModel>();
            var cn = new Conexion();

            try
            {
                using (SqlConnection connection = new SqlConnection(cn.getCon()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Obtener_Tipos", connection); 
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TipoModel tipo = new TipoModel
                            {
                                IdTipo = reader["Id_Tipo"] != DBNull.Value ? Convert.ToInt32(reader["Id_Tipo"]) : 0,
                                Tipo = reader["Tipo"] != DBNull.Value ? reader["Tipo"].ToString() : string.Empty,

                            };
                            tipos.Add(tipo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine(ex.Message);
            }

            return tipos;
        }
    }
}
