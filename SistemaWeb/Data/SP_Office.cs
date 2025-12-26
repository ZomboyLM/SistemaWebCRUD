using SistemaWeb.Models;
using System.Data.SqlClient;
using System.Data;

namespace SistemaWeb.Data
{
    public class SP_Office
    {

        public List<OfficeModel> ObtenerOffice()
        {
            List<OfficeModel> offices = new List<OfficeModel>();
            var cn = new Conexion();

            try
            {
                using (SqlConnection connection = new SqlConnection(cn.getCon()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Obtener_Office", connection); 
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            OfficeModel office = new OfficeModel
                            {
                                IdOffice = reader["Id_Office"] != DBNull.Value ? Convert.ToInt32(reader["Id_Office"]) : 0,
                                Office = reader["Office"] != DBNull.Value ? reader["Office"].ToString() : string.Empty,

                            };
                            offices.Add(office);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine(ex.Message);
            }

            return offices;
        }

    }
}
