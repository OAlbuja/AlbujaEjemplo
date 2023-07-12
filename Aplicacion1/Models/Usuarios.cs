namespace Aplicacion1.Models
{
    public class Usuarios
    {
        public int idCliente { get; set; }
        public string nombre { get; set; }
        public string cedula { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }


        public Usuarios(int idCliente, string nombre, string cedula, string direccion, string telefono)
        {
            this.idCliente = idCliente;
            this.nombre = nombre;
            this.cedula = cedula;
            this.direccion = direccion;
            this.telefono = telefono;
        }

        public Usuarios()
        {
        }
    }
}
