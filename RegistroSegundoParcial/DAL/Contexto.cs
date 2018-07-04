using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using RegistroSegundoParcial.Entidades;

namespace RegistroSegundoParcial.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Vehiculos> Vehiculos  { get; set; }

        public DbSet<Articulos> Articulos { get; set; }

        public DbSet<Entradas> Entradas { get; set; }

        public DbSet<Talleres> Talleres { get; set; }

        public Contexto() : base("ConStr")
        {

        }
    }
}
