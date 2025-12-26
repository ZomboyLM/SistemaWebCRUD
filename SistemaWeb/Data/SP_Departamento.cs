using SistemaWeb.Models;
using System.Data.SqlClient;
using System.Data;

namespace SistemaWeb.Data
{
    public class SP_Departamento
    {

        public List<DepartamentoModel> ObtenerDepartamento()
        {
            List<DepartamentoModel> departamentos = new List<DepartamentoModel>();
            var cn = new Conexion();

            try
            {
                using (SqlConnection connection = new SqlConnection(cn.getCon()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Obtener_Departamento", connection); // Supongamos que tienes un procedimiento almacenado llamado "Obtener_Departamento" para obtener las opciones desde la tabla
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DepartamentoModel departamento = new DepartamentoModel
                            {
                                IdDepartamento = reader["Id_Departamento"] != DBNull.Value ? Convert.ToInt32(reader["Id_Departamento"]) : 0,
                                Departamento = reader["Departamento"] != DBNull.Value ? reader["Departamento"].ToString() : string.Empty,
                                
                            };
                            departamentos.Add(departamento);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine(ex.Message);
            }

            return departamentos;
        }

    }
}

