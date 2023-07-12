using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Aplicacion1.Models
{
    public class Producto
    {

        public int idProducto { get; set; }
        
        public string codeNumber { get; set; }
        
        public string name { get; set; }
        
        public string price { get; set; }
        public string quantity { get; set; }

        public Producto(int idProducto, string codeNumber, string name, string price, string quantity)
        {
            this.idProducto = idProducto;
            this.codeNumber = codeNumber;
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }
    }
}
