using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroSegundoParcial.BLL;
using RegistroSegundoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegistroSegundoParcial.BLL.Tests
{
    [TestClass()]
    public class VehiculosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Vehiculos vehiculos = new Vehiculos()
            {
                VehiculoId = 1,
                Descripcion = "Toyota Corolla 2005 Le",
                Mantenimiento = 0
            };
            
            
            paso = VehiculosBLL.Guardar(vehiculos);
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