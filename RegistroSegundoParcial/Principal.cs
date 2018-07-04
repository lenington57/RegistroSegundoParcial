using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RegistroSegundoParcial.UI.Registros;
namespace RegistroSegundoParcial
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void registrarArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarArticulo registrarArticulo = new RegistrarArticulo();
            registrarArticulo.Show();
        }

        private void registrarEntradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarEntradaArticulos registrarEntradaArticulos = new RegistrarEntradaArticulos();
            registrarEntradaArticulos.Show();
        }

        private void registrarTalleresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarTalleres registrarTalleres = new RegistrarTalleres();
            registrarTalleres.Show();
        }

        private void registrarVehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarVehiculos registrarVehiculos = new RegistrarVehiculos();
            registrarVehiculos.Show();
        }

        private void registrarMantenimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrarMantenimiento registrarMantenimiento = new RegistrarMantenimiento();
            registrarMantenimiento.Show();
        }
    }
}
