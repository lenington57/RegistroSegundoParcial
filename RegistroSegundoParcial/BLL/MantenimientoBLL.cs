using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Linq.Expressions;
using RegistroSegundoParcial.DAL;
using RegistroSegundoParcial.Entidades;

namespace RegistroSegundoParcial.BLL
{
    public class MantenimientoBLL
    {
        public static bool Guardar(Mantenimiento mantenimiento)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Mantenimiento.Add(mantenimiento) != null)

                    foreach (var item in mantenimiento.Detalle)
                    {
                        contexto.Articulos.Find(item.ArticuloId).Inventario -= item.Cantidad;
                    }
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

        public static bool Modificar(Mantenimiento mantenimiento)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var MantetAnt = MantenimientoBLL.Buscar(mantenimiento.MantenimientoId);

                foreach (var item in MantetAnt.Detalle)
                {
                    contexto.Articulos.Find(item.ArticuloId).Inventario -= item.Cantidad;

                    if (!mantenimiento.Detalle.ToList().Exists(v => v.Id == item.Id))
                    {
                        contexto.Articulos.Find(item.ArticuloId).Inventario -= item.Cantidad;
                        item.Articulos = null;
                        contexto.Entry(item).State = EntityState.Deleted;
                    }
                }
                
                foreach (var item in mantenimiento.Detalle)
                {
                    contexto.Articulos.Find(item.ArticuloId).Inventario -= item.Cantidad;
                    
                    var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                    contexto.Entry(item).State = estado;
                }

                contexto.Entry(mantenimiento).State = EntityState.Modified;
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
                Mantenimiento mantenimiento = contexto.Mantenimiento.Find(id);

                foreach (var item in mantenimiento.Detalle)
                {
                    var EliminInventario = contexto.Articulos.Find(item.ArticuloId);
                    EliminInventario.Inventario -= item.Cantidad;
                }

                contexto.Mantenimiento.Remove(mantenimiento);

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


        public static Mantenimiento Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Mantenimiento mantenimiento = new Mantenimiento();
            try
            {
                mantenimiento = contexto.Mantenimiento.Find(id);

                if (mantenimiento != null)
                {
                    mantenimiento.Detalle.Count();

                    foreach (var item in mantenimiento.Detalle)
                    {

                        string s = item.Articulos.Descripcion;
                        string ss = item.Talleres.Nombre;
                        string sss = item.Vehiculos.Descripcion;
                    }
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return mantenimiento;
        }


        public static List<Mantenimiento> GetList(Expression<Func<Mantenimiento, bool>> expression)
        {
            List<Mantenimiento> mantenimiento = new List<Mantenimiento>();
            Contexto contexto = new Contexto();
            try
            {
                mantenimiento = contexto.Mantenimiento.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return mantenimiento;
        }

        public static double Importe(double cantidad, double precio)
        {
            double CalImporte = 0;

            CalImporte = cantidad * precio;

            return CalImporte;
        }

        public static void CostoMantenimiento(double total, string nombre)
        {
            foreach (var item in VehiculosBLL.GetList(x => x.Descripcion == nombre))
            {

                item.TotalMantenimiento += total;
                VehiculosBLL.Modificar(item);
            }
        }

        public static void Cantidad(double Cantidad, string descripcion)
        {
            foreach (var item in ArticulosBLL.GetList(x => x.Descripcion == descripcion))
            {
                item.Inventario += Cantidad;
                ArticulosBLL.Modificar(item);
            }
        }

    }
}