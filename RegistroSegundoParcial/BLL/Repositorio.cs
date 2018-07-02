using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using RegistroSegundoParcial.DAL;

namespace RegistroSegundoParcial.BLL
{
    public class Repositorio<T> : IDisposable, IRepository<T> where T : class
    {
        internal Contexto _contexto;
        public T Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetList(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(T entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}
