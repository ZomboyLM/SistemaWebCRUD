using System.Data.SqlClient;

namespace SistemaWeb.Data
{
	public class Conexion
	{

		private string con = string.Empty;

		public Conexion()
		{

			var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

			con = builder.GetSection("ConnectionString:CadenaCon").Value;
		}

		public string getCon()
		{

			return con;

		}

	}
}