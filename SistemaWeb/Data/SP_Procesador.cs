using SistemaWeb.Models;
using System.Data.SqlClient;
using System.Data;

namespace SistemaWeb.Data
{
    public class SP_Procesador
    {


        public List<ProcesadorModel> ObtenerProcesador()
        {
            List<ProcesadorModel> procesadores = new List<ProcesadorModel>();
            var cn = new Conexion();

            try
            {
                using (SqlConnection connection = new SqlConnection(cn.getCon()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Obtener_Procesadores", connection);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProcesadorModel procesador = new ProcesadorModel
                            {
                                IdProcesador = reader["Id_Procesador"] != DBNull.Value ? Convert.ToInt32(reader["Id_Procesador"]) : 0,
                                Procesador = reader["Procesador"] != DBNull.Value ? reader["Procesador"].ToString() : string.Empty,

                            };
                            procesadores.Add(procesador);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine(ex.Message);
            }

            return procesadores;
        }

    }
}
