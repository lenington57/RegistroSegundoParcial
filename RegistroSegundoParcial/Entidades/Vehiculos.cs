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

        public double TotalMantenimiento { get; set; }


        public Vehiculos()
        {
            VehiculoId = 0;
            Descripcion = string.Empty;
            TotalMantenimiento = 0;
        }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
