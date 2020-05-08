using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public int Id_mercado { get; set; }
        public string Id_producto { get; set; }
        public int Cantidad { get; set; }

        public ICollection<Producto> Productos { get; set; }

    }
}
