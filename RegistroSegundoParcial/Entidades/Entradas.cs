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

        public string Articulo { get; set; }

        public int Cantidad { get; set; }


        public virtual List<EntradasDetalle> Detalle { get; set; }

        public Entradas()
        {
            this.Detalle = new List<EntradasDetalle>();
        }

        public void AgregarDetalle(int Id, int EntradaId, int ArticuloId, int CantidadInventario)
        {
            this.Detalle.Add(new EntradasDetalle(Id, EntradaId, ArticuloId, CantidadInventario));
        }
    }
}
