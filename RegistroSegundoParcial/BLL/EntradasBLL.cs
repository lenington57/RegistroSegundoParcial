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
    public class EntradasBLL
    {
        public static bool Guardar(Entradas entradas)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Entradas.Add(entradas) != null)
                {
                    var Articulo = contexto.Articulos.Find(entradas.ArticuloId);
                    Articulo.Inventario += entradas.Cantidad;

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


        public static bool Modificar(Entradas entradas)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                Entradas EntrAnt = EntradasBLL.Buscar(entradas.EntradaId);

                if (EntrAnt.ArticuloId != entradas.ArticuloId)
                {
                    ModificarBien(entradas, EntrAnt);
                }

               
                    double modificado = entradas.Cantidad - EntrAnt.Cantidad;

                    var Articulo = contexto.Articulos.Find(entradas.ArticuloId);
                    Articulo.Inventario += modificado;
                    ArticulosBLL.Modificar(Articulo);

                contexto.Entry(entradas).State = EntityState.Modified;
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
                Entradas entradas = contexto.Entradas.Find(id);

                var Articulo = contexto.Articulos.Find(entradas.ArticuloId);
                Articulo.Inventario -= entradas.Cantidad;

                contexto.Entradas.Remove(entradas);

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


        public static Entradas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Entradas entradas = new Entradas();
            try
            {
                entradas = contexto.Entradas.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return entradas;
        }
        public static List<Entradas> GetList(Expression<Func<Entradas, bool>> expression)
        {
            List<Entradas> entradas = new List<Entradas>();
            Contexto contexto = new Contexto();

            try
            {
                entradas = contexto.Entradas.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return entradas;
        }

        public static void ModificarBien(Entradas entradas, Entradas EntradasAnteriores)
        {
            Contexto contexto = new Contexto();
            var Articulo = contexto.Articulos.Find(entradas.ArticuloId);
            var ArticulosAnteriores = contexto.Articulos.Find(EntradasAnteriores.ArticuloId);
            
            Articulo.Inventario += entradas.Cantidad;
            ArticulosAnteriores.Inventario -= EntradasAnteriores.Cantidad;
            ArticulosBLL.Modificar(Articulo);
            ArticulosBLL.Modificar(ArticulosAnteriores);
        }

    }
}
