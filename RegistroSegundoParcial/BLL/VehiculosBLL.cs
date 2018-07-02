using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RegistroSegundoParcial.Entidades;
using RegistroSegundoParcial.DAL;
using System.Linq.Expressions;

namespace RegistroSegundoParcial.BLL
{
    public class VehiculosBLL
    {
        public static List<Vehiculos> GetList(Expression<Func<Vehiculos, bool>> expression)
        {
            List<Vehiculos> vehiculos = new List<Vehiculos>();
            Contexto contexto = new Contexto();

            try
            {
                vehiculos = contexto.Vehiculos.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return vehiculos;
        }
    }
}
