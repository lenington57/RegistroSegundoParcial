using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroSegundoParcial.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RegistroSegundoParcial.Entidades;
using RegistroSegundoParcial.DAL;
using System.Linq.Expressions;

namespace RegistroSegundoParcial.BLL.Tests
{
    [TestClass()]
    public class ArticulosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Articulos articulo = new Articulos();
            articulo.ArticuloId = 3;
            articulo.Descripcion= "Clinch";
            articulo.Costo = 20;
            articulo.Precio = 100;            
            articulo.PorcientoGanacia = 10;
            articulo.Inventario = 0; ;
            paso = ArticulosBLL.Guardar(articulo);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Articulos articulo = new Articulos();
            articulo.ArticuloId = 3;
            articulo.Descripcion = "Clinch";
            articulo.Costo = 40;
            articulo.Precio = 80;
            articulo.PorcientoGanacia = 30;
            articulo.Inventario = 0; ;
            paso = ArticulosBLL.Guardar(articulo);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            int id = 3;
            bool paso;
            paso = ArticulosBLL.Eliminar(id);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 2;
            Articulos articulos = new Articulos();
            articulos = ArticulosBLL.Buscar(id);
            Assert.IsNotNull(articulos);
        }

        [TestMethod()]
        public void GetListTest(Expression<Func<Articulos, bool>> expression)
        {
            Contexto contexto = new Contexto();

            List<Articulos> ListArticulos = new List<Articulos>();
            ListArticulos = contexto.Articulos.Where(expression).ToList();
            Assert.IsNotNull(ListArticulos);
        }
    }
}