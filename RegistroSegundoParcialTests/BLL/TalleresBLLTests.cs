using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroSegundoParcial.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RegistroSegundoParcial.Entidades;

namespace RegistroSegundoParcial.BLL.Tests
{
    [TestClass()]
    public class TalleresBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Talleres talleres = new Talleres();
            talleres.TallerId = 4;
            talleres.Nombre = "Taller Los Muchachos";

            paso = TalleresBLL.Guardar(talleres);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }
    }
}