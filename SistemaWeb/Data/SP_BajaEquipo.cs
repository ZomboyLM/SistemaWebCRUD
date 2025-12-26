using SistemaWeb.Models;
using System.Data.SqlClient;
using System.Data;

namespace SistemaWeb.Data
{
    public class SP_BajaEquipo
    {
        public List<BajaEquipoModel> Listar()
        {
            var oLista = new List<BajaEquipoModel>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCon()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Consulta_EquipoBaja", conexion);
                cmd.CommandType = CommandType.StoredProcedure;


                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {

                        oLista.Add(new BajaEquipoModel()
                        {

                            Id_Equipo = Convert.ToInt32(dr["IdEquipo"]),
                            Nombre = dr["Nombre"].ToString(),
                            Empleado = dr["Empleado"].ToString(),
                            Responsiva = dr["Responsiva"].ToString()
                        });

                    }
                }
            }
            return oLista;
        }

        public BajaEquipoModel Obtener(int Id_Equipo)
        {
            var oEquipo = new BajaEquipoModel();
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
                        oEquipo.Adquision = dr["Adquision"].ToString();
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
    }
}
