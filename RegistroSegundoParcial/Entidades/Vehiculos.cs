using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;


namespace RegistroSegundoParcial.Entidades
{
    public class Vehiculos
    {
        [Key]

        public int VehiculoId { get; set; }

        public string Descripcion { get; set; }

        public int Mantenimiento { get; set; }


        public virtual List<DetalleMantenimiento> Detalle { get; set; }



        public Vehiculos()
        {
            this.Detalle = new List<DetalleMantenimiento>();
        }

        public void AgregarDetalle(int Id, int VehiculoId, int TallerId, int ArticuloId, DateTime Fecha, string Articulo, int Cantidad, int Precio, int Importe, int SubTotal, int Itbis, int Total)
        {
            this.Detalle.Add(new DetalleMantenimiento(Id, VehiculoId, TallerId, ArticuloId, Fecha, Articulo, Cantidad, Precio, Importe, SubTotal, Itbis, Total));
        }
    }
}
