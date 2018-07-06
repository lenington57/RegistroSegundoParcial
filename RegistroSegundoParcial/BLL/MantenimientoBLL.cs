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
                {
                    Cantidad(Buscar(mantenimiento.MantenimientoId).Detalle);
                    CostoMantenimiento(Buscar(mantenimiento.MantenimientoId).Detalle);
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
                var ManteniAnt = MantenimientoBLL.Buscar(mantenimiento.MantenimientoId);

                foreach (var item in ManteniAnt.Detalle)
                {
                    contexto.Vehiculos.Find(item.VehiculoId).TotalMantenimiento += item.Importe;

                    if (!mantenimiento.Detalle.ToList().Exists(v => v.Id == item.Id))
                    {
                        contexto.Vehiculos.Find(item.VehiculoId).TotalMantenimiento += item.Importe;
                        item.Articulos = null;
                        contexto.Entry(item).State = EntityState.Deleted;
                    }
                }

                foreach (var item in mantenimiento.Detalle)
                {
                    contexto.Vehiculos.Find(item.VehiculoId).TotalMantenimiento += item.Importe;

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
                    var articulos = contexto.Mantenimiento.Find(item.MantenimientoId);
                    mantenimiento.Total -= item.Importe;

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

        public static float Importe(float cantidad, float precio)
        {
            float CalImporte = 0;

            CalImporte = cantidad * precio;

            return CalImporte;
        }

        public static void CostoMantenimiento(List<MantenimientoDetalle> list)
        {
            foreach (var item in list)
            {
                var costo = MantenimientoBLL.Buscar(item.MantenimientoId);

                costo.MantenimientoId += item.Importe;
                MantenimientoBLL.Modificar(costo);
            }

        }

        public static void Cantidad(List<MantenimientoDetalle> list)
        {
            foreach (var item in list)
            {
                var cantidad = ArticulosBLL.Buscar(item.ArticuloId);

                cantidad.Inventario -= item.Cantidad;
                ArticulosBLL.Modificar(cantidad);
            }
        }

    }
}
