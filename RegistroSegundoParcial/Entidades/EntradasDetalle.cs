using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroSegundoParcial.Entidades
{
    public class EntradasDetalle
    {
        [Key]

        public int Id { get; set; }

        public int EntradaId { get; set; }

        public int ArticuloId { get; set; }

        public int CantidadInventario { get; set; }

        [ForeignKey("ArticuloId")]
        public virtual Articulos Articulos { get; set; }

        public EntradasDetalle()
        {
            Id = 0;
            EntradaId = 0;
            ArticuloId = 0;
            CantidadInventario = 0;          
        }

        public EntradasDetalle(int id, int entradaId, int articuloId, int cantidadInventario)
        {
            Id = id;
            EntradaId = entradaId;
            ArticuloId = articuloId;
            CantidadInventario = cantidadInventario;
        }
    }
}
