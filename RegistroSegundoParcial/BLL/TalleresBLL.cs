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
    public class TalleresBLL
    {
        public static bool Guardar(Talleres talleres)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Talleres.Add(talleres) != null)
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


        public static bool Modificar(Talleres talleres)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(talleres).State = EntityState.Modified;
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
                Talleres talleres = contexto.Talleres.Find(id);

                contexto.Talleres.Remove(talleres);

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();//Siempre hay que cerrar la conexión.
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public static Talleres Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Talleres talleres = new Talleres();
            try
            {
                talleres = contexto.Talleres.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return talleres;
        }


        public static List<Talleres> GetList(Expression<Func<Talleres, bool>> expression)
        {
            List<Talleres> talleres = new List<Talleres>();
            Contexto contexto = new Contexto();

            try
            {
                talleres = contexto.Talleres.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return talleres;
        }
    }
}
