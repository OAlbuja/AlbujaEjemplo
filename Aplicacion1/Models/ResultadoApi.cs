using System.Diagnostics.Contracts;

namespace Aplicacion1.Models
{
    public class ResultadoApi
    {
        public string httpResponseCode { get; set; }

        public List<Producto> listaProductos { get; set; }

        public Producto producto { get; set; }

        public List<Usuarios> listaUsuarios { get; set; }

        public Usuarios usuarios { get; set; }

        public List<ClienteCompra> listaClienteCompras { get; set; }

        public ClienteCompra clienteCompra { get; set; }

    }
}
