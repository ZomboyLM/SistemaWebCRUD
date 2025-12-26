namespace SistemaWeb.Models
{
	public class EmpleadoModel
	{
		public int Id_Empleado { get; set; }
		public string? Nombre { get; set; }
		public string? Apepaterno { get; set; }
		public string? Apematerno { get; set; }
        public string? Tipo { get; set; }
        public string? Division { get; set; }
		public string? Puesto { get; set; }
		public string? Departamento{ get; set; }
		public string? Localidad { get; set; }
        public string? Usuario { get; set; }
        public int Estatus { get; set; }
		public string? Fecha_Alta { get; set; }
		public string? UsuarioAlta { get; set; } // Para hacer consulta
		public string? Fecha_Modifica { get; set; }
		public string? Usuario_Modifica { get; set; }
		public string? Fecha_Baja { get; set; }
        public string? Usuario_Baja { get; set; }
        public int Usuario_Alta { get; set; } //Para insertar
		public int Acceso { get; set; }

        public string? Correo { get; set; }
    }
}
