using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Unidad_de_Medida { get; set; }
        public Boolean Estado { get; set; }

       
    }
}
