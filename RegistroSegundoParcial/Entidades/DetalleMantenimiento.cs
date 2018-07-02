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

        public int VehiculosId { get; set; }

        public DateTime Fecha { get; set; }

        public string Taller { get; set; }

        public string Servicio { get; set; }

        public int Cantidad { get; set; }

        public int Precio { get; set; }

        public int Importe { get; set; }

        public int Total { get; set; }

        [ForeignKey("VehiculosId")]
        public virtual Vehiculos Vehiculos { get; set; }

        public DetalleMantenimiento()
        {
            Id = 0;
            VehiculosId = 0;
            Fecha = DateTime.Now;
            Taller = string.Empty;
            Servicio = string.Empty;
            Cantidad = 0;
            Precio = 0;
            Importe = 0;
            Total = 0;
        }

        public DetalleMantenimiento(int id, DateTime fecha, string taller, string servicio, int cantidad, int precio, int importe, int total)
        {
            Id = id;
            Fecha = fecha;
            Taller = taller;
            Servicio = servicio;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
            Total = total;
        }
    }
}
