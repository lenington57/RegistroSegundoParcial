using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RegistroSegundoParcial.Entidades
{
    public class Mantenimiento
    {
        [Key]

        public int MantenimientoId { get; set; }

        public DateTime Fecha { get; set; }

        public DateTime FechaProximo { get; set; }

        public int SubTotal { get; set; }

        public int Itbis { get; set; }

        public int Total { get; set; }


        public virtual List<MantenimientoDetalle> Detalle { get; set; }

        public Mantenimiento()
        {
            this.Detalle = new List<MantenimientoDetalle>();
        }

        public void AgregarDetalle(int Id, int MantenimientoId, int VehiculoId, int TallerId, int ArticuloId, string Articulo, int Cantidad, int Precio, int Importe)
        {
            this.Detalle.Add(new MantenimientoDetalle(Id, MantenimientoId, VehiculoId, TallerId, ArticuloId, Articulo, Cantidad, Precio, Importe));
        }
    }
}
