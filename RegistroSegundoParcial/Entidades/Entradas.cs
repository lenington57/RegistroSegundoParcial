using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RegistroSegundoParcial.Entidades
{
    public class Entradas
    {
        [Key]

        public int EntradaId { get; set; }

        public DateTime Fecha { get; set; }

        public string Articulo { get; set; }

        public int Cantidad { get; set; }


        public Entradas()
        {
            EntradaId = 0;
            Fecha = DateTime.Now;
            Articulo = string.Empty;
            Cantidad = 0;
        }
    }
}
