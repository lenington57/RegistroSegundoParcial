using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RegistroSegundoParcial.Entidades
{
    public class Articulos
    {
        [Key]

        public int ArticuloId { get; set; }

        public string Descripcion { get; set; }

        public double Costo { get; set; }

        public double Precio { get; set; }

        public double PorcientoGanacia { get; set; }

        public double Inventario { get; set; }


        public Articulos()
        {
            ArticuloId = 0;
            Descripcion = string.Empty;
            Costo = 0;
            Precio = 0;
            PorcientoGanacia = 0;
            Inventario = 0;
        }


        public override string ToString()
        {
            return Descripcion;
        }
    }
}
