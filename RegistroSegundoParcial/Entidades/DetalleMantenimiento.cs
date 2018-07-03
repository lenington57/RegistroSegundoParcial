using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace RegistroSegundoParcial.Entidades
{
    public class DetalleMantenimiento
    {
        [Key]

        public int Id { get; set; }

        public int VehiculoId { get; set; }

        public int TallerId { get; set; }

        public int ArticuloId { get; set; }

        public DateTime Fecha { get; set; }

        public string Articulo { get; set; }

        public int Cantidad { get; set; }

        public int Precio { get; set; }

        public int Importe { get; set; }

        public int SubTotal { get; set; }

        public int Itbis { get; set; }

        public int Total { get; set; }

        [ForeignKey("VehiculoId")]
        public virtual Vehiculos Vehiculos { get; set; }

        [ForeignKey("TallerId")]
        public virtual Talleres Talleres { get; set; }

        [ForeignKey("ArticuloId")]
        public virtual Articulos Articulos { get; set; }

        public DetalleMantenimiento()
        {
            Id = 0;
            VehiculoId = 0;
            TallerId = 0;
            ArticuloId = 0;
            Fecha = DateTime.Now;
            Articulo = string.Empty;
            Cantidad = 0;
            Precio = 0;
            Importe = 0;
            SubTotal = 0;
            Itbis = 0;
            Total = 0;
        }

        public DetalleMantenimiento(int id, int vehiculoId, int tallerId, int articuloId, DateTime fecha, string articulo, int cantidad, int precio, int importe, int subTotal, int itbis, int total)
        {
            Id = id;
            Fecha = fecha;
            VehiculoId = vehiculoId;
            TallerId = tallerId;
            ArticuloId = articuloId;
            Articulo = articulo;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
            SubTotal = subTotal;
            Itbis = itbis;
            Total = total;
        }
    }
}
