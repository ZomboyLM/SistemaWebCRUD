using System.Data.SqlClient;
using System.Data;
using SistemaWeb.Models;
namespace SistemaWeb.Data
{
    public class SP_Opciones
    {
        public List<Opciones> ObtenerOpciones()
        {
            List<Opciones> opciones = new List<Opciones>();
            var cn = new Conexion();

            try
            {
                using (SqlConnection connection = new SqlConnection(cn.getCon()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Obtener_Division", connection); // Supongamos que tienes un procedimiento almacenado llamado "Obtener_Opciones" para obtener las opciones desde la tabla
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Opciones opcion = new Opciones
                            {
                                Id = reader["Id_Division"] != DBNull.Value ? Convert.ToInt32(reader["Id_Division"]) : 0,
                                Nombre = reader["Division"] != DBNull.Value ? reader["Division"].ToString() : string.Empty
                            };
                            opciones.Add(opcion);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine(ex.Message);
            }

            return opciones;
        }

    }
}
