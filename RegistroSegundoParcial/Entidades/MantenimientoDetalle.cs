using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroSegundoParcial.Entidades
{
    public class MantenimientoDetalle
    {
        [Key]

        public int Id { get; set; }

        public int MantenimientoId { get; set; }

        public int VehiculoId { get; set; }

        public int TallerId { get; set; }

        public int ArticuloId { get; set; }        

        public string Articulo { get; set; }

        public double Cantidad { get; set; }

        public double Precio { get; set; }

        public double Importe { get; set; }

        [ForeignKey("VehiculoId")]
        public virtual Vehiculos Vehiculos { get; set; }

        [ForeignKey("TallerId")]
        public virtual Talleres Talleres { get; set; }

        [ForeignKey("ArticuloId")]
        public virtual Articulos Articulos { get; set; }

        public MantenimientoDetalle()
        {
            Id = 0;
            MantenimientoId = 0;
            VehiculoId = 0;
            TallerId = 0;
            ArticuloId = 0;
            Articulo = string.Empty;
            Cantidad = 0;
            Precio = 0;
            Importe = 0;
        }

        public MantenimientoDetalle(int id, int mantenimientoId, int vehiculoId, int tallerId, int articuloId, string articulo, double cantidad, double precio, double importe)
        {
            Id = id;
            MantenimientoId = mantenimientoId;
            VehiculoId = vehiculoId;
            TallerId = tallerId;
            ArticuloId = articuloId;
            Articulo = articulo;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
        }
    }
}


   