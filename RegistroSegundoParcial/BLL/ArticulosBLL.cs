using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RegistroSegundoParcial.Entidades;
using RegistroSegundoParcial.DAL;
using System.Linq.Expressions;
using System.Data.Entity;

namespace RegistroSegundoParcial.BLL
{
    public class ArticulosBLL
    {
        public static bool Guardar(Articulos articulos)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Articulos.Add(articulos) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public static bool Modificar(Articulos articulos)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(articulos).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public static bool Eliminar(int id)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                Articulos articulos = contexto.Articulos.Find(id);

                contexto.Articulos.Remove(articulos);

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public static Articulos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Articulos articulos = new Articulos();
            try
            {
                articulos = contexto.Articulos.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return articulos;
        }


        public static List<Articulos> GetList(Expression<Func<Articulos, bool>> expression)
        {
            List<Articulos> articulos = new List<Articulos>();
            Contexto contexto = new Contexto();

            try
            {
                articulos = contexto.Articulos.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return articulos;
        }

        public static double PorcientoGanancia(double costo, double precio)
        {
            double PctGanancia;

            PctGanancia = precio - costo;
            PctGanancia = PctGanancia / costo;
            PctGanancia *= 100;

            return PctGanancia;
        }
    }
}
