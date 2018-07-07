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
    public class EntradasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Entradas entrada = new Entradas();
            entrada.EntradaId = 3;
            entrada.Articulo = "Clinch";
            entrada.Cantidad = 10; 
            paso = EntradasBLL.Guardar(entrada);
            Assert.AreEqual(paso, true); 
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Entradas entrada = new Entradas();
            entrada.EntradaId = 3;
            entrada.Articulo = "Clinch";
            entrada.Cantidad = 8; 
            paso = EntradasBLL.Guardar(entrada);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            int id = 3;
            bool paso;
            paso = EntradasBLL.Eliminar(id);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 2;
            Entradas entrada = new Entradas();
            entrada = EntradasBLL.Buscar(id);
            Assert.IsNotNull(entrada);
        }

        [TestMethod()]
        public void GetListTest(Expression<Func<Entradas, bool>> expression)
        {
            Contexto contexto = new Contexto();

            List<Entradas> ListEntradas = new List<Entradas>();
            ListEntradas = contexto.Entradas.Where(expression).ToList();
            Assert.IsNotNull(ListEntradas);
        }

        [TestMethod()]
        public void LlenarInventarioTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RebajarInventarioTest()
        {
            Assert.Fail();
        }
    }
}