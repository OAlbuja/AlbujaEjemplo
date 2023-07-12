using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aplicacion1.Models
{
    public class ClienteCompra
    {
        public int idCompra { get; set; }

        public string codigoCompra { get; set; }
        
        public string nombreCliente { get; set; }
               
        public string valorCompra { get; set; }

        public string cedula { get; set; }

        public ClienteCompra(int idCompra, string codigoCompra, string nombreCliente, string valorCompra, string cedula)
        {
            this.idCompra = idCompra;
            this.codigoCompra = codigoCompra;
            this.nombreCliente = nombreCliente;
            this.valorCompra = valorCompra;
            this.cedula = cedula;
        }
    }
}
