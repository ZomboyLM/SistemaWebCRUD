using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Routing.Patterns;
using global::SistemaWeb.Models;

namespace SistemaWeb.Data
{
	public class SP_Equipo
	{
		public List<EquipoModel> Listar()
		{
			var oLista = new List<EquipoModel>();
			var cn = new Conexion();

			using (var conexion = new SqlConnection(cn.getCon()))
			{
				conexion.Open();
				SqlCommand cmd = new SqlCommand("Consulta_Equipo", conexion);
				cmd.CommandType = CommandType.StoredProcedure;


				using (var dr = cmd.ExecuteReader())
				{

					while (dr.Read())
					{

						oLista.Add(new EquipoModel()
						{

							Id_Equipo = Convert.ToInt32(dr["IdEquipo"]),
							Nombre = dr["Nombre"].ToString(),
							Empleado= dr["Empleado"].ToString(),
							Responsiva = dr["Responsiva"].ToString()
						});

					}
				}
			}
			return oLista;
		}

		public EquipoModel Obtener(int Id_Equipo)
		{
			var oEquipo = new EquipoModel();
			var cn = new Conexion();

			using (var conexion = new SqlConnection(cn.getCon()))
			{
				conexion.Open();
				SqlCommand cmd = new SqlCommand("Obten_Equipo", conexion);
				cmd.Parameters.AddWithValue("Id_Equipo", Id_Equipo);
				cmd.CommandType = CommandType.StoredProcedure;

				using (var dr = cmd.ExecuteReader())
				{

					while (dr.Read())
					{
						oEquipo.Nombre = dr["Nombre"].ToString();
						oEquipo.Service_tag = dr["Service_tag"].ToString();
						oEquipo.Modelo = dr["Modelo"].ToString();
						oEquipo.Tipo_equipo = dr["Tipo_equipo"].ToString();
						oEquipo.Dominio = dr["Dominio"].ToString();
						oEquipo.Estado = dr["Estatus"].ToString();
                        oEquipo.Resguardo = dr["Resguardo"].ToString();
                        oEquipo.Activo_fijo = dr["Activo_fijo"].ToString();
						oEquipo.Inicio_garantia = dr["Ini_garantia"].ToString();
						oEquipo.Fin_garantia = dr["Fin_garantia"].ToString();
						oEquipo.Fecha_adquision = dr["Fecha_adquision"].ToString();
						oEquipo.Marca = dr["Marca"].ToString();
						oEquipo.Sistema_operativo = dr["Sistema_operativo"].ToString();
						oEquipo.Procesador = dr["Procesador"].ToString();
						oEquipo.Office_version = dr["Office_version"].ToString();
						oEquipo.No_licencia = dr["No_licencia"].ToString();
						oEquipo.Sdd_hdd = dr["SDD_HDD"].ToString();
						oEquipo.Memoria_ram = dr["Memoria_RAM"].ToString();
						oEquipo.Cable_cargador = dr["Cable_cargador"].ToString();
						oEquipo.No_pantalla = dr["No_pantalla"].ToString();
						oEquipo.Modelo_pantalla = dr["Modelo_pantalla"].ToString();
						oEquipo.No_teclado = dr["No_teclado"].ToString();
						oEquipo.Modelo_teclado = dr["Modelo_teclado"].ToString();
						oEquipo.No_mouse = dr["No_mouse"].ToString();
						oEquipo.Modelo_mouse = dr["Modelo_mouse"].ToString();
						oEquipo.Antena = dr["Antena"].ToString();
						oEquipo.Disco_externo = dr["Disco_externo"].ToString();
						oEquipo.Maletin = dr["Maletin"].ToString();
						oEquipo.Otros = dr["Otros"].ToString();
						oEquipo.Mac_lan = dr["Mac_LAN"].ToString();
						oEquipo.Mac_wlan = dr["Mac_WLAN"].ToString();
						oEquipo.Direccion_ip = dr["Direccion_IP"].ToString();
						oEquipo.Teamviewer = dr["TeamViewer"].ToString();
						oEquipo.Anydesk = dr["AnyDesk"].ToString();
						oEquipo.Empleado = dr["Empleado"].ToString();
						oEquipo.Responsiva = dr["Responsiva"].ToString();



                    }
				}
			}
			return oEquipo;
		}


        public EquipoModel Obtener2(int Id_Equipo)
        {
            var oEquipo = new EquipoModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCon()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Obten_Equipo2", conexion);
                cmd.Parameters.AddWithValue("Id_Equipo", Id_Equipo);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oEquipo.Nombre = dr["Nombre"].ToString();
                        oEquipo.Service_tag = dr["Service_tag"].ToString();
                        oEquipo.Modelo = dr["Modelo"].ToString();
                        oEquipo.Tipo_equipo = dr["Tipo_equipo"].ToString();
                        oEquipo.Dominio = dr["Dominio"].ToString();
                        oEquipo.Estado = dr["Estatus"].ToString();
                        oEquipo.Resguardo = dr["Resguardo"].ToString();
                        oEquipo.Activo_fijo = dr["Activo_fijo"].ToString();
                        oEquipo.Inicio_garantia = dr["Ini_garantia"].ToString();
                        oEquipo.Fin_garantia = dr["Fin_garantia"].ToString();
                        oEquipo.Fecha_adquision = dr["Fecha_adquision"].ToString();
                        oEquipo.Marca = dr["Marca"].ToString();
                        oEquipo.Sistema_operativo = dr["Sistema_operativo"].ToString();
                        oEquipo.Procesador = dr["Procesador"].ToString();
                        oEquipo.Office_version = dr["Office_version"].ToString();
                        oEquipo.No_licencia = dr["No_licencia"].ToString();
                        oEquipo.Sdd_hdd = dr["SDD_HDD"].ToString();
                        oEquipo.Memoria_ram = dr["Memoria_RAM"].ToString();
                        oEquipo.Cable_cargador = dr["Cable_cargador"].ToString();
                        oEquipo.No_pantalla = dr["No_pantalla"].ToString();
                        oEquipo.Modelo_pantalla = dr["Modelo_pantalla"].ToString();
                        oEquipo.No_teclado = dr["No_teclado"].ToString();
                        oEquipo.Modelo_teclado = dr["Modelo_teclado"].ToString();
                        oEquipo.No_mouse = dr["No_mouse"].ToString();
                        oEquipo.Modelo_mouse = dr["Modelo_mouse"].ToString();
                        oEquipo.Antena = dr["Antena"].ToString();
                        oEquipo.Disco_externo = dr["Disco_externo"].ToString();
                        oEquipo.Maletin = dr["Maletin"].ToString();
                        oEquipo.Otros = dr["Otros"].ToString();
                        oEquipo.Mac_lan = dr["Mac_LAN"].ToString();
                        oEquipo.Mac_wlan = dr["Mac_WLAN"].ToString();
                        oEquipo.Direccion_ip = dr["Direccion_IP"].ToString();
                        oEquipo.Teamviewer = dr["TeamViewer"].ToString();
                        oEquipo.Anydesk = dr["AnyDesk"].ToString();
                        oEquipo.Empleado = dr["Empleado"].ToString();
                        oEquipo.Responsiva = dr["Responsiva"].ToString();



                    }
                }
            }
            return oEquipo;
        }


        public (bool success, string message) Insertar(EquipoModel oEquipo)
        {
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCon()))
                {
                    
                    conexion.Open();
					SqlCommand cmd = new SqlCommand("Insertar_Equipo", conexion);
					cmd.Parameters.AddWithValue("@Nombre", oEquipo.Nombre);
					cmd.Parameters.AddWithValue("@Service_tag", oEquipo.Service_tag);
					cmd.Parameters.AddWithValue("@Modelo", oEquipo.Modelo);
					cmd.Parameters.AddWithValue("@Tipo_equipo", oEquipo.Tipo_equipo);
					cmd.Parameters.AddWithValue("@Dominio", oEquipo.Dominio);
					cmd.Parameters.AddWithValue("@Estado", oEquipo.Estado);
                    cmd.Parameters.AddWithValue("@Resguardo", oEquipo.Resguardo);
                    cmd.Parameters.AddWithValue("@Activo_fijo", oEquipo.Activo_fijo);
					cmd.Parameters.AddWithValue("@Inicio_garantia", oEquipo.Inicio_garantia);
					cmd.Parameters.AddWithValue("@Fin_garantia", oEquipo.Fin_garantia);
					cmd.Parameters.AddWithValue("@Fecha_adquision", oEquipo.Fecha_adquision);
					cmd.Parameters.AddWithValue("@Marca", oEquipo.Marca);
					cmd.Parameters.AddWithValue("@Sistema_operativo", oEquipo.Sistema_operativo);
					cmd.Parameters.AddWithValue("@Procesador", oEquipo.Procesador);
					cmd.Parameters.AddWithValue("@Office_version", oEquipo.Office_version);
					cmd.Parameters.AddWithValue("@No_licencia", oEquipo.No_licencia);
					cmd.Parameters.AddWithValue("@SDD_HDD", oEquipo.Sdd_hdd);
					cmd.Parameters.AddWithValue("@Memoria_RAM", oEquipo.Memoria_ram);
					cmd.Parameters.AddWithValue("@Cable_cargador", oEquipo.Cable_cargador);
					cmd.Parameters.AddWithValue("@No_pantalla", oEquipo.No_pantalla);
					cmd.Parameters.AddWithValue("@Modelo_pantalla", oEquipo.Modelo_pantalla);
					cmd.Parameters.AddWithValue("@No_teclado", oEquipo.No_teclado);
					cmd.Parameters.AddWithValue("@Modelo_teclado", oEquipo.Modelo_teclado);
					cmd.Parameters.AddWithValue("@No_mouse", oEquipo.No_mouse);
					cmd.Parameters.AddWithValue("@Modelo_mouse", oEquipo.Modelo_mouse);
					cmd.Parameters.AddWithValue("@Antena", oEquipo.Antena);
					cmd.Parameters.AddWithValue("@Disco_externo", oEquipo.Disco_externo);
					cmd.Parameters.AddWithValue("@Maletin", oEquipo.Maletin);
					cmd.Parameters.AddWithValue("@Otros", oEquipo.Otros);
					cmd.Parameters.AddWithValue("@Mac_LAN", oEquipo.Mac_lan);
					cmd.Parameters.AddWithValue("@Mac_WLAN", oEquipo.Mac_wlan);
					cmd.Parameters.AddWithValue("@Direccion_IP", oEquipo.Direccion_ip);
					cmd.Parameters.AddWithValue("@TeamViewer", oEquipo.Teamviewer);
					cmd.Parameters.AddWithValue("@AnyDesk", oEquipo.Anydesk);


					cmd.CommandType = CommandType.StoredProcedure;
					cmd.ExecuteNonQuery();
                    return (true, "Equipo insertado correctamente");
                }
            }
            catch (Exception ex)
            {
                return (false, "Error al insertar equipo: " + ex.Message);
            }
        }


        public (bool success, string message) Editar(EquipoModel oEquipo)
        {
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCon()))
                {
                    conexion.Open();
                    SqlCommand updateCmd = new SqlCommand("Editar_Equipos", conexion);
                    updateCmd.Parameters.AddWithValue("@Empleado", oEquipo.Empleado);
                    updateCmd.Parameters.AddWithValue("@Responsiva", oEquipo.Responsiva);
                    updateCmd.Parameters.AddWithValue("@Id_Equipo", oEquipo.Id_Equipo);
                    updateCmd.Parameters.AddWithValue("@Nombre", oEquipo.Nombre);
                    updateCmd.Parameters.AddWithValue("@Service_tag", oEquipo.Service_tag);
                    updateCmd.Parameters.AddWithValue("@Modelo", oEquipo.Modelo);
                    updateCmd.Parameters.AddWithValue("@Tipo_equipo", oEquipo.Tipo_equipo);
                    updateCmd.Parameters.AddWithValue("@Dominio", oEquipo.Dominio);
                    updateCmd.Parameters.AddWithValue("@Estado", oEquipo.Estado);
                    updateCmd.Parameters.AddWithValue("@Resguardo", oEquipo.Resguardo);
                    updateCmd.Parameters.AddWithValue("@Activo_fijo", oEquipo.Activo_fijo);
                    updateCmd.Parameters.AddWithValue("@Inicio_garantia", oEquipo.Inicio_garantia);
                    updateCmd.Parameters.AddWithValue("@Fin_garantia", oEquipo.Fin_garantia);
                    updateCmd.Parameters.AddWithValue("@Fecha_adquision", oEquipo.Fecha_adquision);
                    updateCmd.Parameters.AddWithValue("@Marca", oEquipo.Marca);
                    updateCmd.Parameters.AddWithValue("@Sistema_operativo", oEquipo.Sistema_operativo);
                    updateCmd.Parameters.AddWithValue("@Procesador", oEquipo.Procesador);
                    updateCmd.Parameters.AddWithValue("@Office_version", oEquipo.Office_version);
                    updateCmd.Parameters.AddWithValue("@No_licencia", oEquipo.No_licencia);
                    updateCmd.Parameters.AddWithValue("@SDD_HDD", oEquipo.Sdd_hdd);
                    updateCmd.Parameters.AddWithValue("@Memoria_RAM", oEquipo.Memoria_ram);
                    updateCmd.Parameters.AddWithValue("@Cable_cargador", oEquipo.Cable_cargador);
                    updateCmd.Parameters.AddWithValue("@No_pantalla", oEquipo.No_pantalla);
                    updateCmd.Parameters.AddWithValue("@Modelo_pantalla", oEquipo.Modelo_pantalla);
                    updateCmd.Parameters.AddWithValue("@No_teclado", oEquipo.No_teclado);
                    updateCmd.Parameters.AddWithValue("@Modelo_teclado", oEquipo.Modelo_teclado);
                    updateCmd.Parameters.AddWithValue("@No_mouse", oEquipo.No_mouse);
                    updateCmd.Parameters.AddWithValue("@Modelo_mouse", oEquipo.Modelo_mouse);
                    updateCmd.Parameters.AddWithValue("@Antena", oEquipo.Antena);
                    updateCmd.Parameters.AddWithValue("@Disco_externo", oEquipo.Disco_externo);
                    updateCmd.Parameters.AddWithValue("@Maletin", oEquipo.Maletin);
                    updateCmd.Parameters.AddWithValue("@Otros", oEquipo.Otros);
                    updateCmd.Parameters.AddWithValue("@Mac_LAN", oEquipo.Mac_lan);
                    updateCmd.Parameters.AddWithValue("@Mac_WLAN", oEquipo.Mac_wlan);
                    updateCmd.Parameters.AddWithValue("@Direccion_IP", oEquipo.Direccion_ip);
                    updateCmd.Parameters.AddWithValue("@TeamViewer", oEquipo.Teamviewer);
                    updateCmd.Parameters.AddWithValue("@AnyDesk", oEquipo.Anydesk);
                    updateCmd.CommandType = CommandType.StoredProcedure;
                    updateCmd.ExecuteNonQuery();

                    return (true, "Equipo actualizado correctamente");
                }
            }
            catch (Exception ex)
            {
                return (false, "Error al actualizar equipo: " + ex.Message);
            }
        }


    }
}