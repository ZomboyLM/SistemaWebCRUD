namespace SistemaWeb.Models
{
	public class UsuarioModel
	{

		public int Id_Usuario { get; set; }
		public string? Correo { get; set; }
		public string? Contrasena { get; set; }
		public int Estatus { get; set; }
        public string? Fecha_Creacion { get; set; }
        public int Usuario_Alta {get; set; } //Insertar
        public string? UsuarioAlta { get; set; } // Extraer
        public string? Fecha_Baja { get; set; }
        public string? Fecha_Modifica { get; set; }
        public string? Usuario_Modifica { get; set; }
        public string? Usuario_Baja { get; set; }

    }
}
