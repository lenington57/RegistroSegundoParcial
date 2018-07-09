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
    public class TalleresBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Talleres taller = new Talleres();
            taller.TallerId = 4;
            taller.Nombre = "Taller Los Muchachos";

            paso = TalleresBLL.Guardar(taller);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Talleres taller = new Talleres();
            taller.TallerId = 4;
            taller.Nombre = "Taller Los Muchachones";

            paso = TalleresBLL.Modificar(taller);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            int id = 3;
            bool paso;
            paso = TalleresBLL.Eliminar(id);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 4;
            Talleres taller = new Talleres();
            taller = TalleresBLL.Buscar(id);
            Assert.IsNotNull(taller);
        }

        [TestMethod()]
        public void GetListTest(Expression<Func<Talleres, bool>> expression)
        {
            Contexto contexto = new Contexto();

            List<Talleres> ListTalleres = new List<Talleres>();
            ListTalleres = contexto.Talleres.Where(expression).ToList();
            Assert.IsNotNull(ListTalleres);
        }
    }
}