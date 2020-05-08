using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Models
{
    public class Apartamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Piso { get; set; }
        public int Bloque { get; set; }
        public Unidad_Residencial Unidad { get; set; }
        public Boolean Estado { get; set; }

        public ICollection<Propietario> Propietarios { get; set; }
    }
}
