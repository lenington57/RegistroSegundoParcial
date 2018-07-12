using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroSegundoParcial.Entidades
{
    public class Entradas
    {
        [Key]

        public int EntradaId { get; set; }

        public DateTime Fecha { get; set; }

        public int ArticuloId { get; set; }

        public double Cantidad { get; set; }


        public Entradas()
        {
            EntradaId = 0;
            Fecha = DateTime.Now;
            ArticuloId = 0;
            Cantidad = 0; 
        }
    }
}
