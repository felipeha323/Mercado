using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Models
{
    public class Propietario
    {
        public int Id { get; set; }
        public int ApartamentoID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int telefono { get; set; }      
        public Apartamento Apartamento { get; set; }

        public ICollection<Mercado_> Mercados { get; set; }


    }
}
