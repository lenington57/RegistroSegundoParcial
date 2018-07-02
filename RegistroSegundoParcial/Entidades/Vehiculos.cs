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

        public int VehiculosId { get; set; }

        public string Descripcion { get; set; }

        public int Mantenimiento { get; set; }


        public virtual List<DetalleMantenimiento> Detalle { get; set; }



        public Vehiculos()
        {
            this.Detalle = new List<DetalleMantenimiento>();
        }

        public void AgregarDetalle(int Id, DateTime Fecha, string Taller, string Servicio, int Cantidad, int Precio, int Importe, int Total)
        {
            this.Detalle.Add(new DetalleMantenimiento(Id, Fecha, Taller, Servicio, Cantidad, Precio, Importe, Total));
        }
    }
}
