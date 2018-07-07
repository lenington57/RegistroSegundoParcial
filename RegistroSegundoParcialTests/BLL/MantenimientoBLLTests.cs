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
    public class MantenimientoBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Mantenimiento mantenimiento = new Mantenimiento();
            mantenimiento.MantenimientoId = 5;
            mantenimiento.Fecha = DateTime.Now;
            mantenimiento.FechaProximo = DateTime.Now.AddMonths(3);

            mantenimiento.Detalle.Add(new MantenimientoDetalle(0, 0, 1, 1, 2, "Aceite",5, 10, 50));
            mantenimiento.Detalle.Add(new MantenimientoDetalle(0, 0, 2, 3, 4, "Banda de Frenos", 10, 40, 400));

            bool paso = MantenimientoBLL.Guardar(mantenimiento);
            Assert.AreEqual(true, paso);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            int idMantenimiento = MantenimientoBLL.GetList(x => true)[0].MantenimientoId;
            Mantenimiento mantenimiento = MantenimientoBLL.Buscar(idMantenimiento);
            
            mantenimiento.Detalle.Add(new MantenimientoDetalle(0, mantenimiento.MantenimientoId, 2, 4, 50, "Banda De Frenos", 2, 100, 200));
            bool paso = MantenimientoBLL.Modificar(mantenimiento);
            Assert.AreEqual(true, paso);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            int idMantenimiento = MantenimientoBLL.GetList(x => true)[0].MantenimientoId;
            bool paso = MantenimientoBLL.Eliminar(idMantenimiento);
            Assert.AreEqual(true, paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int idMantenimiento = MantenimientoBLL.GetList(x => true)[0].MantenimientoId;

            Mantenimiento mantenimiento = MantenimientoBLL.Buscar(idMantenimiento);
            bool paso = mantenimiento.Detalle.Count > 0;
            Assert.AreEqual(true, paso);
        }

        [TestMethod()]
        public void GetListTest(Expression<Func<Mantenimiento, bool>> expression)
        {
            Contexto contexto = new Contexto();

            List<Mantenimiento> ListMantenimiento = new List<Mantenimiento>();
            ListMantenimiento = contexto.Mantenimiento.Where(expression).ToList();
            Assert.IsNotNull(ListMantenimiento);
        }

        [TestMethod()]
        public void ImporteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CostoMantenimientoTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CantidadTest()
        {
            Assert.Fail();
        }
    }
}