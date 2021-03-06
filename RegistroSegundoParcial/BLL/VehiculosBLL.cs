﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RegistroSegundoParcial.Entidades;
using RegistroSegundoParcial.DAL;
using System.Linq.Expressions;
using System.Data.Entity;

namespace RegistroSegundoParcial.BLL
{
    public class VehiculosBLL
    {
        public static bool Guardar(Vehiculos vehiculo)
        {
            bool paso = false;
            
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Vehiculos.Add(vehiculo) != null)
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

        
        public static bool Modificar(Vehiculos vehiculo)
        {
            bool paso = false;
            
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(vehiculo).State = EntityState.Modified;
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
                Vehiculos vehiculo = contexto.Vehiculos.Find(id);

                contexto.Vehiculos.Remove(vehiculo);

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

        
        public static Vehiculos Buscar(int id)
        {            
            Contexto contexto = new Contexto();
            Vehiculos vehiculo = new Vehiculos();
            try
            {
                vehiculo = contexto.Vehiculos.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return vehiculo;
        }
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
