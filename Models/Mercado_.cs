using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Models
{
    public class Mercado_
    {
        public int Id { get; set; }
        public DateTime Fecha_creacion { get; set; }
        public Propietario Propietario { get; set; }
        public string Estado { get; set; }

        
        public ICollection<Producto> Productos { get; set; }
    }
}
