using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroSegundoParcial.BLL;
using RegistroSegundoParcial.DAL;
using RegistroSegundoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            Vehiculos vehiculo = new Vehiculos();
            vehiculo.VehiculoId = 1;
            vehiculo.Descripcion = "Toyota Corolla 2005 Le";
            vehiculo.TotalMantenimiento = 0;            
            paso = VehiculosBLL.Guardar(vehiculo);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Vehiculos vehiculo = new Vehiculos();
            vehiculo.VehiculoId = 1;
            vehiculo.Descripcion = "Toyota Corolla 2008 Le";
            vehiculo.TotalMantenimiento = 0;
            paso = VehiculosBLL.Modificar(vehiculo);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            int id = 2;
            bool paso;
            paso = VehiculosBLL.Eliminar(id);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 2;
            Vehiculos vehiculo = new Vehiculos();
            vehiculo = VehiculosBLL.Buscar(id);
            Assert.IsNotNull(vehiculo);
        }

        [TestMethod()]
        public void GetListTest(Expression<Func<Vehiculos, bool>> expression)
        {
            Contexto contexto = new Contexto();

            List<Vehiculos> ListVehiculos = new List<Vehiculos>();
            ListVehiculos = contexto.Vehiculos.Where(expression).ToList();
            Assert.IsNotNull(ListVehiculos);
        }
    }
}