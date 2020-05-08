using Mercado.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mercado.Data
{
    public class MercadoContext : DbContext
    {
        public MercadoContext(DbContextOptions<MercadoContext> options)
            : base(options)
        {
        }

        public DbSet<Pais> Pais { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Ciudad> Ciudad { get; set; }
        public DbSet<Unidad_Residencial> Unidad_Residencial { get; set; }
        public DbSet<Apartamento> Apartamento { get; set; }
        public DbSet<Propietario> Propietario{ get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Mercado_> Mercado { get; set; }
        public DbSet<Compra> Compra { get; set; }




    }
}
